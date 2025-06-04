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

        }

    }
}
