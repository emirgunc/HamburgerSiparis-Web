using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.DataAccessLayer.Context;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
    public class IletisimRepository : Repository<Iletisim>
    {
        public IletisimRepository(HamburgerContext context) : base(context)
        {
        }
    }
}