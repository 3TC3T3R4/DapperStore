using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infraestructure.DriverAdapter.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Humanizer.In;

namespace Infraestructure.DriverAdapter
{
    public class SaleRepository : ISaleRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Sale";
        private readonly string tableName2 = "Product";
        private readonly string tableName3 = "Client";


        public SaleRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        

        public async Task<Sale> GetSaleByIdAsync(int idSale)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT pro.name  AS  ProductBuy * FROM {tableName} s " +
                $"INNER JOIN {tableName3} cl  ON  s.client_id_client = cl.id_client INNER JOIN {tableName2} pro" +
                $"ON s.product_id_product = pro.id_product" +
                $" WHERE   cl.type_id = 'C.C' and  cl.id_number = @idSale";

            var result = await connection.QueryAsync<Sale>(sqlQuery);
            connection.Close();
            return (Sale)result;

        }
    }
}
