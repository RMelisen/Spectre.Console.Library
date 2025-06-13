using Spectre.Console;
using SpectreConsoleLibrary.UI.Commons;

namespace SpectreConsoleLibrary.UI
{
    internal class MainMenu
    {        
        internal static void WelcomeUser()
        {
            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR} Bold]Welcome to my Spectre Console Library demo app ![/]\n");
            AnsiConsole.MarkupLine("");

            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
        }
    }
}
