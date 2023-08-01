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
        private UserDAO userRepository = new UserDAO();  // Instancia del DAO para interactuar con los usuarios en la base de datos
        private AuthorizationConfig _db = new AuthorizationConfig(); // Instancia del contexto de base de datos

        // GET: User
        public ActionResult Index()

         
        {
            // Obtener una lista de todas las facturas de la base de datos
            var invoices = _db.Invoices.ToList();


            // Usando Lambda para filtrar facturas del cliente "Cliente A""
            List<Invoice> invoiceCustomerA = invoices.Where(invoice => invoice.Customer == "Cliente A").ToList();

            // Usando LINQ para filtrar facturas del cliente "Cliente A"
            List<Invoice> invoiceCustomerALINQ = (
                from invoice in invoices 
                where invoice.Customer == "Cliente A" 
                select invoice)
                .ToList();

            var totalinvoiceRecord = invoices.Count(); // Contar el número total de facturas (Lambda) **

            var upInvoice = invoices.Max(i => i.Total); // Encontrar la factura con el monto más alto (Lambda)
            var upInvoice2 = invoices.OrderByDescending(i => i.Total).FirstOrDefault(); // Encontrar la factura con el monto más alto usando (Lambda)
            Invoice upInvoice2LINQ = (from invoice in invoices orderby invoice.Total descending select invoice).FirstOrDefault();  // Usando LINQ para encontrar la factura con el monto más alto


            var greaterThan500 = invoices.Any(i => i.Total > 500); // Verificar si alguna factura tiene un monto mayor a 500 (Lambda)
            var totalSum = invoices.Sum(i => i.Total); // Calcular la suma total de todos los montos de las facturas (Lambda)
            var greaterThan100AndDifferentCCustmer = invoices.Where(i => i.Total > 100 && i.Customer != "Cliente C"); // Filtrar facturas con montos mayores a 100 y de clientes diferentes a "Cliente C" (Lambda)
            var allGreaterThan50 = invoices.All(i => i.Total > 50); // Verificar si todas las facturas tienen montos mayores a 50 (Lambda)

            List<Invoice> first5records = (from i in invoices orderby i.Date select i).Take(5).ToList(); // Obtener las primeras 5 facturas ordenadas por fecha usando LINQ

            // Tarea LAMBDA 
            //1- ¿Cuál es el total de todas las facturas registradas en la base de datos? $9667.95
            decimal totalFacturasBLambda = invoices.Sum(i => i.Total);
            decimal totalFacturasLINQ = (
                from invoice 
                in invoices                
                select invoice.Total)
                .Sum();

            //2- ¿Cuántas facturas tiene el cliente "Cliente B"? 10 clientes 
            int cantidadFacturasClienteBLambda = invoices.Count(i => i.Customer == "Cliente B");
            int cantidadFacturasClienteLINQ = (
                from invoice in invoices
                where invoice.Customer == "Cliente B"
                select invoice)
                .Count();

            //3- ¿Cuál es la factura con el monto más bajo? Factura 25 con $40
            Invoice facturaConMontoMasBajoLambda = invoices.OrderBy(i => i.Total).FirstOrDefault();
            Invoice facturaConMontoMasBajoLINQ = (
                from invoice 
                in invoices 
                orderby invoice.Total 
                ascending select invoice)
                .FirstOrDefault();

            //4- Obtener una lista con los nombres de los clientes que tienen facturas con monto mayor a $200
            List<string> clientesConMontoMayor200Lambda = invoices.Where(invoice => invoice.Total > 200).Select(invoice => invoice.Customer).ToList();
            List<string> clientesConMontoMayor200LINQ = (
                from invoice in invoices
                where invoice.Total > 200
                select invoice.Customer)
                .ToList();

            //5- ¿Cuál es la fecha más antigua registrada en las facturas? 1/7/2023
            DateTime fechaMasAntiguaLambda = invoices.Min(invoice => invoice.Date);
            DateTime fechaMasAntiguaLINQ = (
                from invoice 
                in invoices 
                select invoice.Date)
                .Min();

            //6- Obtener una lista de las 5 facturas más recientes
            List<Invoice> ultimas5FacturasLambda = invoices.OrderByDescending(i => i.Date).Take(5).ToList();
            List<Invoice> ultimas5FacturasLINQ = (
                from invoice 
                in invoices
                orderby invoice.Date 
                descending select invoice)
                .Take(5)
                .ToList();
            List<string> nombresUltimas5FacturasLambda = invoices.OrderByDescending(i => i.Date).Take(5).Select(i => i.InvoiceNUmber).ToList();
            List<string> nombresUltimas5FacturasLINQ = (
                from invoice in invoices
                orderby invoice.Date descending
                select invoice.InvoiceNUmber)
                .Take(5)
                .ToList();

            //7- ¿Hay alguna factura registrada el día de hoy? no hay
            var hayFacturaHoyLambda = invoices.Any(i => i.Date.Date == DateTime.Today);
            var hayFacturaHoyLINQ = (
                from invoice 
                in invoices                     
                where invoice.Date == DateTime.Today                  
                select invoice).Any();

            //8- Obtener una lista de las facturas que tienen un monto menor o igual a $100 y un cliente distinto de "Cliente A". total 19
            List<Invoice> facturasFiltradasLambda = invoices.Where(i => i.Total <= 100 && i.Customer != "Cliente A").ToList();
            List<Invoice> facturasFiltradasLINQ = (
                from invoice in invoices
                where invoice.Total <= 100 && invoice.Customer != "Cliente A"
                select invoice)
                .ToList();

            //9- ¿Cuál es el promedio del monto de las facturas? $193.359
            decimal promedioMontoFacturasLambda = invoices.Average(invoice => invoice.Total);
            decimal promedioMontoFacturasLINQ = (
                from invoice 
                in invoices
                select invoice.Total)
                .Average();
            //10- Obtener una lista con los números de factura de las 10 facturas con montos más altos
            List<string> numerosFacturaMontosAltosLambda = invoices.OrderByDescending(invoice => invoice.Total).Take(10).Select(invoice => invoice.InvoiceNUmber).ToList();
            List<string> numerosFacturaMontosAltosLINQ = (
                from invoice in invoices
                orderby invoice.Total descending
                select invoice.InvoiceNUmber)
                .Take(10)
                .ToList();




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



        public ActionResult RolesList()
        {
            List<RolesUsuario> rolesList = new List<RolesUsuario>();

            try
            {
                using (var db = new AuthorizationConfig())
                {
                    rolesList = db.RolesUsuario.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in project1.Controllers.RolesController.ReadRoles: " + ex.Message);
            }

            return View(rolesList);
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
        public ActionResult Create(UserDTO user, RolesUsuario model)
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
                if (ModelState.IsValid)
                {
                    using (var db = new AuthorizationConfig())
                    {
                        // Crear una nueva instancia de RolesUsuario con los datos ingresados
                        var newRolesUsuario = new RolesUsuario
                        {
                            id_user = model.id_user,
                            id_role = model.id_role
                        };

                        // Agregar el nuevo RolesUsuario a la base de datos
                        db.RolesUsuario.Add(newRolesUsuario);
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index"); // Redirigir a la página deseada después de guardar los datos
                }

                // Si hay errores de validación, regresar a la vista con el modelo para mostrar los mensajes de error
                ViewBag.Roles = new SelectList(_db.Roles.ToList(), "id", "Description");
                return View(model);
            }


        }

 
        public ActionResult Createx()
        {
            // Obtener los roles disponibles
            var roles = _db.Roles.ToList();
            ViewBag.Roles = new SelectList(roles, "id", "Description");

            // var rolesusuario = _db.RolesUsuario.ToList();
            // ViewBag.RolesUsuario = new SelectList(rolesusuario, "id", "id_role", "id_user");

            return View();
        }

        // POST: User/Createx
        [HttpPost]

        public ActionResult Createx(RolesUsuario model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AuthorizationConfig())
                {
                    // Crear una nueva instancia de RolesUsuario con los datos ingresados
                    var newRolesUsuario = new RolesUsuario
                    {
                        id_user = model.id_user,
                        id_role = model.id_role
                    };

                    // Agregar el nuevo RolesUsuario a la base de datos
                    db.RolesUsuario.Add(newRolesUsuario);
                    db.SaveChanges();
                }

                return RedirectToAction("Index"); // Redirigir a la página deseada después de guardar los datos
            }

            // Si hay errores de validación, regresar a la vista con el modelo para mostrar los mensajes de error
            ViewBag.Roles = new SelectList(_db.Roles.ToList(), "id", "Description");
            return View(model);
        }


        [HttpGet]
        public ActionResult getRole(int id)
        {
            try
            {
                int idRole = _db.RolesUsuario.Where(x => x.id_user == id).FirstOrDefault().id_role;
                return Content(_db.Roles.Where(x => x.id == idRole).FirstOrDefault().Description);
            }
            catch (Exception ex)
            {
                return Content("DESCONOCIDO");

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
