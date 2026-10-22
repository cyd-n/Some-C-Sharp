
using Spectre.Console;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            AnsiConsole.Clear();

            // App header
            AnsiConsole.Write(
                new FigletText("DREAM WRITER")
                    .Centered()
                    .Color(Color.Blue1));

            AnsiConsole.Write(
                new Rule("[blue]A Writer's Workspace[/]")
                    .RuleStyle("blue"));

            // Navigation menu
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Navigate[/]")
                    .HighlightStyle(new Style(Color.White, Color.DarkBlue))
                    .AddChoices(
                        "Home",
                        "My Documents",
                        "New Document",
                        "Settings",
                        "Exit"));

            // Display the selected page
            switch (choice)
            {
                case "Home":
                    ShowPage("Welcome to Dream Writer!");
                    break;

                case "My Documents":
                    ShowPage("Your documents will appear here.");
                    break;

                case "New Document":
                    CreateDocument();
                    break;

                case "Settings":
                    ShowPage("Application settings.");
                    break;

                case "Exit":
                    running = false;
                    break;
            }
        }

        AnsiConsole.MarkupLine("[blue]Goodbye, writer![/]");
    }

    static void ShowPage(string message)
    {
        AnsiConsole.Clear();

        AnsiConsole.Write(
            new Panel(message)
                .Header("[blue]DREAM WRITER[/]")
                .BorderColor(Color.Blue3)
                .RoundedBorder());

        AnsiConsole.MarkupLine(
            "\n[grey]Press any key to return to navigation...[/]");

        Console.ReadKey(true);
    }

    static void CreateDocument()
    {
        AnsiConsole.Clear();

        string title = AnsiConsole.Ask<string>(
            "[blue]Enter document title:[/]");

        AnsiConsole.MarkupLine(
            $"[green]Document '{Markup.Escape(title)}' created![/]");

        AnsiConsole.MarkupLine(
            "\n[grey]Press any key to return...[/]");

        Console.ReadKey(true);
    }
}
