using System.Web;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Web.Helpers
{
    public class UserService : IUserService
    {
        private readonly HttpContextBase _context;

        public UserService(HttpContextBase context)
        {
            _context = context;
        }

        public string UserId
        {
            get
            {
                return _context.Request.ServerVariables["HTTP_CT_REMOTE_USER"] ?? "AOSYS";
            }
        }
    }
}