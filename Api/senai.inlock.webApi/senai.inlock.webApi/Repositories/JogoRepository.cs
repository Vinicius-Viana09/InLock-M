using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-RJD23R9\SQLEXPRESS; initial catalog = INLOCK; user = sa; pwd = Senai@132";

        public void atualizar(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = @"UPDATE JOGOS SET nomeJogo = '@novoNomeJogo', dataLancamento = '@novaDataLancamento', descricaoJogo = '@novaDescricaoJogo', valorJogo = '@novoValorJogo', idJogos = @novoIdJogo, idStudio = @novoIdStudio WHERE idJogos = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novaDescricaoJogo", jogoAtualizado.descricaoJogo);
                    cmd.Parameters.AddWithValue("@novoValorJogo", jogoAtualizado.valorJogo);
                    cmd.Parameters.AddWithValue("@novoIdJogo", jogoAtualizado.idJogo);
                    cmd.Parameters.AddWithValue("@novoIdStudio", jogoAtualizado.idStudio);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain buscarPorId(int id)
        {
            JogoDomain jogo = new JogoDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = @"SELECT idJogos, idStudio, nomeJogo 'Jogo', descricaoJogo 'Descrição', valorJogo 'Valor em reais', dataLancamento 'Lançamento'  FROM JOGOS WHERE idJogos = @id";

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader leitor;

                    leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {

                        jogo.idJogo = Convert.ToInt32(leitor[0]);
                        jogo.idStudio = Convert.ToInt32(leitor[1]);
                        jogo.nomeJogo = Convert.ToString(leitor[2]);
                        jogo.descricaoJogo = Convert.ToString(leitor[3]);
                        jogo.valorJogo = Convert.ToString(leitor[4]);
                        jogo.dataLancamento = Convert.ToDateTime(leitor[5]);

                        return jogo;
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
                string queryDelete = @"DELETE FROM JOGOS WHERE idJogos = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void inserir(JogoDomain jogoNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO JOGOS nomeJogo, dataLancamento, descricaoJogo, valorJogo, idStudio VALUES('@novoNomeJogo', '@novaDataLancamento', '@novaDescricaoJogo', '@novoValorJogo', '@novoIdStudio' )";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeJogo", jogoNovo.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", jogoNovo.dataLancamento);
                    cmd.Parameters.AddWithValue("@novaDescricaoJogo", jogoNovo.descricaoJogo);
                    cmd.Parameters.AddWithValue("@novoValorJogo", jogoNovo.valorJogo);
                    cmd.Parameters.AddWithValue("@novoIdJogo", jogoNovo.idJogo);
                    cmd.Parameters.AddWithValue("@novoIdStudio", jogoNovo.idStudio);

                    cmd.ExecuteNonQuery();
                }
            }


        }

        public List<JogoDomain> listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idJogos, idStudio, nomeJogo 'Jogo', descricaoJogo 'Descrição', valorJogo 'Valor em reais', dataLancamento 'Lançamento', nomeStudio 'Produtora' FROM JOGOS
JOIN STUDIO
ON STUDIO.idStudio = JOGOS.idStudio;";

                con.Open();

                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(leitor[0]),
                            idStudio = Convert.ToInt32(leitor[1]),
                            nomeJogo = Convert.ToString(leitor[2]),
                            descricaoJogo = Convert.ToString(leitor[3]),
                            valorJogo = Convert.ToString(leitor[4]),
                            dataLancamento = Convert.ToDateTime(leitor[5]),
                        };

                        listaJogos.Add(jogo);
                    }
                };
            };

            return listaJogos;
        }
    }
}
