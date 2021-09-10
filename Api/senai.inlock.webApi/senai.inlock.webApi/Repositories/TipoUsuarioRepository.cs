using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-RJD23R9\SQLEXPRESS; initial catalog = INLOCK; user = sa; pwd = Senai@132";

        public void atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = @"UPDATE TIPOUSUARIO SET nomeTipoUsuario = '@novoNomeTipoUsuario', idTipoUsuario = @idTipoAtualizado WHERE idTipoUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoAtualizado", tipoUsuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@novoNomeTipoUsuario", tipoUsuarioAtualizado.nomeTipoUsuario);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain buscarPorId(int id)
        {
            TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = @"SELECT idTipoUsuario, nomeTipoUsuario 'Tipo Usuario' FROM TIPOUSUARIO WHERE idTipoUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader leitor;

                    leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {

                        TipoUsuario.idTipoUsuario = Convert.ToInt32(leitor[0]);
                        TipoUsuario.nomeTipoUsuario = Convert.ToString(leitor[1]);

                        return TipoUsuario;
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
                string queryDelete = @"DELETE FROM TIPOUSUARIO WHERE idTipoUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void inserir(TipoUsuarioDomain novoTipo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO TIPOUSUARIO nomeTipoUsuario VALUES('@nomeTipo')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeTipo", novoTipo.nomeTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }


        }

        public List<TipoUsuarioDomain> listar()
        {
            List<TipoUsuarioDomain> listaTipos = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idTipoUsuario, nomeTipoUsuario 'Tipo' FROM TIPOUSUARIO";

                con.Open();

                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(leitor[0]),
                            nomeTipoUsuario = Convert.ToString(leitor[1]),
                        };

                        listaTipos.Add(tipo);
                    }
                };
            };

            return listaTipos;
        }
    }
}
