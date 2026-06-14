using UnitsConversionModule.Converters;
using Xunit;

namespace UnitsConversionModule.Tests.Converters;

public class LengthConverterTests
{
    private readonly LengthConverter _converter;

public LengthConverterTests()
    {
        _converter = new LengthConverter();
    }

    [Fact]
    public void Convert_MeterToFeet_ReturnsCorrectValue()
    {
        // Arrange
        double value = 1;

        // Act
        double result = _converter.Convert("meter", "feet", value);

        // Assert
        Assert.Equal(3.2808, result, 4);
    }

    [Fact]
    public void Convert_KilometerToMeter_ReturnsCorrectValue()
    {
        // Arrange
        double value = 2;

        // Act
        double result = _converter.Convert("kilometer", "meter", value);

        // Assert
        Assert.Equal(2000, result);
    }

    [Fact]
    public void Convert_SameUnit_ReturnsSameValue()
    {
        // Arrange
        double value = 50;

        // Act
        double result = _converter.Convert("meter", "meter", value);

        // Assert
        Assert.Equal(50, result);
    }

    [Fact]
    public void Convert_InvalidUnit_ThrowsException()
    {
        // Arrange
        double value = 10;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _converter.Convert("meter", "liter", value));
    }

    [Fact]
    public void CanHandle_LengthCategory_ReturnsTrue()
    {
        // Act
        bool result = _converter.CanHandle("length");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanHandle_InvalidCategory_ReturnsFalse()
    {
        // Act
        bool result = _converter.CanHandle("temperature");

        // Assert
        Assert.False(result);
    }

}
