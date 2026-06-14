using Microsoft.AspNetCore.Mvc;
using UnitsConversionModule.Models.Requests;
using UnitsConversionModule.Models.Responses;
using UnitsConversionModule.Services.Interfaces;

namespace UnitsConversionModule.Controllers
{
    [ApiController]
    [Route("api/v1/conversions")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public IActionResult Convert(ConversionRequest request)
        {
            double result = _conversionService.Convert(
                request.Category,
                request.FromUnit,
                request.ToUnit,
                request.Value);

            var response = new ConversionResponse
            {
                Category = request.Category,
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit,
                OriginalValue = request.Value,
                ConvertedValue = result
            };

            return Ok(response);
        }
    }
}