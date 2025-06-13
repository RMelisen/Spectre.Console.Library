using Spectre.Console;
using SpectreConsoleLibrary.Commons.Enums;
using SpectreConsoleLibrary.UI.Commons;
using System;
using System.Collections.Generic;

namespace SpectreConsoleLibrary.UI
{
    internal class MainMenu
    {        
        internal static List<Mushroom> mushrooms;
        internal static void WelcomeUser()
        {
            mushrooms = new List<Mushroom>
            {
                new Mushroom(1, "Shiitake", "A popular edible mushroom, native to East Asia. Often used in Japanese and Chinese cuisine.", true),
                new Mushroom(2, "Amanita Muscaria", "Known as fly agaric. A poisonous and psychoactive basidiomycete fungus.", false),
                new Mushroom(3, "Portobello", "A large, dark brown mushroom, often used as a meat substitute due to its texture.", true),
                new Mushroom(4, "Death Cap", "Extremely poisonous and responsible for the majority of mushroom fatalities worldwide. Resembles several edible species.", false),
                new Mushroom(5, "Chanterelle", "A popular wild mushroom with a distinctive funnel shape and fruity aroma, highly prized by chefs.", true)
            };

            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR} Bold]Welcome to my Spectre Console Library demo app ![/]\n");
            AnsiConsole.MarkupLine("");

            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
            AnsiConsole.Clear();
        }

        internal static void ShowMainMenu()
        {
            bool shouldLoopMainMenu = true;
            MainMenuOption mainMenuChoice;

            while (shouldLoopMainMenu)
            {
                mainMenuChoice = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOption>().Title($"What do you want to do ?").AddChoices(Enum.GetValues<MainMenuOption>()));

                switch (mainMenuChoice)
                {
                    case MainMenuOption.ViewMarkup:
                        ViewMarkupSamples();
                        break;
                    case MainMenuOption.ViewTable:
                        ViewTableSamples();
                        break;
                    case MainMenuOption.AskInput:
                        AskInput();
                        break;
                    case MainMenuOption.Canvas:
                    case MainMenuOption.Quit:
                        shouldLoopMainMenu = false;
                        break;
                }
                AnsiConsole.Clear();
            }
            AnsiConsole.MarkupLine($"[Bold]See you soon ![/]");
        }

        private static void ViewMarkupSamples()
        {
            AnsiConsole.Clear();

            foreach (Mushroom mushroom in mushrooms)
            {
                AnsiConsole.MarkupLine($"{mushroom.ToString()}");
            }

            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
        }

        private static void ViewTableSamples()
        {
            Table sampleTable = new Table();
            sampleTable.Border(TableBorder.Rounded);

            sampleTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Id[/]");
            sampleTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Name[/]");
            sampleTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Description[/]");
            sampleTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Edible[/]");

            // Populate rows
            foreach (Mushroom mushroom in mushrooms)
            {
                sampleTable.AddRow(mushroom.Id.ToString(), mushroom.Name, mushroom.Description, mushroom.Edible.ToString());
            }

            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR} Bold]Mushrooms :[/]");
            AnsiConsole.Write(sampleTable);
            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
        }

        private static void AskInput()
        {
            AnsiConsole.Clear();

            string name = AnsiConsole.Ask<string>($"Enter an mushroom [{UIStyles.NEUTRAL_INDICATOR_COLOR}]name[/] : ");
            int price = AnsiConsole.Ask<int>($"Enter the mushroom [{UIStyles.NEUTRAL_INDICATOR_COLOR}]price[/] : ");

            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR} Bold]Mushrooms name and price:[/] {name} - {price}");

            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
        }
    }


    internal class Mushroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Edible{ get; set; }

        public Mushroom(int id, string name, string description, bool edible)
        {
            Id = id;
            Name = name;
            Description = description;
            Edible = edible;
        }
        public override string ToString()
        {
            return $"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Mushroom ID[/]: {Id}, [{UIStyles.NEUTRAL_INDICATOR_COLOR}]Name[/]: {Name}, [{UIStyles.NEUTRAL_INDICATOR_COLOR}]Edible[/]: {Edible}, [{UIStyles.NEUTRAL_INDICATOR_COLOR}]Description[/]: '{Description.Substring(0, Math.Min(Description.Length, 20))}...'";
        }
    }
}
