using UnitsConversionModule.Converters.Base;

namespace UnitsConversionModule.Converters;

public class LengthConverter : FactorBasedConverter
{
    protected override string SupportedCategory => Constants.UnitCategories.Length;
        
    protected override Dictionary<string, double> ConversionFactors => new()
    {
        { "millimeter", 0.001 },
        { "centimeter", 0.01 },
        { "decimeter", 0.1 },
        { "meter", 1 },
        { "kilometer", 1000 },
        { "feet", 0.3048 },
        { "mile", 1609.34 }
    };
}