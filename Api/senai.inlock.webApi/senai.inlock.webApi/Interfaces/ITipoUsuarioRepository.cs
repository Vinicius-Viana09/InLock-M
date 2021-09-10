using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        public List<TipoUsuarioDomain> listar();

        public TipoUsuarioDomain buscarPorId(int id);

        public void inserir(TipoUsuarioDomain tipoUsuario);

        public void atualizar(int id, TipoUsuarioDomain tipoAtualizado);

        public void deletar(int id);
    }
}
