
using FoodManage.GUI;
using FoodManage.GUI.Forms;
using FoodManage.GUI.Forms.Users;
using FoodManage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FoodManage
{
    static class Program
    {

        private static Container container;
      /// <summary>
      ///  The main entry point for the application.
      /// </summary>
      [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
            //Application.EnableVisualStyles();

            //Application.SetCompatibleTextRenderingDefault(false);
            //Boostrap();
            //Application.Run(container.GetInstance<frmLogin>());


        }
        private static void Boostrap()
        {
            container = new Container();
            container.Register<MyDBContext>(() => new MyDBContext());
           // container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Transient);
          
            
           // container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
            //container.Register<IMemberService, MemberService>();
            //container.Register<NotificationEntities>(Lifestyle.Scoped);
            //Register your form
            container.Register<frmLogin>(Lifestyle.Transient);
            container.Register<frmCreateUser>(Lifestyle.Transient);
            

            // Optionally verify the container.
            container.Verify();
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
       
    }
}