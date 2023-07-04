using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using project1.Models.DTO;

namespace project1.Models.DAO
{
    public class UserDAO
    {

        public string InsertUser(UserDTO user, int roleId)


        {
            string response = "Failed";

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string insertUserQuery = "INSERT INTO Users (name, email) VALUES (@name, @email)";
                    string insertRolesUsuarioQuery = "INSERT INTO RolesUsuario (id_user, id_role) VALUES (@userId, @roleId)";

                    using (MySqlCommand userCommand = new MySqlCommand(insertUserQuery, connection))
                    {
                        userCommand.Parameters.AddWithValue("@name", user.Name);
                        userCommand.Parameters.AddWithValue("@email", user.Email);

                        int rowsAffected = userCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Obtén el ID del usuario insertado
                            int userId = (int)userCommand.LastInsertedId;

                            // Utiliza la conexión de AuthorizationConfig para insertar en RolesUsuario
                            using (var context = new AuthorizationConfig())
                            {
                                var authConnection = context.Database.Connection;

                                authConnection.Open();

                                using (MySqlCommand roleCommand = new MySqlCommand(insertRolesUsuarioQuery, (MySqlConnection)authConnection))
                                {
                                    roleCommand.Parameters.AddWithValue("@userId", userId);
                                    roleCommand.Parameters.AddWithValue("@roleId", user.RoleId);

                                    int rolesAffected = roleCommand.ExecuteNonQuery();

                                    if (rolesAffected > 0)
                                    {
                                        response = "Success";
                                        Console.WriteLine("User and RolesUsuario inserted successfully.");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UserDAO.InsertUser: " + ex.Message);
            }

            return response;
        }


        public List<UserDTO> ReadUsers()
        {
            List<UserDTO> users = new List<UserDTO>();

            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Users";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                       using (MySqlDataReader reader =command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserDTO user = new UserDTO();
                                user.Id = reader.GetInt32("id");
                                user.Name = reader.GetString("name");
                                user.Email = reader.GetString("email");
                                users.Add(user);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in project1.Models.DAO.UserDAO.InserUser:" + ex.Message);
            }
            return users;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>

       
        public UserDTO GetUserById(int id)
        {
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string selectQuery = "SELECT Id, Name, Email FROM Users WHERE Id = @id";

                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserDTO user = new UserDTO
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    Email = reader["Email"].ToString()
                                };

                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UserDAO.GetUserById: " + ex.Message);
            }

            return null;
        }

        public string UpdateUser(UserDTO user)
        {
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string updateQuery = "UPDATE Users SET name = @name, email = @email WHERE Id = @id";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", user.Name);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@id", user.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UserDAO.UpdateUser: " + ex.Message);
            }

            return "Failed";
        }

        public string DeleteUser(int id)
        {
            try
            {
                using (MySqlConnection connection = Config.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Users WHERE Id = @id";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UserDAO.DeleteUser: " + ex.Message);
            }

            return "Failed";
        }
    }
}