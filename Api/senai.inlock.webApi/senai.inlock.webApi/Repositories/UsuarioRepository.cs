using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source = DESKTOP-RJD23R9\SQLEXPRESS; initial catalog = INLOCK; user = sa; pwd = Senai@132";

        public void atualizar(int id, UsuarioDomain UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizar = @"UPDATE USUARIO SET emailUsuario = '@novoEmailUsuario', senhaUsuario = '@novaSenhaUsuario' idUsuario = @idUsuarioAtualizado idTipoUsuario = @idTipoUsuarioAtualizado WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuarioAtualizado", UsuarioAtualizado.idUsuario);
                    cmd.Parameters.AddWithValue("@novoEmailUsuario", UsuarioAtualizado.emailUsuario);
                    cmd.Parameters.AddWithValue("@novaSenhaUsuario", UsuarioAtualizado.senhaUsuario);
                    cmd.Parameters.AddWithValue("@idTipoUsuarioAtualizado", UsuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain buscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT * FROM USUARIO WHERE
                                        email = @email
                                            AND
                                        senha = @senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(leitor["idUsuario"]),
                            emailUsuario = Convert.ToString(leitor["emailUsuario"]),
                            senhaUsuario = Convert.ToString(leitor["senhaUsuario"]),
                            idTipoUsuario = Convert.ToInt32(leitor["idTipoUsuario"]),
                        };

                        return usuarioBuscado;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }


        public UsuarioDomain buscarPorId(int id)
        {
            UsuarioDomain Usuario = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = @"SELECT idUsuario, emailUsuario 'Email', senhaUsuario 'Senha', idTipoUsuario 'id do Tipo' FROM USUARIO WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    SqlDataReader leitor;

                    leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {

                        Usuario.idUsuario = Convert.ToInt32(leitor[0]);
                        Usuario.idTipoUsuario = Convert.ToInt32(leitor[3]);
                        Usuario.emailUsuario = Convert.ToString(leitor[1]);
                        Usuario.senhaUsuario = Convert.ToString(leitor[2]);

                        return Usuario;
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
                string queryDelete = @"DELETE FROM USUARIO WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void inserir(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = @"INSERT INTO USUARIO emailUsuario, senhaUsuario, idTipoUsuario VALUES('@emailUsuarioNovo', '@senhaUsuarioNovo', '@idTipoUsernovo' )";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@emailUsuarioNovo", novoUsuario.emailUsuario);
                    cmd.Parameters.AddWithValue("@senhaUsuarioNovo", novoUsuario.senhaUsuario);
                    cmd.Parameters.AddWithValue("@idTipoUsernovo", novoUsuario.idTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }


        }

        public List<UsuarioDomain> listar()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT idUsuario, idTipoUsuario, emailUsuario 'Email', senhaUsuario 'Senha', nomeTipoUsuario 'Tipo'  FROM STUDIO
JOIN TIPOUSUARIO
ON TIPOUSUARIO.idTipoUsuario = USUARIO.idTipoUsuario;";

                con.Open();

                SqlDataReader leitor;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    leitor = cmd.ExecuteReader();

                    while (leitor.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(leitor[0]),
                            idTipoUsuario = Convert.ToInt32(leitor[1]),
                            emailUsuario = Convert.ToString(leitor[2]),
                            senhaUsuario = Convert.ToString(leitor[3]),
                        };

                        listaUsuarios.Add(usuario);
                    }
                };
            };

            return listaUsuarios;
        }
    }
}
