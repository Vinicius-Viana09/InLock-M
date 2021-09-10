using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        public List<UsuarioDomain> listar();

        public UsuarioDomain buscarPorId(int id);

        public void inserir(UsuarioDomain usuario);

        public void atualizar(int id, UsuarioDomain usuarioAtualizado);

        public void deletar(int id);
    }
}
