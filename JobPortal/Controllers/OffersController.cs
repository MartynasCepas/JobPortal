using JobPortal.Data.Entities;
using JobPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using JobPortal.Data.Dtos.Topics;
using AutoMapper;
using JobPortal.Auth.Model;
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/")]
    public class OffersController : ControllerBase
    {
        private readonly IOffersRepository _offerssRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public OffersController(IOffersRepository offersRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _offerssRepository = offersRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
       public async Task<IEnumerable<OfferDto>> GetAll()
        {
            return (await _offerssRepository.GetAllAsync()).Select(o => _mapper.Map<OfferDto>(o)); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> Get(int id)
        {
            var offer = await _offerssRepository.GetByIdAsync(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            return Ok(_mapper.Map<OfferDto>(offer));
        }

        [HttpPost]
        [Authorize(Roles = RestUserRoles.Recruiter)]
        public async Task<ActionResult<OfferDto>> Post(CreateOfferDto offerDto)
        {
            var user = User.FindFirst(CustomClaims.UserId).Value;
            var offer = _mapper.Map<Offer>(offerDto);
            offer.UserId = user;

            await _offerssRepository.InsertAsync(offer);

            // 201
            // Created offer
            return Created($"/api/offers/{offer.Id}", _mapper.Map<Offer>(offer));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RestUserRoles.Recruiter)]
        public async Task<ActionResult<OfferDto>> Put(int id, UpdateOfferDto offerDto)
        {
            var offer = await _offerssRepository.GetByIdAsync(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, offer, PolicyNames.SameUser);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            _mapper.Map(offerDto, offer);

            await _offerssRepository.UpdateAsync(offer);

            return Created($"/api/offers/{offer.Id}", _mapper.Map<Offer>(offer));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RestUserRoles.Recruiter)]
        public async Task<ActionResult<OfferDto>> Delete(int id)
        {
            var offer = await _offerssRepository.GetByIdAsync(id);
            if (offer == null) return NotFound($"Offer with id '{id}' not found");

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, offer, PolicyNames.SameUser);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            await _offerssRepository.DeleteAsync(offer);

            // 204
            return NoContent();
        }
    }
}
