using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.TariffAgregate.Interface;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        //private readonly IIncludedProductInTariff _include;
        //private readonly IProduct _product;
        //private readonly ITariffRepostitory _tariff;
        //private readonly ITariffTestPeriod _tariffTestPeriod;
        private readonly IClassWithEnum _classWithEnum;

        public TestController(
            //IProduct product
            //, IIncludedProductInTariff include
            //, ITariffRepostitory tariff
            //, ITariffTestPeriod tariffTestPeriod
            IClassWithEnum classWithEnum
            )
        {
            //_product = product;
            //_include = include;
            //_tariff = tariff;
            //_tariffTestPeriod = tariffTestPeriod;
            _classWithEnum = classWithEnum;
        }

        [HttpGet("test")]
        public void GetSource()
        {
            // _product.AddElement();
            //_include.AddElement();
            //_tariff.AddElement();
            //_tariffTestPeriod.AddElement();
            _classWithEnum.AddElement();
        }
    }
}
