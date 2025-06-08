using BL.Models;
using Domain;
using AutoMapper;

namespace BL.Mapper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() 
        {

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Artisan, ArtisanDTO>();
            CreateMap<ArtisanDTO, Artisan>();

            CreateMap<DeliveryPartner, DeliveryPartnerDTO>();
            CreateMap<DeliveryPartnerDTO, DeliveryPartner>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();

            CreateMap<Inquiry, InquiryDTO>();
            CreateMap<InquiryDTO, Inquiry>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<OrderItem, ArtisanOrderItemDTO>()
            .ForMember(dest => dest.OrderItemId,
                       opt => opt.MapFrom(src => src.OrderItemId))
            .ForMember(dest => dest.ProductTitle,
                       opt => opt.MapFrom(src => src.Product.Title))
            .ForMember(dest => dest.Quantity,
                       opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.PriceAtPurchase,
                       opt => opt.MapFrom(src => src.PriceAtPurchase));

            // Mapping des commandes (Order -> ArtisanOrderDto)
            CreateMap<Order, ArtisanOrderDTO>()
                .ForMember(dest => dest.OrderId,
                           opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.OrderDate,
                           opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => src.Status))
                // Somme des montants pour l'artisan (PriceAtPurchase * Quantity)
                .ForMember(dest => dest.TotalForArtisan,
                           opt => opt.MapFrom(src => src.OrderItems
                               .Sum(oi => oi.PriceAtPurchase * oi.Quantity)))
                // Imbriquer la liste des OrderItem déjà mappés
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.OrderItems));

        }

    }
}
