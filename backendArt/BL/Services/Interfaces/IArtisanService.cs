using BL.Models;

namespace BL.Services.Interfaces
{
    public interface IArtisanService
    {

        public IEnumerable<ArtisanDTO> GetAll();

        public ArtisanDTO Get(int id);

        public void Add(ArtisanDTO artisan);

        public bool Update(ArtisanDTO artisan);

        public bool Delete(int id);
    }


}
