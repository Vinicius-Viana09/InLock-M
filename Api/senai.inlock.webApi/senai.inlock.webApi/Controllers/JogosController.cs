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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {

            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            List<JogoDomain> Listajogos = _JogoRepository.listar();

            return Ok(Listajogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoPesquisado = _JogoRepository.buscarPorId(id);

            if (jogoPesquisado == null)
            {
                return NotFound("Nenhum Jogo encontrado!");
            }

            return Ok(jogoPesquisado);
        }

        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _JogoRepository.inserir(novoJogo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _JogoRepository.buscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Jogo não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _JogoRepository.atualizar(id, jogoAtualizado);

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
            _JogoRepository.deletar(id);

            return StatusCode(204);
        }
    }
}
