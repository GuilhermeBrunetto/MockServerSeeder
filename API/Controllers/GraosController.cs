using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GraosController : Controller
    {
        private readonly IGraoRepository _graoRepository;
        private readonly IMapper _mapper;
        public GraosController(IGraoRepository graoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _graoRepository = graoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetGraos()
        {
            var graos = await _graoRepository.GetAllAsync();
            return Ok(_mapper.Map<List<GraoDto>>(graos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetGraoById(int id)
        {
            var grao = await _graoRepository.GetByIdAsync(id);
            if(grao == null)
                    return NotFound("Couldn't find the specified grao, maybe it doesn't exist");
            
            return Ok(_mapper.Map<GraoDto>(grao));
        }

        [HttpPost]
        public async Task<ActionResult> CreateGrao([FromBody] GraoDto graoDto)
        {
            if (ModelState.IsValid)
            {
                var grao = _mapper.Map<Grao>(graoDto);

                var addResult = await _graoRepository.CreateAsync(grao);
                if (addResult == null)
                    return BadRequest("Grao wasn't added, try again");

                return Created($"http://localhost:5000/api/graos/{grao.Id}", grao);
            }
            return BadRequest("Provided model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateGrao([FromBody] GraoDto updatedGraoDto, int id)
        {
            if (ModelState.IsValid)
            {
                var grao = _mapper.Map<Grao>(updatedGraoDto);
                grao.Id = id;
                var updateResult = await _graoRepository.UpdateAsync(grao);

                if (updateResult)
                    return Ok("Grao updated successfully");

                return BadRequest("Couldn't update Acordo, please try again");
            }

            return BadRequest("Provided model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteGrao(int id)
        {
            var deleteResult = await _graoRepository.DeleteAsync(id);

            if (deleteResult)
                return Ok("Grao deleted succesfully");

            return BadRequest("Couldn't delete the grao");
        }

    }
}