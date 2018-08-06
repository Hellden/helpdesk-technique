using System;
using System.ComponentModel.DataAnnotations;

namespace TT_MVC.Models
{
	public class Model_Ticket_Validation
	{
		public int Id { get; set; }
		public string Commentaire { get; set; }
		public DateTime DateFinTicket { get; set; }
		public int Validation { get; set; }
	}
}