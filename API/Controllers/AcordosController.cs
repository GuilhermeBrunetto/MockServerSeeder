using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcordosController : ControllerBase
    {
        private readonly IAcordoRepository _acordoRepository;
        public AcordosController(IAcordoRepository acordoRepository)
        {
            _acordoRepository = acordoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAcordos()
        {
            List<AcordoDto> acordosDto = new List<AcordoDto>();
            var acordos = await _acordoRepository.GetAllAsync();
        
            foreach(var acordo in acordos)
            {
                var dto = new AcordoDto();
                dto.Id = acordo.Id;
                dto.Contrato = acordo.Contrato;
                dto.Moeda = acordo.Moeda;
                dto.Variacao = acordo.Variacao;
                dto.GraoId = acordo.GraoId;
                acordosDto.Add(dto);
            }

            return Ok(acordosDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Acordo>> GetAcordoById(int id)
        {
            var acordo = await _acordoRepository.GetByIdAsync(id);

            if(acordo == null)
                return NotFound("Couldn't find the specified acordo(deal), maybe it doesn't exist");

            var acordoDto = new AcordoDto();
            acordoDto.Id = acordo.Id;
            acordoDto.Contrato = acordo.Contrato;
            acordoDto.Moeda = acordo.Moeda;
            acordoDto.Variacao = acordo.Variacao;
            acordoDto.GraoId = acordo.GraoId;

            return Ok(acordoDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAcordo([FromBody] AcordoDto acordoDto)
        {
            if(ModelState.IsValid)
            {
                var acordo = new Acordo();
                acordo.Contrato = acordoDto.Contrato;
                acordo.Moeda = acordoDto.Moeda;
                acordo.Variacao = acordoDto.Variacao;
                acordo.GraoId = acordoDto.GraoId;

                var addResult = await _acordoRepository.CreateAsync(acordo);
                if(addResult == null)
                    return BadRequest("Acordo wasn't added, try again");

                return Created("http://localhost:5000/api/acordos/{acordo.Id}", acordo);
            }
            return BadRequest("Provided model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAcordo([FromBody] AcordoDto updatedAcordoDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updatedAcordo = new Acordo();
                updatedAcordo.Id = id;
                updatedAcordo.Contrato = updatedAcordoDto.Contrato;
                updatedAcordo.Moeda = updatedAcordoDto.Moeda;
                updatedAcordo.Variacao = updatedAcordoDto.Variacao;
                updatedAcordo.GraoId = updatedAcordoDto.GraoId;

                var updateResult = await _acordoRepository.UpdateAsync(updatedAcordo);

                if(updateResult)
                    return Ok("Acordo updated successfully");
            
                return BadRequest("Couldn't update Territorio, please try again");
            }

            return BadRequest("Provided model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTerritorio(int id)
        {
            var deleteResult = await _acordoRepository.DeleteAsync(id);

            if(deleteResult)
                return Ok("Acordo deleted succesfully");

            return BadRequest("Couldn't delete the territorio");
        }

    }
}