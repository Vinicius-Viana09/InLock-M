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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult get()
        {
            List<TipoUsuarioDomain> ListaTipoUsuarios = _TipoUsuarioRepository.listar();

            return Ok(ListaTipoUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain TipoUsuarioPesquisado = _TipoUsuarioRepository.buscarPorId(id);

            if (TipoUsuarioPesquisado == null)
            {
                return NotFound("Nenhum Tipo encontrado!");
            }

            return Ok(TipoUsuarioPesquisado);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipoUsuario)
        {
            _TipoUsuarioRepository.inserir(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            TipoUsuarioDomain TipoUsuarioBuscado = _TipoUsuarioRepository.buscarPorId(id);

            if (TipoUsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Tipo de Usuario não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _TipoUsuarioRepository.atualizar(id, TipoUsuarioAtualizado);

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
            _TipoUsuarioRepository.deletar(id);

            return StatusCode(204);
        }
    }
}
