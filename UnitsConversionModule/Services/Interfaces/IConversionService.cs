namespace UnitsConversionModule.Services.Interfaces
{
    public interface IConversionService
    {
        double Convert(
        string category,
        string fromUnit,
        string toUnit,
        double value);
    }
}
