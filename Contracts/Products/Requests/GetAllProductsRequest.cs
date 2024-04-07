﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Products.Requests
{
    public record GetAllProductsRequest(
        int Page,
        int ItemsPerPage
        );
    
}
