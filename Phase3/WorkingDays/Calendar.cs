namespace WorkingDays;

public static class Calendar
{
    public static IEnumerable<DateOnly> WorkingDays(DateOnly start, IReadOnlySet<DateOnly> holidays)
    {
        ArgumentNullException.ThrowIfNull(holidays);

        return Iterate();

        IEnumerable<DateOnly> Iterate()
        {
            for (var day = start; ; day = day.AddDays(1))
            {
                if (day.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                    continue;

                if (holidays.Contains(day))
                    continue;

                yield return day;
            }
        }
    }
}