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
        // GET: api/<GoodTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取物品分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<GoodTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<GoodTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoodTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
