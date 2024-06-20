using InnovaAgroTech.Models;
using Microsoft.Data.SqlClient;

namespace InnovaAgroTech.Repositories.ADO.SQLServer
{
    public class LoginDAO
    {
        private readonly string connectionString;

        public LoginDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Criar o método de validação do Login do Usuário.
        public bool check(Login login)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ID FROM LOGIN WHERE USUARIO=@USUARIO AND SENHA=@SENHA;";
                    command.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = login.Id;
                    command.Parameters.Add(new SqlParameter("@SENHA", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    // Executa o comando da SQL: "SELECT". 
                    SqlDataReader dr = command.ExecuteReader();

                    // Se encontrado o usuário, result é verdadeiro (result = true;),
                    // caso contrário, result se mantém como falso (result = false;).
                    result = dr.Read();
                }
            }
            // retorna o valor de result (true ou false).
            return result;
        }

        public LoginResultado getTipo(Login login)
        {
            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ID, TIPO FROM LOGIN WHERE ID_USUARIO=@ID_USUARIO AND SENHA=@SENHA";
                    command.Parameters.Add(new SqlParameter("@ID_USUARIO", System.Data.SqlDbType.VarChar)).Value = login.Id;
                    command.Parameters.Add(new SqlParameter("@SENHA", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id"];
                            result.TipoUsuario = dr["tipo"].ToString();

                            login.Id = result.Id;
                            login.Usuario_Niveis = result.TipoUsuario;
                        } // encerra if.
                    } // encerra using SqlDataReader.

                } // encerra using SqlCommand.

                //...executar códigos dentro da sessão durante o login do usuário efetuado com sucesso.

            } // encerra using SqlConnection.

            return result;
        }
    }
}
