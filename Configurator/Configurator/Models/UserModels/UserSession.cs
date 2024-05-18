using Configurator.Models.PCBuider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.UserModels
{
    class UserSession
    {
        private static UserSession _instance;
        public User? CurrentUser { get; set; }
        public PCBuilder PcBuilder { get; set; }
        private UserSession()
        {
        }

        public static UserSession GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UserSession();
                _instance.PcBuilder = new PCBuilder();
            }
            return _instance;
        }
    }
}
