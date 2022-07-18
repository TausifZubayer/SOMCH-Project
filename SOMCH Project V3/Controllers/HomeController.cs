using Microsoft.AspNetCore.Mvc;
using SOMCH_Project_V3.Models;
using System.Diagnostics;

namespace SOMCH_Project_V3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegUserInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegUserInfo(RegUserInfo user)
        {
            bool status = false;
            string message = "";

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                bool isExist = IsMobileNumberExist(user.MobileNumber);

                if(isExist)
                {
                    using(var context = new registration2Context())
                    {
                        var retrievedPassword = context.RegUserInfos.Where(a => a.MobileNumber == user.MobileNumber).SingleOrDefault();
                        if(retrievedPassword != null)
                        {
                            if(retrievedPassword.Password == user.Password)
                            {
                                status = true;
                                message = "Login Successful";
                            }
                        }
                    }
                } 
                else
                {
                    status = false;
                    message = "Invalid username or password";
                }
            } 
            else
            {
                status = false;
                message = "Invalid Request";
            }

            ViewBag.Status = status;
            ViewBag.Message = message;

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult PatientWorkList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [NonAction]
        public bool IsMobileNumberExist(string? mobileNumber)
        {
            using(var context = new registration2Context())
            {
                var retrievedMobileNumber = context.RegUserInfos.Where(a => a.MobileNumber == mobileNumber).FirstOrDefault();
                return retrievedMobileNumber != null;
            }
        }
    }
}