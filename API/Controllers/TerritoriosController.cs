using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TerritoriosController : ControllerBase
    {
        private readonly ITerritorioRepository _territoriosRepository;
        private readonly IMapper _mapper;
        public TerritoriosController(ITerritorioRepository territoriosRepository, IMapper mapper)
        {
            _mapper = mapper;
            _territoriosRepository = territoriosRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTerritorios()
        {
            var territorios = await _territoriosRepository.GetAllAsync();
            return Ok(_mapper.Map<List<TerritorioDto>>(territorios));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Territorio>> GetTerritorioById(int id)
        {
            var territorio = await _territoriosRepository.GetByIdAsync(id);

            if (territorio == null)
                return NotFound("Couldn't find the specified territory, maybe it doesn't exist");

            return Ok(_mapper.Map<TerritorioDto>(territorio));

        }

        [HttpPost]
        public async Task<ActionResult> CreateTerritorio([FromBody] TerritorioDto territorioDto)
        {
            if (ModelState.IsValid)
            {
                var territorio = _mapper.Map<Territorio>(territorioDto);

                var addResult = await _territoriosRepository.CreateAsync(territorio);
                if (addResult == null)
                    return BadRequest("Territorio wasn't added, try again");

                return Created($"http://localhost:5000/api/territorios/{territorio.TerritorioId}", territorio);
            }
            return BadRequest("Provided model is not valid");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateTerritorio([FromBody] TerritorioDto updatedTerritorioDto, int id)
        {
            if (ModelState.IsValid)
            {
                var updatedTerritorio = _mapper.Map<Territorio>(updatedTerritorioDto);
                updatedTerritorio.TerritorioId = id;
                var updateResult = await _territoriosRepository.UpdateAsync(updatedTerritorio);

                if (updateResult)
                    return Ok("Territorio updated successfully");

                return BadRequest("Couldn't update Territorio, please try again");
            }

            return BadRequest("Provided model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTerritorio(int id)
        {
            var deleteResult = await _territoriosRepository.DeleteAsync(id);

            if (deleteResult)
                return Ok("Territorio deleted succesfully");

            return BadRequest("Couldn't delete the territorio");
        }

    }
}