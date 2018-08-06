using System;
using System.ComponentModel.DataAnnotations;

namespace TT_MVC.Models
{
	public class Model_Ticket_Attente
	{
		[Required(ErrorMessage = "Le Nom est obligatoire !")]
		public string Nom { get; set; }

		[Display(Name = "Prénom")]
		public string Prenom { get; set; }

		public string Sujet { get; set; }

		[Required(ErrorMessage = "Un message est obligatoire !")]
		public string Message { get; set; }

		public DateTime? DateDebut { get; set; }

		public string Suivie { get; set; }

		public string Commentaire { get; set; }

		public int Validation { get; set; }

		public int Id { get; set; }

		[Display(Name = "Date de Fin")]
		public DateTime ?DateFinTicket { get; set; }
	}
}