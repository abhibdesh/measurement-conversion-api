namespace UnitsConversionModule.Converters.Interfaces
{
    public interface IUnitConverter
    {
        bool CanHandle(string category);

        double Convert(string fromUnit, string toUnit, double value);
    }
}
