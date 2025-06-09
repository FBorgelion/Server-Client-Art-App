using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class ArtisanService : IArtisanService
    {

        private readonly IMapper _mapper;
        private readonly IArtisanRepo _artisanRepo;

        public ArtisanService(IMapper mapper, IArtisanRepo artisanRepo) 
        {
            _mapper = mapper;
            _artisanRepo = artisanRepo;
        }

        public void Add(ArtisanDTO artisan)
        {
            var artisanEntity = _mapper.Map<Artisan>(artisan);
            _artisanRepo.Add(artisanEntity);
        }

        public bool Delete(int id)
        {
            return _artisanRepo.Delete(id);
        }

        public IEnumerable<ArtisanDTO> GetAll()
        {
            var artisans = _artisanRepo.GetAll();
            return _mapper.Map<IEnumerable<ArtisanDTO>>(artisans);
        }

        public ArtisanDTO Get(int id)
        {
            var artisan = _artisanRepo.Get(id);
            if (artisan == null)
            {
                return null;
            }
            return _mapper.Map<ArtisanDTO>(artisan);
        }

        public bool Update(ArtisanDTO artisan)
        {
            var artisanEntity = _mapper.Map<Artisan>(artisan);
            return _artisanRepo.Update(artisanEntity);
        }

        public bool UpdateDescription(int artisanId, string description)
        {
            return _artisanRepo.UpdateDescription(artisanId, description);
        }

    }
}
