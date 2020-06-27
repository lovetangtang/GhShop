using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using EFCore.Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    /// <summary>
    /// 物品分类操作接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GoodTypeController : ControllerBase
    {
        private ApiDBContent _dbContext = null;
        private readonly IGoodsTypeService _goodsTypeService;

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="dbContext"></param>
        public GoodTypeController(ApiDBContent dbContext, GoodsTypeService goodsTypeService)
        {
            _dbContext = dbContext;
            _goodsTypeService = goodsTypeService;
        }
        /// <summary>
        /// 获取物品分类数据
        /// </summary>
        /// <param name="rank">0:主分类；1：子分类</param>
        /// <returns></returns>
        // GET: api/<GoodTypeController>
        [HttpGet]
        public IEnumerable<GoodsType> Get(int rank)
        {
            return _dbContext.GoodsType.Where(e => e.Rank == rank).ToList();
        }

        /// <summary>
        /// 新增物品分类
        /// </summary>
        /// <param name="goodsType"></param>
        // POST api/<GoodTypeController>
        [HttpPost]
        public async Task Post([FromBody] GoodsType goodsType)
        {
            await _goodsTypeService.AddGoodsType(goodsType);
        }

        /// <summary>
        /// 修改物品分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="goodsType"></param>
        // PUT api/<GoodTypeController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] GoodsType goodsType)
        {
            _dbContext.GoodsType.Update(goodsType);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 删除物品分类信息
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<GoodTypeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var GoodsType = _dbContext.GoodsType.Find(id);
            _dbContext.GoodsType.Remove(GoodsType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
