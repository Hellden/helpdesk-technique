using AutoMapper;
using DAL;
namespace TT_MVC.App_Start
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Models.Model_Ticket_Attente, Ticket_Attente>();
				cfg.CreateMap<Ticket_Attente, Models.Model_Ticket_Attente>();
				cfg.CreateMap<Models.Model_Ticket_Suivie, Ticket_Attente>();
				cfg.CreateMap<Models.Model_Ticket_Validation, Ticket_Attente>();
				cfg.CreateMap<Models.UtilisteurViewModel, Users>();
			});
		}
	}
}