using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using HamburgerSiparis.EntityLayer;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
    public class SiparisRepository : Repository<Siparis>,ISiparisRepository
    {
        public SiparisRepository(HamburgerContext context) : base(context)
        {
        }
    }
}