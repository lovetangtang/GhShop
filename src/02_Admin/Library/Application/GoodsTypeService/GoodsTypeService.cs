using EFCore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GoodsTypeService : IGoodsTypeService
    {
        private ApiDBContent _dbContext = null;
        public GoodsTypeService(ApiDBContent dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddGoodsType(GoodsType goodsType)
        {
            _dbContext.Add(goodsType);
             await _dbContext.SaveChangesAsync();
        }
    }
}
