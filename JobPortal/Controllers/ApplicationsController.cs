using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobPortal.Data.Dtos.Applications;
using JobPortal.Data.Dtos.Topics;
using JobPortal.Data.Entities;
using JobPortal.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationsRepository _applicationsRepository;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationsRepository applicationsRepository, IMapper mapper)
        {
            _applicationsRepository = applicationsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationDto>> GetAll()
        {
            return (await _applicationsRepository.GetAllAsync()).Select(o => _mapper.Map<ApplicationDto>(o));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDto>> Get(int id)
        {
            var application = await _applicationsRepository.GetByIdAsync(id);
            if (application == null) return NotFound($"Application with id '{id}' not found");

            return Ok(_mapper.Map<ApplicationDto>(application));
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> Post(CreateApplicationDto applicationDto)
        {
            var application = _mapper.Map<Application>(applicationDto);

            await _applicationsRepository.InsertAsync(application);

            // 201
            // Created offer
            return Created($"/api/applications/{application.Id}", _mapper.Map<Application>(application));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApplicationDto>> Put(int id, UpdateApplicationDto applicationDto)
        {
            var application = await _applicationsRepository.GetByIdAsync(id);
            if (application == null) return NotFound($"Application with id '{id}' not found");

            _mapper.Map(applicationDto, application);

            await _applicationsRepository.UpdateAsync(application);

            return Created($"/api/applications/{application.Id}", _mapper.Map<Application>(application));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApplicationDto>> Delete(int id)
        {
            var application = await _applicationsRepository.GetByIdAsync(id);
            if (application == null) return NotFound($"Application with id '{id}' not found");

            await _applicationsRepository.DeleteAsync(application);

            // 204
            return NoContent();
        }
    }
}
