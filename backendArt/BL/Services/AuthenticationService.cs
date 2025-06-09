using AutoMapper;
using BL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BL.Services
{
    public class AuthenticationService
    {

        private readonly AuthenticationRepo _authRepo;
        private readonly IArtisanRepo _artisanRepo;
        private readonly IAdminRepo _adminRepo;
        private readonly IDeliveryPartnerRepo _deliveryPartnerRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthenticationService(AuthenticationRepo authRepo, IMapper mapper, IArtisanRepo artisanRepo, IDeliveryPartnerRepo deliveryPartnerRepo, ICustomerRepo customerRepo, IConfiguration config, IAdminRepo adminRepo)
        {
            _authRepo = authRepo;
            _artisanRepo = artisanRepo;
            _customerRepo = customerRepo;
            _deliveryPartnerRepo = deliveryPartnerRepo;
            _mapper = mapper;
            _config = config;
            _adminRepo = adminRepo;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _authRepo.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public void Register(string password, string username, string email, string role)
        {
            var user = _authRepo.GetByUsername(username);
            if (user != null && (user.Username.ToLower() == username.ToLower()))
            {
                throw new Exception("User already exist");
            }
            var salt = DateTime.Now.ToString("dddd");
            var passwordHash = HashPassword(password, salt);
            UserDTO userDTO = new UserDTO();
            userDTO.Username = username;
            userDTO.PasswordHash = passwordHash;
            userDTO.Email = email;
            userDTO.Role = role;

            var userEntity = _mapper.Map<User>(userDTO);
            _authRepo.Add(userEntity, salt);

            AddUserToRoleSpecificTable(role, userEntity);
        }

        private string HashPassword(string password, string salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                        password: Encoding.UTF8.GetBytes(password),
                        salt: Encoding.UTF8.GetBytes(salt),
                        iterations: 10,
                        hashAlgorithm: HashAlgorithmName.SHA512,
                        outputLength: 10);
            return Convert.ToHexString(hash);
        }

        private void AddUserToRoleSpecificTable(string role, User user)
        {
            switch (role.ToLower())
            {
                case "admin":
                    var admin = new Admin { AdminId = user.UserId };
                    _adminRepo.Add(admin);
                    break;

                case "artisan":
                    var artisan = new Artisan { ArtisanId = user.UserId };

                    _artisanRepo.Add(artisan);
                    break;

                case "customer":
                    var customer = new Customer { CustomerId = user.UserId };
                    _customerRepo.Add(customer);
                    break;

                case "deliverypartner":
                    var partner = new DeliveryPartner { DeliveryPartnerId = user.UserId };
                    _deliveryPartnerRepo.Add(partner);
                    break;

                default:
                    throw new Exception("Invalid role");
            }
        }

        public string Login(string username, string password)
        {
            var user = _authRepo.GetByUsername(username);
            if(user == null)
            {
                throw new Exception("Login failed. Invalid user or password.");
            }
            var passwordHash = HashPassword(password, user.Salt);
            if(passwordHash == user.PasswordHash)
            {
                var token = GenerateToken(username);
                return token;
            }
            throw new Exception("Login failed. Invalid user or password.");
        }

        public string GenerateToken(string username)
        {
            var secretKey = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var user = _authRepo.GetByUsername(username);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim("custom_info", "info"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("userId", user.UserId.ToString())
            };

            var jwtIssuer = _config["Jwt:Issuer"];
            var jwtAudience = _config["Jwt:Audience"];

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
