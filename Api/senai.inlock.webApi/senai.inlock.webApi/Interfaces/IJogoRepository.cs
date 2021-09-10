using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        public List<JogoDomain> listar();

        public JogoDomain buscarPorId(int id);

        public void inserir(JogoDomain jogo);

        public void atualizar(int id, JogoDomain jogoAtualizado);

        public void deletar(int id);
    }
}
