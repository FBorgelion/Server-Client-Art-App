using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IArtisanRepo
    {

        public IEnumerable<Artisan> GetAll();

        public Artisan Get(int id);

        public void Add(Artisan artisan);

        public bool Update(Artisan artisan);

        public bool Delete(int id);
    }
}
