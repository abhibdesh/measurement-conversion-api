using UnitsConversionModule.Converters;
using Xunit;

namespace UnitsConversionModule.Tests.Converters;

public class VolumeConverterTests
{
    private readonly VolumeConverter _converter;

public VolumeConverterTests()
    {
        _converter = new VolumeConverter();
    }

    [Fact]
    public void Convert_LiterToMilliliter_ReturnsCorrectValue()
    {
        // Arrange
        double value = 2;

        // Act
        double result = _converter.Convert("liter", "milliliter", value);

        // Assert
        Assert.Equal(2000, result);
    }

    [Fact]
    public void Convert_GallonToLiter_ReturnsCorrectValue()
    {
        // Arrange
        double value = 1;

        // Act
        double result = _converter.Convert("gallon", "liter", value);

        // Assert
        Assert.Equal(3.7854, result, 4);
    }

    [Fact]
    public void Convert_SameUnit_ReturnsSameValue()
    {
        // Arrange
        double value = 25;

        // Act
        double result = _converter.Convert("liter", "liter", value);

        // Assert
        Assert.Equal(25, result);
    }

    [Fact]
    public void Convert_InvalidUnit_ThrowsException()
    {
        // Arrange
        double value = 5;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _converter.Convert("liter", "meter", value));
    }

    [Fact]
    public void CanHandle_VolumeCategory_ReturnsTrue()
    {
        // Act
        bool result = _converter.CanHandle("volume");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanHandle_InvalidCategory_ReturnsFalse()
    {
        // Act
        bool result = _converter.CanHandle("weight");

        // Assert
        Assert.False(result);
    }

}
