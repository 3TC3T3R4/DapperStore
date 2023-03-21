﻿using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway.Repository
{
    public interface ISaleRepository
    {

        Task<Sale> GetSaleByIdAsync(int idSale);



    }
}
