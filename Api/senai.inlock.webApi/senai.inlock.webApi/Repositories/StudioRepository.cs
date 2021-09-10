using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-RJD23R9\SQLEXPRESS; initial catalog = INLOCK; user = sa; pwd = Senai@132";

        public void atualizar(int id, StudioDomain StudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = @"UPDATE STUDIO SET nomeStudio = '@novoNomeStudio', idStudio = @idStudioAtualizado WHERE idStudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idStudioAtualizado", StudioAtualizado.idStudio);
                    cmd.Parameters.AddWithValue("@novoNomeStudio", StudioAtualizado.nomeStudio);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public StudioDomain buscarPorId(int id)
        {
            StudioDomain Studio = new StudioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = @"SELECT idStudio, nomeStudio 'Estudio' FROM STUDIO WHERE idStudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader leitor;

                    leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {

                        Studio.idStudio = Convert.ToInt32(leitor[0]);
                        Studio.nomeStudio = Convert.ToString(leitor[1]);

                        return Studio;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = @"DELETE FROM STUDIO WHERE idStudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void inserir(StudioDomain novoStudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO STUDIO nomeStudio VALUES('@nomeStudioNovo')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeStudioNovo", novoStudio.nomeStudio);

                    cmd.ExecuteNonQuery();
                }
            }


        }

        public List<StudioDomain> listar()
        {
            List<StudioDomain> listaStudios = new List<StudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idStudio, nomeStudio 'Estudio' FROM STUDIO";

                con.Open();

                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        StudioDomain studio = new StudioDomain()
                        {
                            idStudio = Convert.ToInt32(leitor[0]),
                            nomeStudio = Convert.ToString(leitor[1]),
                        };

                        listaStudios.Add(studio);
                    }
                };
            };

            return listaStudios;
        }
    }
}
