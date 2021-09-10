using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IStudioRepository
    {
        public List<StudioDomain> listar();

        public StudioDomain buscarPorId(int id);

        public void inserir(StudioDomain studio);

        public void atualizar(int id, StudioDomain studioAtualizado);

        public void deletar(int id);
    }
}
