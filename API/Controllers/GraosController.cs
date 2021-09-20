using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GraosController : Controller
    {
        private readonly IGraoRepository _graoRepository;
        public GraosController(IGraoRepository graoRepository)
        {
            _graoRepository = graoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetGraos()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetGraoById(int id)
        {
            return Ok();
        }
 
        [HttpPost]
        public async Task<ActionResult> CreateGrao([FromBody] GraoDto graoDto)
        {
            return Ok();
        }

       [HttpPut]
       [Route("{id}")]
        public async Task<ActionResult> UpdateGrao([FromBody] GraoDto updatedGraoDto, int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteGrao(int id)
        {
            return Ok();
        }

    }
}