using System;
using System.ComponentModel;
using Humanizer;
using Humanizer.Inflections;

namespace Demo.Humanizer
{
    /// <summary>
    /// ORIGINAL SOURCE:
    /// https://github.com/Humanizr/Humanizer
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            var funcs = new Func<string>[]
            {
                #region Humanize String
                () => "user_not_found",
                () => "user_not_found".Humanize(),
                () => "user_not_found".Humanize(LetterCasing.Sentence),
                () => "Mohammed Hoque".Camelize(),
                () => "Mohammed Hoque".Underscore(),
                () => "Mohammed Hoque".Dasherize(),
                () => "Mohammed Hoque".Hyphenate(),
                () => "Mohammed Hoque".Kebaberize(),
                // acronyms are left intact
                () => "HTML".Humanize(),
                // any unbroken upper case string is treated as an acronym
                () => "HUMANIZER".Transform(To.LowerCase, To.TitleCase),
                () => "Long text to truncate".Truncate(15, "..."),
                #endregion Humanize String

                () => StatusCode.InProgress.Humanize(),

                #region DateTime
                () => DateTime.UtcNow.AddDays(-7).Humanize(),
                () => DateTime.Today.AtNoon().Humanize(),
                () => DateTime.Today.AtMidnight().Humanize(),
                () => DateTime.Today.At(4, 20, 15).Humanize(),
                () => new DateTime(2005, 5, 5).ToOrdinalWords(),

                () => TimeSpan.FromMilliseconds(252000).Humanize(),  

                () => In.AprilOf(2022).Humanize(),
                () => In.Three.Months.Humanize(),
                () => On.July.The4th.Humanize(),
                () => On.July.The(4).Humanize(),
                #endregion DateTime


                () => 10000.ToWords(),
                () => 1.25.Billions().ToString(),
                () => 11.ToOrdinalWords(),
                () => 11.ToRoman(),
            };

            foreach (var func in funcs)
            {
                Console.WriteLine(func());
            }
        }

        enum StatusCode : ushort
        {
            [Description("Order Received")]
            Received = 0,
            [Description("Processing Order")]
            InProgress = 1,
            [Description("Failed to Complete")]
            Failed = 500,
            [Description("Completed Order")]
            Completed = 2
        }
    }
}
