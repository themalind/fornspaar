using Fornspar.Importer;

using Spectre.Console;

AnsiConsole.MarkupLine($"Welcome, [blue]First Chosen of the Lord of Light[/]!");

var command = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("What [green]command[/] would you like me to perform?")
        .AddChoices("Import", "Exit"));
  
switch (command)
{
    case "Import":
        var file =
             new FilePicker(new DirectoryInfo(Environment.CurrentDirectory), "*.csv")
                .PickFile();

        AnsiConsole.MarkupLine($"[green]Importing[/] data...");
        break;
    case "Exit":
        AnsiConsole.MarkupLine($"[red]Exiting[/] the program. Farewell!");
        break;
}

