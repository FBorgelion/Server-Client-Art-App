﻿using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArtisanRepo : IArtisanRepo
    {

        private readonly AppDbContext _dbContext;

        public ArtisanRepo(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Artisan artisan)
        {
            _dbContext.Artisans.Add(artisan);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var artisan = _dbContext.Artisans.FirstOrDefault(p => p.ArtisanId == id);
            if (artisan == null)
            {
                return false;
            }
            _dbContext.Artisans.Remove(artisan);
            _dbContext.SaveChanges();
            return true;
        }

        public Artisan Get(int id)
        {
            var artisan = _dbContext.Artisans.FirstOrDefault(p => p.ArtisanId == id);
            return artisan;
        }

        public IEnumerable<Artisan> GetAll()
        {
            return _dbContext.Artisans.ToList();
        }

        public bool Update(Artisan artisan)
        {
            var artisanToUpd = _dbContext.Artisans.FirstOrDefault();
            if (artisanToUpd == null)
            {
                return false;
            }
            artisanToUpd.ProfileDescription = artisan.ProfileDescription;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
