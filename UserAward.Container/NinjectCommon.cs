using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.DAL.DAO;
using UserAward.DAL.Interface;

namespace UserAward.Container
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<IUserDao>().To<UserDao>();
            _kernel.Bind<IUserLogic>().To<UserLogic>();

            _kernel.Bind<IAwardDao>().To<AwardDao>();
            _kernel.Bind<IAwardLogic>().To<AwardLogic>();
        }
    }
}
