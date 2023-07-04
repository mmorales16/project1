using project1.Models;
using project1.Models.DAO;
using project1.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project1.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userRepository = new UserDAO();
        private AuthorizationConfig _db = new AuthorizationConfig();
        
        // GET: User
        public ActionResult Index()
        {
            // Obtiene una lista de usuarios utilizando el método ReadUsers del repositorio UserDAO
            List<UserDTO> users = userRepository.ReadUsers();

            // Obtiene un usuario específico (con ID 5) de la lista de usuarios
            UserDTO user = (from u in users where 5 == u.Id select u).First();

            // Obtiene el rol del usuario a través de la tabla RolesUsuario en la base de datos
            RolesUsuario ru = _db.RolesUsuario.Where(x => x.id_user == user.Id).FirstOrDefault();

            // Asigna una variable de sesión con la descripción del rol del usuarioe
            Session["role"] = _db.Roles.Where(x => x.id == ru.id_role).FirstOrDefault().Description;

            // Obtiene una lista de roles
            var roles = _db.Roles.ToList();

            // Devuelve la vista Index con la lista de usuarios
            return View(userRepository.ReadUsers());
        }

        public ActionResult Create()
        {
            // Obtener los roles disponibles
            var roles = _db.Roles.ToList();
            ViewBag.Roles = new SelectList(roles, "id", "Description");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDTO user)
        {
            try
            {
                // Intenta insertar un nuevo usuario utilizando el método InsertUser del repositorio UserDAO
                string result = userRepository.InsertUser(user, user.RoleId);
                Console.WriteLine("User added: " + result);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                return View(user);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                // Intenta obtener un usuario específico utilizando el método GetUserById del repositorio UserDAO
                UserDTO user = userRepository.GetUserById(id);
                if (user != null)
                {
                    // Si el usuario existe, muestra la vista de edición con los detalles del usuario
                    return View(user);
                }
                else
                {
                    Console.WriteLine("User not found");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting user: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: User/Edit/
        [HttpPost]
        public ActionResult Edit(UserDTO user)
        {
            try
            {
                // Intenta actualizar los detalles del usuario utilizando el método UpdateUser del repositorio UserDAO
                string result = userRepository.UpdateUser(user);
                Console.WriteLine("User updated: " + result);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user: " + ex.Message);
                return View(user);
            }
        }
        // GET: User/Delete/
        public ActionResult Delete(int id)
        {
            // Obtiene un usuario específico utilizando el método GetUserById del repositorio UserDAO
            UserDTO user = userRepository.GetUserById(id);
            if (user == null)
            {
                // El usuario no existe, mostrar mensaje de error o redirigir a otra vista
                return RedirectToAction("Index");
            }

            return View(user);
        }
        // POST: User/Delete/
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Intenta eliminar el usuario utilizando el método DeleteUser del repositorio UserDAO
                string result = userRepository.DeleteUser(id);
                Console.WriteLine("User deleted: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
            }
            // Redirige a la vista Index después de eliminar el usuario
            return RedirectToAction("Index");
        }
    }
}
