using System;
using System.ComponentModel;
using Humanizer;
using Humanizer.Inflections;

namespace Demo.Humanizer
{
    class Program
    {
        static void Main(string[] args)
        {

            var strings = new Func<string>[]
            {
                () => "user_not_found",
                () => "user_not_found".Humanize(),
                () => "user_not_found".Humanize(LetterCasing.Sentence),

                () => StatusCode.InProgress.Humanize(),

                () => DateTime.UtcNow.AddDays(-7).Humanize(),
                () => TimeSpan.FromMilliseconds(252000).Humanize(),

                () => "Mohammed Hoque".Camelize(),
                () => "Mohammed Hoque".Underscore(),
                () => "Mohammed Hoque".Dasherize(),
                () => "Mohammed Hoque".Hyphenate(),
                () => "Mohammed Hoque".Kebaberize(),

                () => 1.ToWords()
            };

            foreach (var func in strings)
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
