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

        public ActionResult Index()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                users = userRepository.ReadUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting users: " + ex.Message);
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserDTO user)
        {
            try
            {
                string result = userRepository.InsertUser(user);
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
                UserDTO user = userRepository.GetUserById(id);
                if (user != null)
                {
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

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDTO user)
        {
            try
            {
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

        public ActionResult Delete(int id)
        {
            UserDTO user = userRepository.GetUserById(id);
            if (user == null)
            {
                // El usuario no existe, mostrar mensaje de error o redirigir a otra vista
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                string result = userRepository.DeleteUser(id);
                Console.WriteLine("User deleted: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting user: " + ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
