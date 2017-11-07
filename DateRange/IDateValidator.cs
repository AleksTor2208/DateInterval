
namespace DateRange
{
    public interface IDateValidator
    {
        string ErrorMessage { get; set; }
        bool IsValid(string startDate, string endDate);
       
    }
}
