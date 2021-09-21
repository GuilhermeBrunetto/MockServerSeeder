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
    [Route("api/[controller]")]
    public class AcordosController : ControllerBase
    {
        private readonly IAcordoRepository _acordoRepository;
        private readonly IMapper _mapper;
        public AcordosController(IAcordoRepository acordoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _acordoRepository = acordoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAcordos([FromQuery] int produtoId)
        {
            IEnumerable<Acordo> acordos = null;
            // se n especificar só retorna a lista full
            if (produtoId <= 0) 
            {
                acordos = await _acordoRepository.GetAllAsync();
                return Ok(_mapper.Map<List<AcordoDto>>(acordos));
            }
            else
            {
                // se especificar um graoId dá pra chamar a funcao de pegar acordos by grao
                var acordosByGrao = await _acordoRepository.GetAcordosByProdutoAsync(produtoId);
                return Ok(_mapper.Map<List<AcordoDto>>(acordosByGrao));
            }


        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Acordo>> GetAcordoById(int id)
        {
            var acordo = await _acordoRepository.GetByIdAsync(id);
            if (acordo == null)
                return NotFound("Couldn't find the specified acordo(deal), maybe it doesn't exist");

            return Ok(_mapper.Map<AcordoDto>(acordo));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAcordo([FromBody] AcordoDto acordoDto)
        {
            if (ModelState.IsValid)
            {
                var acordo = _mapper.Map<Acordo>(acordoDto);

                var addResult = await _acordoRepository.CreateAsync(acordo);
                if (addResult == null)
                    return BadRequest("Acordo wasn't added, try again");

                return Created($"http://localhost:5000/api/acordos/{acordo.Id}", acordo);
            }
            return BadRequest("Provided model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAcordo([FromBody] AcordoDto updatedAcordoDto, int id)
        {
            if (ModelState.IsValid)
            {
                var acordo = _mapper.Map<Acordo>(updatedAcordoDto);
                acordo.Id = id;
                var updateResult = await _acordoRepository.UpdateAsync(acordo);

                if (updateResult)
                    return Ok("Acordo updated successfully");

                return BadRequest("Couldn't update Acordo, please try again");
            }

            return BadRequest("Provided model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTerritorio(int id)
        {
            var deleteResult = await _acordoRepository.DeleteAsync(id);

            if (deleteResult)
                return Ok("Acordo deleted succesfully");

            return BadRequest("Couldn't delete the acordo");
        }

    }
}