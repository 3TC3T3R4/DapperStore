
using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infraestructure.DriverAdapter.Gateway;
using System.Data;

namespace Infraestructure.DriverAdapter
{
    public class ClientRepository : IClientRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Client";

        public ClientRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            //NORMAL CONSULTA TRAINING
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Client>(sqlQuery);
            connection.Close();
            return result.ToList();

            //CONSULTA CON STOREPROCEDURE
            //var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            //var result = await connection.QueryAsync<Client>("GETALLCLIENTS", commandType: CommandType.StoredProcedure);
            //connection.Close();
            //return result.ToList();

            //CONSULTA CON VIEW
            //var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            //var result = await connection.QueryAsync<Client>("SELECT * FROM GETALLCLIENTSVIEW");
            //connection.Close();
            //return result.ToList();



        }

        public async Task<Client> GetClientByIdAsync(int idClient)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName} WHERE id_client = {idClient}";
            var result = await connection.QueryFirstAsync<Client>(sqlQuery);
            connection.Close();
            return result;
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var clientAAgregar = new
            {
                    id = client.id_client,
                    cedula = client.id_number,
                    tipodecedula   = client.type_id,
                    nombre = client.name
            };
            string sqlQuery = $"INSERT INTO {tableName} (id_client, id_number, type_id,name)VALUES(@id, @cedula, @tipodecedula, @nombre)";
            var rows = await connection.ExecuteAsync(sqlQuery, clientAAgregar);
            return client;
        }

        public Task<Client> InsertClientSqlKataAsync(Client client)
        {
            throw new NotImplementedException();
        }


    }
}
