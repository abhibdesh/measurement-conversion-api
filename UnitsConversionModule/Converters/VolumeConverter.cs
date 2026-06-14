using UnitsConversionModule.Converters.Base;

namespace UnitsConversionModule.Converters;

public class VolumeConverter : FactorBasedConverter
{
    protected override string SupportedCategory => Constants.UnitCategories.Volume;

    protected override Dictionary<string, double> ConversionFactors => new()
    {
        { "milliliter", 0.001 },
        { "liter", 1 },
        { "gallon", 3.78541 }
    };
}