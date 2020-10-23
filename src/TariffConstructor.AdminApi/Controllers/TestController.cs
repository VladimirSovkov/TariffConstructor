using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("tariff")]
    public class TestController : Controller
    {
        private readonly IIncludedProductInTariff _include;
        private readonly IProduct _product;
        public TestController(
            IProduct product
            , IIncludedProductInTariff include
            )
        {
            _product = product;
            _include = include;
        }

        [HttpGet("test")]
        public void GetSource()
        {
           // _product.AddElement();
            _include.AddElement();
        }
    }
}
