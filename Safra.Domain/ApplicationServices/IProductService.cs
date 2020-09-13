﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Safra.Domain.Models;

namespace Safra.Domain.ApplicationServices
{
    public interface IProductService
    {
        Task<List<Product>> Get(bool showInactives);
        Task<Product> Get(int id);
        Task<int> Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
