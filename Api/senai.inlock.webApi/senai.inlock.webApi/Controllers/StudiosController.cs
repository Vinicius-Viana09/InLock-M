using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class StudiosController : ControllerBase
    {
        private IStudioRepository _StudioRepository { get; set; }

        public StudiosController()
        {

            _StudioRepository = new StudioRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            List<StudioDomain> ListaStudios = _StudioRepository.listar();

            return Ok(ListaStudios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            StudioDomain StudioPesquisado = _StudioRepository.buscarPorId(id);

            if (StudioPesquisado == null)
            {
                return NotFound("Nenhum Studio encontrado!");
            }

            return Ok(StudioPesquisado);
        }

        [HttpPost]
        public IActionResult Post(StudioDomain novoStudio)
        {
            _StudioRepository.inserir(novoStudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, StudioDomain StudioAtualizado)
        {
            StudioDomain StudioBuscado = _StudioRepository.buscarPorId(id);

            if (StudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Studio não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _StudioRepository.atualizar(id, StudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _StudioRepository.deletar(id);

            return StatusCode(204);
        }
    }
}
