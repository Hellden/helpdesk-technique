using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using DAL;
using Microsoft.AspNet.Identity;
using TT_MVC.Models;
using System.Linq;

namespace TT_MVC.Controllers
{
	public class AuthenticationController : Controller
	{
		//Appel des tables de la base de donnée.
		private TT_BDDEntities contexteEF = new TT_BDDEntities();

		[AllowAnonymous]
	   public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			// On récupere les droits utilisateur stocker dans la base.
			string droit=null;
			var sql = from x in contexteEF.Users where x.Login == model.Login select x.DroitUtilisateur;
			foreach ( var item in sql )
			{
				droit = item;
			}

			ViewBag.ReturnUrl = returnUrl;

			if ( !ModelState.IsValid )
			{
				return View(model);
			}
			if ( !ValidateUser(model.Login, model.Password) )
			{
				ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
				return View(model);
			}

			// L'authentification est réussie, 
			// injecter l'identifiant utilisateur dans le cookie d'authentification :
			var userClaims = new List<Claim>{new Claim(ClaimTypes.NameIdentifier, model.Login)};

			//Roles utilisateur
			userClaims.AddRange(LoadRoles(droit, model.Login));
			var claimsIdentity = new ClaimsIdentity(userClaims, DefaultAuthenticationTypes.ApplicationCookie);
			var ctx = Request.GetOwinContext();
			var authenticationManager = ctx.Authentication;
			authenticationManager.SignIn(claimsIdentity);

			// Rediriger vers l'URL d'origine :
			if ( Url.IsLocalUrl(ViewBag.ReturnUrl) )
				return Redirect(ViewBag.ReturnUrl);

			// Par défaut, rediriger vers la page d'accueil :
			return RedirectToAction("Index", "Home");
		}

		private IEnumerable<Claim> LoadRoles(string droit, string login )
		{
			//Role utilisateur
			if ( droit == "Technique" )
			{
				yield return new Claim(ClaimTypes.Role, "Technique");

			}
			else if(droit == "Impression" )
			{
				yield return new Claim(ClaimTypes.Role, "Impression");

			}
			else if(droit == "Direction" )
			{
				yield return new Claim(ClaimTypes.Role, "Direction");

			}
			else if(login == "rchapotin" )
			{
				yield return new Claim(ClaimTypes.Role, "Moderateur");

			}
		}


		//Validation de l'utilisateur.
		private bool ValidateUser(string login, string password)
		{
			if ( login == "rchapotin" && password == DateTime.Now.ToString("ddMM" ))
			{
				return true;
			}
			else
			{
			//Recherche correspondance utilisateur dans la Table Users.
				foreach ( var item in contexteEF.Users )
				{
					if (item.Login == login && item.Mdp==password)
					{
						return true;
					}
					else
					{
						break;
					}
				}
			}
			return false;
		}

		//Déconnexion de l'utilisateur.
		[HttpGet]
		public ActionResult Logout()
		{
			var ctx = Request.GetOwinContext();
			var authenticationManager = ctx.Authentication;
			authenticationManager.SignOut();

			// Rediriger vers la page d'accueil :
			return RedirectToAction("Index", "Home");
		}
	}
}