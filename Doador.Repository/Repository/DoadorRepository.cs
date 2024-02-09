using Dapper;
using Doador.Domain.Command;
using Doador.Domain.Interfaces;
using System.Data.SqlClient;


namespace Doador.Repository.Repository
{
    public class DoadorRepository : IDoadorRepository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=doador;Trusted_Connection=True;MultipleActiveResultSets=True";

        public async Task<IEnumerable<DoadorCommand>> GetAsync()
        {
            string queryget = @"Select * from CadastroDoador where ativoDoador = 1";
            using (SqlConnection conn = new SqlConnection(conexao))
            {                
                return await conn.QueryAsync<DoadorCommand>(queryget);               
            }
        }

        public async Task<string> PostAsync(DoadorCommand command)
        {
            string queryInsert = @"INSERT INTO CadastroDoador(nomeDoador, estadoDoador, idadeDoador, doadorCEP, bairroDoador, telefoneDoador, emailDoador, ativoDoador)
                                 Values(@nomeDoador, @estadoDoador, @idadeDoador, @doadorCEP, @bairroDoador, @telefoneDoador, @emailDoador, @ativoDoador)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryInsert, new
                {
                    nomeDoador = command.nomeDoador,
                    estadoDoador = command.estadoDoador,
                    idadeDoador = command.idadeDoador,
                    doadorCEP = command.doadorCEP,
                    bairroDoador = command.bairroDoador,
                    telefoneDoador = command.telefoneDoador,
                    emailDoador = command.emailDoador,
                    ativoDoador = command.ativoDoador,

                });
                return  "Doador cadastrado com sucesso";
            }

        }
    }
}
       
