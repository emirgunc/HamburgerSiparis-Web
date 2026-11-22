using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using HamburgerSiparis.EntityLayer;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
    public class KullaniciRepository : Repository<Kullanici>,IKullaniciRepository
    {
        public KullaniciRepository(HamburgerContext context) : base(context)
        {
        }
    }
}