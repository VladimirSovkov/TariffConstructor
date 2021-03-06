﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Modules.ProductOptionTariffModule.Dto;
using TariffConstructor.AdminApi.Modules.ProductOptionTariffModule.Mappers;
using TariffConstructor.Domain.ProductOptionTariffModel;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.AdminApi.Modules.ProductOptionTariffModule
{
    [Route("productOptionTariffs")]
    [ApiController]
    public class ProductOptionTariffController : ControllerBase
    {
        private readonly IProductOptionTariffRepository productOptionTariffRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductOptionTariffController(IProductOptionTariffRepository productOptionTariffRepository,
            IUnitOfWork unitOfWork)
        {
            this.productOptionTariffRepository = productOptionTariffRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductOptionTariffDto productOptionTariffDto)
        {
            ProductOptionTariff productOptionTariff = new ProductOptionTariff(
                productOptionTariffDto.ProductOptionId,
                productOptionTariffDto.Name);
            foreach (var priceItem in productOptionTariffDto.Prices)
            {
                Price price = new Price(priceItem.Price.Value, priceItem.Price.Currency);
                ProlongationPeriod prolongationPeriod = new ProlongationPeriod(priceItem.Period.Value, (PeriodUnit)priceItem.Period.periodUnit);
                productOptionTariff.AddPriceItem(price, prolongationPeriod);
            }
            await productOptionTariffRepository.Add(productOptionTariff);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductOptionTariff(int id)
        {
            ProductOptionTariff productOptionTariff = await productOptionTariffRepository.GetProductOptionTariff(id);
            if (productOptionTariff == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOptionTariff id == {id}. Not found!");
            }
            return Ok(productOptionTariff.Map());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productOptionTariffRepository.Delete(id);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Update([FromBody] ProductOptionTariffDto productOptionTariffDto)
        {
            ProductOptionTariff productOptionTariff = await productOptionTariffRepository.GetProductOptionTariff(productOptionTariffDto.Id);
            if (productOptionTariff == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"ProductOptionTariff id == {productOptionTariffDto.Id}. Not found!");
            }

            productOptionTariff.SetName(productOptionTariffDto.Name);
            productOptionTariff.SetProductOption(productOptionTariffDto.ProductOptionId);

            productOptionTariff.RemovePriceItems(productOptionTariffDto.Prices.ToProductOptionTariffPrices());

            foreach (var item in productOptionTariffDto.Prices)
            {
                Price price = new Price(item.Price.Value, item.Price.Currency);
                ProlongationPeriod period = new ProlongationPeriod(item.Period.Value, (PeriodUnit)item.Period.periodUnit);
                if (productOptionTariff.Prices.FirstOrDefault(x => x.Period == period
                                                                    && x.Price.Currency == price.Currency) != null)
                {
                    productOptionTariff.ChangePriceItem(price, period);
                }
                else
                    productOptionTariff.AddPriceItem(price, period);
            }

            await productOptionTariffRepository.Update(productOptionTariff);
            await unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(int pageNumber, int onPage, string searchString)
        {
            var abc = new ProductOptionTariffSearchPattern
            {
                PageNumber = pageNumber,
                OnPage = onPage,
                SearchString = searchString
            };
            SearchResult<ProductOptionTariff> searchResult = await productOptionTariffRepository.Search(abc);

            return Ok(new SearchResult<ProductOptionTariffDto>
            {
                Items = searchResult.Items.Map(),
                TotalCount = searchResult.TotalCount,
                FilteredCount = searchResult.FilteredCount
            });
        }
    }
}
