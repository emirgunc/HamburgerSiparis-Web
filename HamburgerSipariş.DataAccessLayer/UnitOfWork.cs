using HamburgerSiparis.DataAccessLayer.Repositories;
using HamburgerSiparis.EntityLayer;
using System;
namespace HamburgerSiparis.DataAccessLayer.Context
{
   
    public class UnitOfWork : IDisposable
    {
      
        private HamburgerContext context = new HamburgerContext();

        
        private Repository<Kategori> _kategoriRepository;
       
        public Repository<Kategori> KategoriRepository
        {
            get
            {
                if (_kategoriRepository == null)
                    _kategoriRepository = new Repository<Kategori>(context);
                return _kategoriRepository;
            }
        }

        private Repository<Urun> _urunRepository;
        public Repository<Urun> UrunRepository
        {
            get
            {
                if (_urunRepository == null)
                    _urunRepository = new Repository<Urun>(context);
                return _urunRepository;
            }
        }

        private Repository<Kullanici> _kullaniciRepository;
        public Repository<Kullanici> KullaniciRepository
        {
            get
            {
                if (_kullaniciRepository == null)
                    _kullaniciRepository = new Repository<Kullanici>(context);
                return _kullaniciRepository;
            }
        }

        
        private Repository<Siparis> _siparisRepository;
        public Repository<Siparis> SiparisRepository
        {
            get
            {
                if (_siparisRepository == null)
                {
                    _siparisRepository = new Repository<Siparis>(context);
                }
                return _siparisRepository;
            }
        }
       
        private Repository<Hakkimizda> _hakkimizdaRepository;
        public Repository<Hakkimizda> HakkimizdaRepository
        {
            get
            {
                if (_hakkimizdaRepository == null)
                {
                    _hakkimizdaRepository = new Repository<Hakkimizda>(context);
                }
                return _hakkimizdaRepository;
            }
        }

     
        private Repository<Iletisim> _iletisimRepository;
        public Repository<Iletisim> IletisimRepository
        {
            get
            {
                if (_iletisimRepository == null)
                {
                    _iletisimRepository = new Repository<Iletisim>(context);
                }
                return _iletisimRepository;
            }
        }
       
        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}