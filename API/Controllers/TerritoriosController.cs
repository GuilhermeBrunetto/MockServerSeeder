using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TerritoriosController : ControllerBase
    {
        private readonly ITerritorioRepository _territoriosRepository;
        public TerritoriosController(ITerritorioRepository territoriosRepository)
        {
            _territoriosRepository = territoriosRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTerritorios()
        {
            List<TerritorioDto> territoriosDto = new List<TerritorioDto>();
            var territorios = await _territoriosRepository.GetAllAsync();
        
            foreach(var territorio in territorios)
            {
                var dto = new TerritorioDto();
                dto.TerritorioId = territorio.TerritorioId;
                dto.Nome = territorio.Nome;
                dto.Bolsa = territorio.Bolsa;
                dto.Produtos = territorio.Produtos;
                territoriosDto.Add(dto);
            }

            return Ok(territoriosDto);
        }

        [HttpGet]
        [Route("{id}")]        public async Task<ActionResult<Territorio>> GetTerritorioById(int id)
        {
            var territorio = await _territoriosRepository.GetByIdAsync(id);

            if(territorio == null)
                return NotFound("Couldn't find the specified territory, maybe it doesn't exist");

            var territorioDto = new TerritorioDto();
            territorioDto.TerritorioId = territorio.TerritorioId;
            territorioDto.Nome = territorio.Nome;
            territorioDto.Bolsa = territorio.Bolsa;
            territorioDto.Produtos = territorio.Produtos;
    
            return Ok(territorioDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTerritorio([FromBody] TerritorioDto territorioDto)
        {
            if(ModelState.IsValid)
            {
                var territorio = new Territorio();
                territorio.Nome = territorioDto.Nome;
                territorio.Bolsa = territorioDto.Bolsa;
                territorio.Produtos = new Collection<TerritorioProduto>();

                var addResult = await _territoriosRepository.CreateAsync(territorio);
                if(addResult == null)
                    return BadRequest("Territorio wasn't added, try again");

                return Created("http://localhost:5000/api/territorios/{territorio.TerritorioId}", territorio);
            }
            return BadRequest("Provided model is not valid");

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateTerritorio([FromBody] TerritorioDto updatedTerritorioDto, int id)
        {
            if(ModelState.IsValid)
            {
                var updatedTerritorio = new Territorio();
                updatedTerritorio.TerritorioId = id;
                updatedTerritorio.Nome = updatedTerritorioDto.Nome;
                updatedTerritorio.Bolsa = updatedTerritorioDto.Bolsa;
                updatedTerritorio.Produtos = new List<TerritorioProduto>();

                var updateResult = await _territoriosRepository.UpdateAsync(updatedTerritorio);

                if(updateResult)
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

            if(deleteResult)
                return Ok("Territorio deleted succesfully");

            return BadRequest("Couldn't delete the territorio");
        }

    }
}