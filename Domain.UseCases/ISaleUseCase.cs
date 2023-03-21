using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
   public interface ISaleUseCase
    {
        Task<Sale> GetSaleById(int id);


    }
}
