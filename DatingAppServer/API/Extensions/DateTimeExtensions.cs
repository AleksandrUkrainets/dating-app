namespace API.Extensions;

public static class DateTimeExtensions
{
    public static int AgeCalculate(this DateOnly birdthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - birdthDate.Year;

        if (birdthDate > today.AddYears(-age)) age--;

        return age;
    }
}
