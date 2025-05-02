using ProfileProjectMVC.Models;
using ProfileProjectMVC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfileProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.EmailSuccessMessage = string.Empty;
            return View(new Email());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Index(Email email)
        {
            if (ModelState.IsValid)
            {
                bool IsEmailSent = new EmailService().sendEmail(email);
                if (IsEmailSent)
                {
                    return Content("<span class='text-success'>Thank you for reaching out to me! Your message has been successfully received.</span>");
                }
                else
                {
                    return Content("<span class='text-danger'>We apologize, but it seems there was an issue submitting your message.</span>");
                }
            }
            else
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                string errorMessage = string.Join("<br>", errorMessages);
                return Content("<span class='text-danger'>" + errorMessage + "</span>");
            }
        }
    }
}