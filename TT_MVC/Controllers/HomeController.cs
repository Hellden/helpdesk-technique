using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL;

namespace TT_MVC.Controllers
{
	public class HomeController : Controller
	{
		private TT_BDDEntities contexteEF = new TT_BDDEntities();

		//Gestion de l'Index.
		#region Index
		[AllowAnonymous]
		public ActionResult Index()
		{
			
			var sqlTicket = ( from s in contexteEF.Ticket_Attente
							  where s.Validation == 1
							  orderby s.Id descending
							  select new Models.Model_Ticket_Attente
							  {
								  Id = s.Id,
								  Nom = s.Nom,
								  Prenom = s.Prenom,
								  Sujet = s.Sujet,
								  Message = s.Message,
								  DateDebut = s.DateDebut,
								  Suivie = s.Suivie,
								  Commentaire = s.Commentaire,
								  DateFinTicket = s.DateFinTicket
							  } ).Take(5).ToList();
			ViewBag.Ticket = sqlTicket;

			//Affiche le nombre de ticket en attente de validation.
			var sqlTicketPresent = ( from s in contexteEF.Ticket_Attente
									 where s.Validation != 1
									 select new Models.Model_Ticket_Attente
									 {
										 Id = s.Id,
									 } );
			int ticketPresent = 0;
			foreach ( var item in sqlTicketPresent )
			{
				ticketPresent += 1;
			}
			//Envoie de la présence ou non de ticket en attente.
			ViewBag.ticketPresent = ticketPresent;

			Session["ticketPresent"] = ticketPresent;
			return View();
		}
		
		//Enregistrement d'une nouvelle demande.
		[HttpPost]
		[AllowAnonymous]
		[ValidateInput(false)]
		public ActionResult Index(Models.Model_Ticket_Attente models)
		{
			if ( ModelState.IsValid )
			{
				models.DateDebut = DateTime.Now;
				models.DateFinTicket = DateTime.Now;
				var ticketAttente = AutoMapper.Mapper.Map<Ticket_Attente>(models);
				contexteEF.Ticket_Attente.Add(ticketAttente);
				contexteEF.SaveChanges();
				return RedirectToAction("Index", "Home", new { confirm = "ok" });
			}

			var sqlTicket = ( from s in contexteEF.Ticket_Attente
							  where s.Validation == 1
							  orderby s.Id descending
							  select new Models.Model_Ticket_Attente
							  {
								  Id = s.Id,
								  Nom = s.Nom,
								  Prenom = s.Prenom,
								  Sujet = s.Sujet,
								  Message = s.Message,
								  DateDebut = s.DateDebut,
								  Suivie = s.Suivie,
								  Commentaire = s.Commentaire
							  } ).Take(5).ToList();
			ViewBag.Ticket = sqlTicket;

			return View();
		}

		#endregion

		
		//Récupére dans la BDD la liste des tickets en attente via LINQ.
		#region Ticket_Attente
		[AllowAnonymous]
		public ActionResult Ticket_Attente(Models.Model_Ticket_Attente models)
		{
			var sqlTicket = ( from s in contexteEF.Ticket_Attente
							  where s.Validation != 1
							  select new Models.Model_Ticket_Attente
							  {
								  Id = s.Id,
								  Nom = s.Nom,
								  Prenom = s.Prenom,
								  Sujet = s.Sujet,
								  Message = s.Message,
								  DateDebut = s.DateDebut,
								  Suivie = s.Suivie
							  }).ToList();

			//Affiche le nombre de ticket en attente de validation.
			var sqlTicketPresent = ( from s in contexteEF.Ticket_Attente
									 where s.Validation != 1
									 select new Models.Model_Ticket_Attente
									 {
										 Id = s.Id,
									 } );
			int ticketPresent = 0;
			foreach ( var item in sqlTicketPresent )
			{
				ticketPresent += 1;
			}
			//Envoie de la présence ou non de ticket en attente.
			ViewBag.ticketPresent = ticketPresent;

			Session["ticketPresent"] = ticketPresent;

			return View(sqlTicket);
		}

