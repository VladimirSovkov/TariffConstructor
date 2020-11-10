using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.Interface;
using TariffConstructor.Infrastructure.Data.TariffConstructorModel.EntityConfigurations.ObjectTests.Interface;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        //private readonly IIncludedProductInTariff _include;
        //private readonly IProduct _product;
        //private readonly ITariffRepostitory _tariff;
        private readonly ITariffRepository _tariffTestPeriod;
        //private readonly IClassWithEnum _classWithEnum;

        public TestController(
            ITariffRepository tariffRepository
            //IProduct product
            //, IIncludedProductInTariff include
            //, ITariffRepostitory tariff
            //, ITariffTestPeriod tariffTestPeriod
            //IClassWithEnum classWithEnum
            )
        {
            _tariffTestPeriod = tariffRepository;
            //_product = product;
            //_include = include;
            //_tariff = tariff;
            //_tariffTestPeriod = tariffTestPeriod;
            //_classWithEnum = classWithEnum;
        }

        [HttpGet("test")]
        public void GetSource()
        {
            _tariffTestPeriod.AddTariff(/*new Tariff("test", PaymentType.Commission)*/);
        }
    }
}
