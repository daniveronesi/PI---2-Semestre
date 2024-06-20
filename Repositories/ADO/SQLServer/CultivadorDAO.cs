using InnovaAgroTech.Models;
using Microsoft.Data.SqlClient;

namespace InnovaAgroTech.Repositories.ADO.SQLServer
{
    public class CultivadorDAO
    {
        //Declarado para toda a classe. Possível alterar somente no construtor.
        private readonly string connectionString;

        //Quem invocar o construtor do repositório deve enviar a string de conexão.
        public CultivadorDAO(string connectionString)
        {
            // atualização do atributo por meio do valor que veio
            // no parâmetro do construtor.
            this.connectionString = connectionString;
        }

        /* Método para Listar todos os Carros. */
        public List<Cultivador> getAllCultivadores() // get() ou getUsuario ou getAllUsuarios()
        {
            List<Cultivador> cultivadores = new List<Cultivador>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                //Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select cnpj, numero, logradouro, complemento, cidade, estado, numero, cep, nome ,sexo, cultura, cultivo, categoria, email;";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Cultivador cultivador = new Cultivador();

                        cultivador.CNPJ = (int)dr["CNPJ"];
                        cultivador.Telefone = (int)dr["celular"];
                        cultivador.Logradouro = (string)dr["logradouro"];
                        cultivador.Complemento = (string)dr[""];
                        cultivador.Cidade = (string)dr["cidade"];
                        cultivador.Estado = (string)dr["estado"];
                        cultivador.Numero = (int)dr["numero"];
                        cultivador.CEP = (int)dr["CEP"];
                        cultivador.Nome = dr["nome"].ToString();
                        cultivador.Sexo = (bool)dr["sexo"];
                        cultivador.Cultura = (int)dr["cultura"];
                        cultivador.Cultivo = (string)dr["cultivo"];
                        cultivador.Categoria = (string)dr["categoria"];
                        cultivador.Email = (string)dr["email"];
                        cultivador.NomeProp = (string)dr["nomeprop"];


                        cultivadores.Add(cultivador);
                    }
                }

            }

            return cultivadores;
        }

        /* Método para Listar somente 1 Carro. */
        public Cultivador getByIdCultivador(int id)
        {
            Cultivador cultivador = new Cultivador();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    // Cria o comando (instrução SQL) que será feita a tabela carro do banco de dados CarrosDB
                    command.Connection = connection;
                    command.CommandText = "select id, nome, cor, dataFabricacao, valor from carro where id=@id;";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    // Faz a consulta através do comando e retorna o resultado da consulta para o objeto dr (da classe SqlDataReader)
                    SqlDataReader dr = command.ExecuteReader();

                    // Caso encontrado um carro na consulta, os dados serão carregados no objeto carro.
                    if (dr.Read())
                    {
                        cultivador.CNPJ = (int)dr["CNPJ"];
                        cultivador.Telefone = (int)dr["celular"];
                        cultivador.Logradouro = (string)dr["logradouro"];
                        cultivador.Complemento = (string)dr[""];
                        cultivador.Cidade = (string)dr["cidade"];
                        cultivador.Estado = (string)dr["estado"];
                        cultivador.Numero = (int)dr["numero"];
                        cultivador.CEP = (int)dr["CEP"];
                        cultivador.Nome = dr["nome"].ToString();
                        cultivador.Sexo = (bool)dr["sexo"];
                        cultivador.Cultura = (int)dr["cultura"];
                        cultivador.Cultivo = (string)dr["cultivo"];
                        cultivador.Categoria = (string)dr["categoria"];
                        cultivador.Email = (string)dr["email"];
                        cultivador.NomeProp = (string)dr["nomeprop"];
                    }
                }
            }
            return cultivador; // retorna o carro encontrado na consulta.
        }

        /* Método para Editar um Carro pelo seu identificador (id). */
        public void update(int id_usuario, Cultivador cultivador)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    // Cria o comando (instrução SQL) que será feita a atualização do carro
                    // na tabela do carro no banco de dados CarrosDB.
                    command.CommandText = "UPDATE CNPJ SET CNPJ=@CNPJ, " +
                                          "TELEFONE=@TELEFONE, " +
                                          "LOGRADOURO=@LOGRADOURO," +
                                          "COMPLEMENTO=@COMPLEMENTO " +
                                          "CIDADE=@CIDADE" +
                                          "ESTADO=@ESTADO" +
                                          "NUMERO=@NUMERO" +
                                          "CEP=@CEP" +
                                          "NOME=@NOME" +
                                          "SEXO=@SEXO" +
                                          "CULTURA=@CULTURA" +
                                          "CULTIVO=@CULTIVO" +
                                          "CATEGORIA=@CATEGORIA" +
                                          "EMAIL=@EMAIL" +
                                          //"NOMEPROP=@NOMEPROP" +
                                          "WHERE ID_USUARIO=@ID_USUARIO;";
                    command.Parameters.Add(new SqlParameter("@CNPJ", System.Data.SqlDbType.VarChar)).Value = cultivador.CNPJ;
                    command.Parameters.Add(new SqlParameter("@TELEFONE", System.Data.SqlDbType.VarChar)).Value =  cultivador.Telefone;
                    command.Parameters.Add(new SqlParameter("@LOGRADOURO", System.Data.SqlDbType.DateTime)).Value = cultivador.Logradouro;
                    command.Parameters.Add(new SqlParameter("@COMPLEMENTO", System.Data.SqlDbType.Decimal)).Value = cultivador.Complemento;
                    command.Parameters.Add(new SqlParameter("@CIDADE", System.Data.SqlDbType.Int)).Value = cultivador.Cidade;
                    command.Parameters.Add(new SqlParameter("@ESTADO", System.Data.SqlDbType.Int)).Value = cultivador.Estado;
                    command.Parameters.Add(new SqlParameter("@NUMERO", System.Data.SqlDbType.Int)).Value = cultivador.Numero;
                    command.Parameters.Add(new SqlParameter("@CEP", System.Data.SqlDbType.Int)).Value = cultivador.CEP;
                    command.Parameters.Add(new SqlParameter("@NOME", System.Data.SqlDbType.Int)).Value = cultivador.Nome;
                    command.Parameters.Add(new SqlParameter("@SEXO", System.Data.SqlDbType.Int)).Value = cultivador.Sexo;
                    command.Parameters.Add(new SqlParameter("@CULTURA", System.Data.SqlDbType.Int)).Value = cultivador.Cultura;
                    command.Parameters.Add(new SqlParameter("@CULTIVO", System.Data.SqlDbType.Int)).Value = cultivador.Cultivo;
                    command.Parameters.Add(new SqlParameter("@CATEGORIA", System.Data.SqlDbType.Int)).Value = cultivador.Categoria;
                    command.Parameters.Add(new SqlParameter("@EMAIL", System.Data.SqlDbType.Int)).Value = cultivador.Email;
                    //command.Parameters.Add(new SqlParameter("@NOMEPROP", System.Data.SqlDbType.Int)).Value = cultivador.Nome_Prop;
                    command.Parameters.Add(new SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int)).Value = cultivador.Id;


                    /* Executar a atualização dos dados da tabela carro. */
                    command.ExecuteNonQuery();
                }
            }
        }

        /* Método para Adicionar um Carro - objeto carro. */
        public void add(Cultivador cultivador)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    // Cria o comando (instrução SQL) que será feita a inserção do carro
                    // na tabela do carro no banco de dados CarrosDB.
                    command.CommandText = "INSERT CNPJ SET CNPJ=@CNPJ, " +
                                          "TELEFONE=@TELEFONE, " +
                                          "LOGRADOURO=@LOGRADOURO," +
                                          "COMPLEMENTO=@COMPLEMENTO " +
                                          "CIDADE=@CIDADE" +
                                          "ESTADO=@ESTADO" +
                                          "NUMERO=@NUMERO" +
                                          "CEP=@CEP" +
                                          "NOME=@NOME" +
                                          "SEXO=@SEXO" +
                                          "CULTURA=@CULTURA" +
                                          "CULTIVO=@CULTIVO" +
                                          "CATEGORIA=@CATEGORIA" +
                                          "EMAIL=@EMAIL" +
                                          //"NOMEPROP=@NOMEPROP" +
                                          "WHERE ID_USUARIO=@ID_USUARIO;" +
                                          "SELECT CONVERT(STRING,@@IDENTITY) AS ID;;";
                    command.Parameters.Add(new SqlParameter("@CNPJ", System.Data.SqlDbType.VarChar)).Value = cultivador.CNPJ;
                    command.Parameters.Add(new SqlParameter("@TELEFONE", System.Data.SqlDbType.VarChar)).Value = cultivador.Telefone;
                    command.Parameters.Add(new SqlParameter("@LOGRADOURO", System.Data.SqlDbType.DateTime)).Value = cultivador.Logradouro;
                    command.Parameters.Add(new SqlParameter("@COMPLEMENTO", System.Data.SqlDbType.Decimal)).Value = cultivador.Complemento;
                    command.Parameters.Add(new SqlParameter("@CIDADE", System.Data.SqlDbType.Int)).Value = cultivador.Cidade;
                    command.Parameters.Add(new SqlParameter("@ESTADO", System.Data.SqlDbType.Int)).Value = cultivador.Estado;
                    command.Parameters.Add(new SqlParameter("@NUMERO", System.Data.SqlDbType.Int)).Value = cultivador.Numero;
                    command.Parameters.Add(new SqlParameter("@CEP", System.Data.SqlDbType.Int)).Value = cultivador.CEP;
                    command.Parameters.Add(new SqlParameter("@NOME", System.Data.SqlDbType.Int)).Value = cultivador.Nome;
                    command.Parameters.Add(new SqlParameter("@SEXO", System.Data.SqlDbType.Int)).Value = cultivador.Sexo;
                    command.Parameters.Add(new SqlParameter("@CULTURA", System.Data.SqlDbType.Int)).Value = cultivador.Cultura;
                    command.Parameters.Add(new SqlParameter("@CULTIVO", System.Data.SqlDbType.Int)).Value = cultivador.Cultivo;
                    command.Parameters.Add(new SqlParameter("@CATEGORIA", System.Data.SqlDbType.Int)).Value = cultivador.Categoria;
                    command.Parameters.Add(new SqlParameter("@EMAIL", System.Data.SqlDbType.Int)).Value = cultivador.Email;
                    //command.Parameters.Add(new SqlParameter("@NOMEPROP", System.Data.SqlDbType.Int)).Value = cultivador.Nome_Prop;
                    command.Parameters.Add(new SqlParameter("@ID_USUARIO", System.Data.SqlDbType.Int)).Value = cultivador.Id;

                    cultivador.Id = (int)command.ExecuteScalar(); // o homem do saco leva os dados até o
                    // SGBD e volta com o valor do id -> ExecuteScalar retorna um único valor. Observe que
                    // o ComandText foi alterado com mais de uma instrução. Então, as duas instruções são 
                    // executadas e temos como retorno o valor do id que foi gerado pelo SGBD na tabela
                    // carro. Assim, conseguimos atualizar o valor do id do objeto carro que antes da
                    // inserção era 0.
                } // finaliza SqlCommand.
            } // finaliza SqlConnection.
        } // fim do método add.

        /* Método para Remover um Carro pelo seu identificador (id). */
        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    // Cria o comando (instrução SQL) que será feita a remoção do carro
                    // na tabela do carro no banco de dados CarrosDB.
                    command.CommandText = "DELETE FROM CARRO WHERE ID=@ID";
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                    /* Executar a remoção dos dados da tabela carro. */
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
