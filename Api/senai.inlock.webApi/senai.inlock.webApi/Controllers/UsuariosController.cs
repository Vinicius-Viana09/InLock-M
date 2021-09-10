using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {

            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain loginUser)
        {
           UsuarioDomain usuarioBuscado = _UsuarioRepository.buscarPorEmailSenha(loginUser.emailUsuario, loginUser.senhaUsuario);

            if (usuarioBuscado != null)
            {
                // return Ok(usuarioBuscado);
                var claimsInlock = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.emailUsuario),
                    new Claim (JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim (ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Posso-pressentir-o-perigo-e-o-caos"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var TokenLogin = new JwtSecurityToken(
                    issuer: "inLock.WebAPI",
                    audience: "inLock.WebAPI",
                    claims: claimsInlock,
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: creds
                    ) ;

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(TokenLogin)
                });
            }
            else
            {
                return NotFound("Email ou senha inválidos");
            }
        }

        [HttpGet]
        public IActionResult get()
        {
            List<UsuarioDomain> ListaUsuarios = _UsuarioRepository.listar();

            return Ok(ListaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain UsuarioPesquisado = _UsuarioRepository.buscarPorId(id);

            if (UsuarioPesquisado == null)
            {
                return NotFound("Nenhum Usuario encontrado!");
            }

            return Ok(UsuarioPesquisado);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            _UsuarioRepository.inserir(novoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, UsuarioDomain UsuarioAtualizado)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.buscarPorId(id);

            if (UsuarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Usuario não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _UsuarioRepository.atualizar(id, UsuarioAtualizado);

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
            _UsuarioRepository.deletar(id);

            return StatusCode(204);
        }
    }
}
