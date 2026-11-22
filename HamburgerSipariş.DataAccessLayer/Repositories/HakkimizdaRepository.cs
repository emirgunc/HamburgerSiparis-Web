using HamburgerSiparis.DataAccessLayer.Repositories.Base;
using HamburgerSiparis.EntityLayer;
using HamburgerSiparis.DataAccessLayer.Context;

namespace HamburgerSiparis.DataAccessLayer.Repositories
{
    public class HakkimizdaRepository : Repository<Hakkimizda>
    {
        public HakkimizdaRepository(HamburgerContext context) : base(context)
        {
        }
    }
}