using UnitsConversionModule.Converters.Base;

namespace UnitsConversionModule.Converters;

public class WeightConverter : FactorBasedConverter
{
    protected override string SupportedCategory => Constants.UnitCategories.Weight;

    protected override Dictionary<string, double> ConversionFactors => new()
    {
        { "milligram", 0.000001 },
        { "gram", 0.001 },
        { "kilogram", 1 },
        { "pound", 0.453592 }
    };
}