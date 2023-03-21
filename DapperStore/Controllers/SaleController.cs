using AutoMapper;
using Domain.Entities.Entities;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController
    {

        private readonly ISaleUseCase _saleUseCase;
        private readonly IMapper _mapper;

        [HttpGet("{id:int}")]

        public async Task<Sale> Obtener_ProductQueCompro_By_Document(int id)
        {
            return await _saleUseCase.GetSaleById(id);
        }






    }
}
