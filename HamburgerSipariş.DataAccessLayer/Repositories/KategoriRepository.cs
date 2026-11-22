using HamburgerSiparis.DataAccessLayer.Context;
using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using HamburgerSiparis.EntityLayer;

namespace HamburgerSiparis.DataAccessLayer.Repositories

{
    public class KategoriRepository : Repository<Kategori>,IKategoriRepository
    {
        public KategoriRepository(HamburgerContext context) : base(context)
        {
        }
    }
}