using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MailSenderApp.Models;
using MailSenderApp.ViewModels;
using System.Net.Mail;
using System.Net;

namespace MailSenderApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult SendMail()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SendMail(MailSenderViewModel model)
		{
			if(ModelState.IsValid)
			{
				MailMessage msg = new MailMessage
				{
					From = new MailAddress("digitalkenth@gmail.com"),
				};
				msg.To.Add(model.RecipientEmail);
				msg.Subject = model.Title;
				msg.Body = model.Body;

				SmtpClient client = new SmtpClient
				{
					Host = "smtp.gmail.com"
				};
				NetworkCredential credential = new NetworkCredential
				{
					UserName = "aptechweb2019@gmail.com",
					Password = "aptech2019@"
				};
				client.Credentials = credential;
				client.EnableSsl = true;
				client.Port = 587;
				client.Send(msg);

				ViewBag.Success = $"Email has been sent successfully to {model.RecipientEmail}";
			}
			return View(model);
		}

		public IActionResult Index()
		{
			return View();
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
