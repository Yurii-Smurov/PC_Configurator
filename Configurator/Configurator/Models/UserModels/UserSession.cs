using Configurator.Models.PCBuider;
namespace Configurator.Models.UserModels
{
    class UserSession
    {
        private static UserSession? _instance;
        public User CurrentUser { get; set; }
        public PCBuilder PcBuilder { get; set; }
        private UserSession()
        {
            PcBuilder = new PCBuilder();
            CurrentUser = new User();
        }

        public static UserSession GetInstance()
        {
            if(_instance == null)
            {
                _instance = new UserSession();
            }
            return _instance;
        }
    }
}
