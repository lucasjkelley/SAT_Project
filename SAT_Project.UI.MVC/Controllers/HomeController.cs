﻿using Microsoft.AspNetCore.Mvc;
using SAT_Project.UI.MVC.Models;
using System.Diagnostics;
using MimeKit;
using MailKit.Net.Smtp;
using SAT_Project.UI.MVC.Controllers;
using System.Net.Mail;

namespace SAT_Project.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();

        
        }
        public IActionResult EmailConfirmation()
        {
            return View();
        }


        public IActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have received a new email from your site's contact form!<br />" +
                             $"Sender: {cvm.Name}<br />" +
                             $"Email: {cvm.Email}<br />" +
                             $"Phone: {cvm.Phone}<br />" +
                             $"Message: {cvm.Message}";


            var mm = new MimeMessage();


            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            mm.Subject = cvm.Phone;

            mm.Body = new TextPart("HTML") { Text = message };

            mm.Priority = MessagePriority.Urgent;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                    client.Authenticate(
                        _config.GetValue<string>("Credentials:Email:User"),
                        _config.GetValue<string>("Credentials:Email:Password")
                        );
                    client.Send(mm);
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = $"There was an issue processing your request. Please try" +
                        $"again later.<br/>Error Message: {ex.Message}";
                    return View(cvm);
                }

                return View("EmailConfirmation", cvm);

            }
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}