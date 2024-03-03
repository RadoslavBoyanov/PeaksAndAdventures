namespace PeaksAndAdventures.Infrastructure.Data.Enums.Hut
{
    /// <summary>
    /// Enumeration for work time for Hut in seasons
    /// </summary>
    [Flags]
    public enum WorkTime
    {
        None = 0,
        Spring = 1,
        Summer = 2,
        Autumn = 4,
        Winter = 8,

        SpringSummer = Spring | Summer,
        SpringAutumn = Spring | Autumn,
        SummerAutumn = Summer | Autumn,
        SpringWinter = Spring | Winter,
        SummerWinter = Summer | Winter,
        AutumnWinter = Autumn | Winter,

        SpringSummerAutumn = Spring | Summer | Autumn,
        SpringSummerWinter = Spring | Summer | Winter,
        SpringAutumnWinter = Spring | Autumn | Winter,
        SummerAutumnWinter = Summer | Autumn | Winter,

        All = Spring | Summer | Autumn | Winter
    }
}
