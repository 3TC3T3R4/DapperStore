﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DriverAdapter.Gateway
{
    public interface IDbConnectionBuilder
    {


        Task<IDbConnection> CreateConnectionAsync();



    }
}