using UnitsConversionModule.Converters.Interfaces;

namespace UnitsConversionModule.Converters.Base;

public abstract class FactorBasedConverter : IUnitConverter
{
    protected abstract Dictionary<string, double> ConversionFactors { get; }

    protected abstract string SupportedCategory { get; }

    public bool CanHandle(string category)
    {
        return category.Equals(
            SupportedCategory,
            StringComparison.OrdinalIgnoreCase);
    }

    public virtual double Convert(
        string fromUnit,
        string toUnit,
        double value)
    {
        fromUnit = fromUnit.ToLower();

        toUnit = toUnit.ToLower();

        if (!ConversionFactors.ContainsKey(fromUnit) ||
            !ConversionFactors.ContainsKey(toUnit))
        {
            throw new ArgumentException(
                $"Invalid units for {SupportedCategory} conversion.");
        }

        double baseValue = value * ConversionFactors[fromUnit];

        double convertedValue = baseValue / ConversionFactors[toUnit];

        return Math.Round(convertedValue, 4);
    }
}