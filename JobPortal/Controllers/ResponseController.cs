using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobPortal.Data.Dtos.Responses;
using JobPortal.Data.Entities;
using JobPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ResponseController : ControllerBase
    {
        private readonly IResponsesRepository _responsesRepository;
        private readonly IMapper _mapper;

        public ResponseController(IResponsesRepository responsesRepository, IMapper mapper)
        {
            _responsesRepository = responsesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ResponseDto>> GetAll()
        {
            return (await _responsesRepository.GetAll()).Select(o => _mapper.Map<ResponseDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> Get(int id)
        {
            var topic = await _responsesRepository.Get(id);
            if (topic == null) return NotFound($"Response with id '{id}' not found");

            return Ok(_mapper.Map<ResponseDto>(topic));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> Post(CreateResposeDto responseDto)
        {
            var response = _mapper.Map<Response>(responseDto);

            await _responsesRepository.Create(response);

            // 201
            // Created offer
            return Created($"/api/responses/{response.Id}", _mapper.Map<Offer>(response));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto>> Put(int id, UpdateResponseDto responseDto)
        {
            var response = await _responsesRepository.Get(id);
            if (response == null) return NotFound($"Response with id '{id}' not found");

            _mapper.Map(responseDto, response);

            await _responsesRepository.Put(response);

            return Created($"/api/responses/{response.Id}", _mapper.Map<Response>(response));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> Delete(int id)
        {
            var response = await _responsesRepository.Get(id);
            if (response == null) return NotFound($"Responses with id '{id}' not found");

            await _responsesRepository.Delete(response);

            // 204
            return NoContent();
        }
    }
}
