using System.ComponentModel.DataAnnotations;


namespace TT_MVC.Models
{
	public class UtilisteurViewModel
	{
		[Required]
		[Display(Name = "Identifiant")]
		public string Login { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Mot de passe")]
		public string Mdp { get; set; }

		[Display(Name = "Droit Utilisateur")]
		public string DroitUtilisateur { get; set; }
	}
}