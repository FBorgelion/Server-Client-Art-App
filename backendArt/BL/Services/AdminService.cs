using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain;

namespace BL.Services
{
    public class AdminService : IAdminService
    {

        private readonly IMapper _mapper;
        private readonly IAdminRepo _adminRepo;

        public AdminService(IMapper mapper, IAdminRepo adminRepo) 
        {
            _mapper = mapper;
            _adminRepo = adminRepo;
        }

        public void Add(AdminDTO admin)
        {
            var adminEntity = _mapper.Map<Admin>(admin);
            _adminRepo.Add(adminEntity);
        }

    }
}
