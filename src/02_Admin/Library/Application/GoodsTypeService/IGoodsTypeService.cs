using EFCore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IGoodsTypeService
    {
        Task AddGoodsType(GoodsType goodsType);
    }
}
