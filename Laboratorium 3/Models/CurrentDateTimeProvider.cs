namespace Laboratorium_3.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
