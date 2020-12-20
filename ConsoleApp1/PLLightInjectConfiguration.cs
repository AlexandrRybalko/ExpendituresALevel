using BL;
using BL.Services;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class LightInjectConfiguration
    {
        public static void Congigurate()
        {
            var container = new ServiceContainer();
            //container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            //var config = new MapperConfiguration(cfg => cfg.AddProfiles(
            //      new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            /*            container.Register(c => config.CreateMapper())*/
            ;

            container = BLLightInjectConfiguration.Configuration(container);

            container.Register<ITransactionService, TransactionService>();
            container.Register<ICategoryService, CategoryService>();
            //container.Register<IEmailService, EmailService>();
            //container.Register<IArticleApiService, ArticleApiService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();
        }
    }
}
