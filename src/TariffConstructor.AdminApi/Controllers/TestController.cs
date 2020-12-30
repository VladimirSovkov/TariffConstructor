﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffConstructor.AdminApi.Dto;
using TariffConstructor.AdminApi.Mappers.TariffAggregate;
using TariffConstructor.Domain.ContractModel;
using TariffConstructor.Domain.TariffAggregate;
using TariffConstructor.Domain.TariffAggregate.Toolkit;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Search;
using TariffConstructor.Domain.ProductAggregate;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.AdminApi.Mappers.ProductAggregate;
using TariffConstructor.Domain.ProductOptionAggregate;
using TariffConstructor.AdminApi.Mappers.ProductOptionAggregate;
using TariffConstructor.AdminApi.Dto.TariffAggragate;

namespace TariffConstructor.AdminApi.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        private readonly ITariffRepository _tariff;
        private readonly IProductRepository _product;
        private readonly IProductOptionRepository _productOption;

        public TestController(
            ITariffRepository tariffRepository
            , IProductRepository productRepository
            , IProductOptionRepository productOption)
        {
            _tariff = tariffRepository;
            _product = productRepository;
            _productOption = productOption;
        }

        [HttpPost("post")]
        public void AddTariff([FromBody]TariffLoadParameters parameters) 
        {
            PaymentType py = (PaymentType)Convert.ToInt32(parameters.PaymentType);
            Tariff tariff = new Tariff(parameters.Name, py);
            tariff.SetAccountingTariffId(parameters.AccountingTariffId);
            tariff.SetAwaitingPaymentStrategy(parameters.AwaitingPaymentStrategy);
            tariff.SetSettingsPresetId(parameters.SettingsPresetId);
            tariff.SetTermsOfUseId(parameters.TermsOfUseId);
            if (parameters.IsArchived)
                tariff.Archive();


            tariff.AddTestPeriod(new TariffTestPeriod(parameters.Value, (TariffTestPeriodUnit)Convert.ToInt32(parameters.Unit)));
            _tariff.Add(tariff);
        }

        [HttpGet("paginator")]
        public async Task<IReadOnlyList<SimplifiedTariffDto>> GetTariffs()
        {
            TariffPaginator abc = await _tariff.GetTariffs(5, 2);
            IReadOnlyList<SimplifiedTariffDto> tariffs = abc.Tariffs.ToSimplifiedTariffDtos();
            return tariffs;
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(SearchResult<SimplifiedTariffDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int pageNumber, int onPage, string searchString)
        {
            var abc = new TarifftSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Tariff> searchResult = await _tariff.GetFoundRates(abc);

            return Ok(new SearchResult<SimplifiedTariffDto>
            {
                Items = searchResult.Items.ToSimplifiedTariffDtos(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            }); 
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProducts(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<Product> searchResult = await _product.Search(abc);

            return Ok(new SearchResult<ProductDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }

        [HttpGet("productOption")]
        public async Task<IActionResult> GetProductOptions(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductOptionSearchPattern();
            abc.PageNumber = pageNumber;
            abc.OnPage = onPage;
            abc.SearchString = searchString;
            SearchResult<ProductOption> searchResult = await _productOption.Search(abc);

            return Ok(new SearchResult<ProductOptionDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }


        [HttpGet("getTariff")]
        public async Task<IActionResult> GetTariff(int id)
        {
                Tariff abc = await _tariff.GetTariff(id);
            ProlongationPeriod prolongation = new ProlongationPeriod(1, PeriodUnit.Year);
            Price price = new Price(98.12m, "USD");
            Product product = new Product("name product");
            ProductOption productOption = new ProductOption(1, "name", true);

            //price
            abc.AddPriceItem(price, prolongation);
            //advance price
            abc.AddAdvancePriceItem(price, prolongation);
            //included products
            //abc.AddProduct(product, 1);
            //included product option
            //abc.AddProductOption(productOption);
            //contract kind bindings
            abc.AddAvailableContractKind(1);
            return Ok(abc.Map());
        }
    }
}
