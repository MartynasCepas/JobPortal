﻿using JobPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.Data.Repositories
{
    public interface IOffersRepository
    {
        Task<IEnumerable<Offer>> GetAll();
        Task<Offer> Get(int id);
        Task<Offer> Create(Offer offer);
        Task<Offer> Put(Offer offer);
        Task Delete(Offer offer);
    }

    public class OffersRepository : IOffersRepository
    {
        public async Task<IEnumerable<Offer>> GetAll()
        {
            return new List<Offer>
            {
                new Offer()
                {
                    Name = "name",
                    Description = "description",
                    CreationTimeUtc = DateTime.UtcNow
                },
                 new Offer()
                {
                    Name = "name",
                    Description = "description",
                    CreationTimeUtc = DateTime.UtcNow
                }
            };
        }

        public async Task<Offer> Get(int id)
        {
            return new Offer()
            {
                Name = "name",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Offer> Create(Offer offer)
        {
            return new Offer()
            {
                Name = "name",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Offer> Put(Offer offer)
        {
            return new Offer()
            {
                Name = "name",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task Delete(Offer offer)
        {
            
        }
    }
}