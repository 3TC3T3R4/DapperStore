using Dapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Infraestructure.DriverAdapter.Gateway;

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



        public async Task<SaleWithProductAndClient> GetSaleByIdAsync(int idSale)
        {

            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var pcQuery = $"SELECT * FROM {tableName} WHERE id_sale_product_client = @idSale";
            var multiQuery = $"{pcQuery}";
            using (var multi = await connection.QueryMultipleAsync(multiQuery, new { idSale }))
            
            {
                var pc = await multi.ReadFirstOrDefaultAsync<Sale>();
                if (pc == null)
                {
                    return null;
                }
                var mouseQuery = $"SELECT * FROM {tableName2} WHERE id_product = {pc.product_id_product}";

                var tecladoQuery = $"SELECT * FROM {tableName3} WHERE id_client = {pc.client_id_client}";
                var mouse = await connection.QuerySingleOrDefaultAsync<Product>(mouseQuery);
                var teclado = await connection.QuerySingleOrDefaultAsync<Client>(tecladoQuery);

                return new SaleWithProductAndClient
                {
                    id_sale_product_client = pc.id_sale_product_client,
                    Product = mouse,
                    Client = teclado,
                    way_to_pay = pc.way_to_pay,
                    date_sale = pc.date_sale

                };
            }
        }
    }
}
