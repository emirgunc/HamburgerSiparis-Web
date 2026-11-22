using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.DataAccessLayer.Repositories.Base;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
 
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(HamburgerContext context) : base(context)
        {
        }
    }
}