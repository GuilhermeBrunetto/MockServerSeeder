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
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllProdutos()
        {
            var produtos = await _produtoRepository.GetProdutos();
            return Ok(_mapper.Map<List<ProdutoDto>>(produtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProdutoById(int id)
        {
            var produto = await _produtoRepository.GetProdutoById(id);
            if (produto == null)
                return NotFound("Couldn't find the specified produto, maybe it doesn't exist");

            return Ok(_mapper.Map<ProdutoDto>(produto));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduto([FromBody] ProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                var produto = _mapper.Map<Produto>(produtoDto);

                var addResult = await _produtoRepository.CreateAsync(produto);
                if (addResult == null)
                    return BadRequest("Produto wasn't added, try again");

                return Created($"http://localhost:5000/api/produtos/{produto.ProdutoId}", produto);
            }
            return BadRequest("Provided model is not valid");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateProduto([FromBody] ProdutoDto updatedProdutoDto, int id)
        {
            if (ModelState.IsValid)
            {
                var updatedProduto = _mapper.Map<Produto>(updatedProdutoDto);
                updatedProduto.ProdutoId = id;
                var updateResult = await _produtoRepository.UpdateAsync(updatedProduto);

                if (updateResult)
                    return Ok("Produto updated successfully");

                return BadRequest("Couldn't update Produto, please try again");
            }

            return BadRequest("Provided model is not valid");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteGrao(int id)
        {
            var deleteResult = await _produtoRepository.DeleteAsync(id);

            if (deleteResult)
                return Ok("Produto deleted succesfully");

            return BadRequest("Couldn't delete the produto");
        }

    }
}