using JobPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data.Repositories
{
    public interface IOffersRepository
    {
        Task<IEnumerable<Offer>> GetAllAsync();
        Task<Offer> GetByIdAsync(int id);
        Task InsertAsync(Offer offer);
        Task UpdateAsync(Offer offer);
        Task DeleteAsync(Offer offer);
    }

    public class OffersRepository : IOffersRepository
    {
        private readonly RestContext _restContext;

        public OffersRepository(RestContext restContext)
        {
            _restContext = restContext;
        }


        public async Task<Offer> GetByIdAsync(int id)
        {
            return await _restContext.Offers.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task InsertAsync(Offer offer)
        {
            _restContext.Offers.Add(offer);
            await _restContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Offer offer)
        {
            _restContext.Offers.Update(offer);
            await _restContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Offer offer)
        {
            _restContext.Offers.Remove(offer);
            await _restContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Offer>> GetAllAsync()
        {
            return await _restContext.Offers.ToListAsync();
        }
    }
}
