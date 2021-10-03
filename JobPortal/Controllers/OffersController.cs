using JobPortal.Data.Entities;
using JobPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using JobPortal.Data.Dtos.Topics;
using AutoMapper;

namespace JobPortal.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OffersController : ControllerBase
    {
        private readonly IOffersRepository _offerssRepository;
        private readonly IMapper _mapper;

        public OffersController(IOffersRepository offersRepository, IMapper mapper)
        {
            _offerssRepository = offersRepository;
            _mapper = mapper;
        }

        [HttpGet]
       public async Task<IEnumerable<OfferDto>> GetAll()
        {
            return (await _offerssRepository.GetAll()).Select(o => _mapper.Map<OfferDto>(o)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> Get(int id)
        {
            var offer = await _offerssRepository.Get(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            return Ok(_mapper.Map<OfferDto>(offer));
        }

        [HttpPost]
        public async Task<ActionResult<OfferDto>> Post(CreateOfferDto offerDto)
        {
            var offer = _mapper.Map<Offer>(offerDto);

            await _offerssRepository.Create(offer);

            // 201
            // Created offer
            return Created($"/api/offers/{offer.Id}", _mapper.Map<Offer>(offer));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OfferDto>> Put(int id, UpdateOfferDto offerDto)
        {
            var offer = await _offerssRepository.Get(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            _mapper.Map(offerDto, offer);

            await _offerssRepository.Put(offer);

            return Created($"/api/offers/{offer.Id}", _mapper.Map<Offer>(offer));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OfferDto>> Delete(int id)
        {
            var offer = await _offerssRepository.Get(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            await _offerssRepository.Delete(offer);

            // 204
            return NoContent();
        }
    }
}
