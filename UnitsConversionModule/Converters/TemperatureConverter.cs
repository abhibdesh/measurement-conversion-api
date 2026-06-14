using UnitsConversionModule.Converters.Interfaces;

namespace UnitsConversionModule.Converters;

public class TemperatureConverter : IUnitConverter
{
    public bool CanHandle(string category)
    {
        return category.Equals(
            Constants.UnitCategories.Temperature,
            StringComparison.OrdinalIgnoreCase);
    }

    public double Convert(
        string fromUnit,
        string toUnit,
        double value)
    {
        fromUnit = fromUnit.ToLower();

        toUnit = toUnit.ToLower();

        double celsiusValue = ConvertToCelsius(fromUnit, value);

        double convertedValue = ConvertFromCelsius(toUnit, celsiusValue);

        return Math.Round(convertedValue, 4);
    }

    private double ConvertToCelsius(string fromUnit, double value)
    {
        return fromUnit switch
        {
            "celsius" => value,

            "fahrenheit" => (value - 32) * 5 / 9,

            "kelvin" => value - 273.15,

            _ => throw new ArgumentException(
                "Invalid source temperature unit.")
        };
    }

    private double ConvertFromCelsius(string toUnit, double value)
    {
        return toUnit switch
        {
            "celsius" => value,

            "fahrenheit" => (value * 9 / 5) + 32,

            "kelvin" => value + 273.15,

            _ => throw new ArgumentException(
                "Invalid target temperature unit.")
        };
    }
}