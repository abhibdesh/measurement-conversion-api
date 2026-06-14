using System;
using UnitsConversionModule.Converters.Interfaces;
using UnitsConversionModule.Services.Interfaces;

namespace UnitsConversionModule.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IEnumerable<IUnitConverter> _converters;

        public ConversionService(IEnumerable<IUnitConverter> converters)
        {
            _converters = converters;
        }

        public double Convert(
        string category,
        string fromUnit,
        string toUnit,
        double value)
        {
            var converter = _converters.FirstOrDefault(c => c.CanHandle(category));

            if (converter is null)
            {
                throw new ArgumentException("Unsupported conversion category.");
            }

            return converter.Convert(fromUnit, toUnit, value);
        }
    }
}
