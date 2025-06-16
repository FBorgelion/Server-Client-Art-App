using AutoMapper;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ReviewService : IReviewService
    {

        private readonly IMapper _mapper;
        private readonly IReviewRepo _reviewRepo;

        public ReviewService(IMapper mapper, IReviewRepo reviewRepo)
        {
            _mapper = mapper;
            _reviewRepo = reviewRepo;
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            var reviews = _reviewRepo.GetAll();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public IEnumerable<ReviewDTO> GetReviewsByProduct(int productId)
        {
            var reviews = _reviewRepo.GetReviewByProduct(productId);
            if (reviews == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews); ;
        }

        public IEnumerable<ReviewDTO> GetReviewsByCustomer(int custId)
        {
            var reviews = _reviewRepo.GetReviewsByCustomer(custId);
            if (reviews == null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews); ;
        }

        public void Add(int custId, int productId, int rating , string comment)
        {
            Review review = new Review
            {
                CustomerId = custId,
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                CreatedDate = DateTime.Now
            };
            _reviewRepo.Add(review);
        }

        public bool Delete(int id)
        {
            return _reviewRepo.Delete(id);
        }

    }
}