		[AllowAnonymous]
		public ActionResult Modal_Suivie(int id)
		{
			Ticket_Attente editTicket = contexteEF.Ticket_Attente.Single(p => p.Id == id);
			Models.Model_Ticket_Attente editTick = AutoMapper.Mapper.Map<Models.Model_Ticket_Attente>(editTicket);
			return View(editTick);
		}



		//Appel de la vue pour rentrer un suivie.
		[HttpPost]
		[AllowAnonymous]
		[ValidateInput(false)]
		public ActionResult Modal_Suivie(Models.Model_Ticket_Suivie models)
		{
			Ticket_Attente ticketAttente = contexteEF.Ticket_Attente.Single(p => p.Id == models.Id);
			ticketAttente = AutoMapper.Mapper.Map<Models.Model_Ticket_Suivie, Ticket_Attente>(models, ticketAttente);
			contexteEF.SaveChanges();

			//Redirige avec réecriture URL d'une confirmation lue via RequestParameter
			return RedirectToAction("Ticket_Attente", "Home", new { confirmSuivie = "ok" });
		}

		[AllowAnonymous]
		public ActionResult Modal_Validation(int id)
		{
			Ticket_Attente editTicket = contexteEF.Ticket_Attente.Single(p => p.Id == id);
			Models.Model_Ticket_Attente editTick = AutoMapper.Mapper.Map<Models.Model_Ticket_Attente>(editTicket);
			return View(editTick);
		}

		
		//Validation du ticket, avec la demande du commentaire et de la date de clôture du ticket.
		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Modal_Validation(Models.Model_Ticket_Validation models)
		{
			models.Validation = 1;
			Ticket_Attente ticketAttente = contexteEF.Ticket_Attente.Single(p => p.Id == models.Id);
			ticketAttente = AutoMapper.Mapper.Map<Models.Model_Ticket_Validation, Ticket_Attente>(models, ticketAttente);
			contexteEF.SaveChanges();
			return RedirectToAction("Ticket_Attente", "Home", new { configValid = "ok" });

		}
		#endregion

		#region Ticket_Historique

		//liste des ticket validé. Liste tous les tickets avec la validation à 1. A voir avec le tps si cela ne fait pas ralentir la BDD.
		public ActionResult Ticket_Historique()
		{
			var sqlTicket = ( from s in contexteEF.Ticket_Attente
							  where s.Validation == 1
							  select new Models.Model_Ticket_Historique
							  {
								  Id = s.Id,
								  Nom = s.Nom,
								  Prenom = s.Prenom,
								  Sujet = s.Sujet,
								  Message = s.Message,
								  DateDebut = s.DateDebut,
								  Suivie = s.Suivie,
								  Commentaire = s.Commentaire,
								  DateFinTicket = s.DateFinTicket
							  } ).ToList();

			return View(sqlTicket);
		}

		#endregion


		#region Nouvelle_Utilisateur

		//Récupération de la liste des utilisateurs.
		public ActionResult Utilisateur()
		{
			List<string> utilisateur = new List<string>
			{
				"Technique",
				"Impression",
				"Direction"
			};
			ViewBag.user = new SelectList(utilisateur);


			List<DAL.Users> item = contexteEF.Users.ToList();
			ViewBag.Liste = new SelectList(item, "Login", "DroitUtilisateur");
			return View();
		}

		[HttpPost]
		public ActionResult Utilisateur(Models.UtilisteurViewModel model)
		{
			var user = AutoMapper.Mapper.Map<Users>(model);
			contexteEF.Users.Add(user);
			contexteEF.SaveChanges();

			return RedirectToAction("Utilisateur", "Home", new { confirmUtilisateur = "ok" });
		}
		#endregion
		[AllowAnonymous]
		public ActionResult About()
		{
			return View();
		}


		//Affichage de la page Statistique
		public ActionResult Statistique()
		{
			var sql = ( from s in contexteEF.Ticket_Attente
							  where s.Validation == 1
							  orderby s.Id descending
							  select new Models.StatistiqueViewModel
							  {
								  Id = s.Id,
							  } ).Take(1).ToList();
			ViewBag.Id = sql;
			return View();
		}
	}
}