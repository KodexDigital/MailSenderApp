using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailSenderApp.ViewModels
{
	public class MailSenderViewModel
	{
		[Display(Name ="Subject")]
		public string Title { get; set; }
		[Display(Name = "To")]
		public string RecipientEmail { get; set; }
		public string Body { get; set; }
		public string Attachments { get; set; }
	}
}
