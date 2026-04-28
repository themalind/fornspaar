using Spectre.Console;

namespace Fornspar.Importer
{
    public class FilePicker
    {
        private readonly DirectoryInfo startDirectory;
        private readonly string fileFilter;

        public FilePicker(DirectoryInfo startDirectory, string fileFilter = "*")
        {
            this.startDirectory = startDirectory;
            this.fileFilter = fileFilter;
        }

        public FileInfo? PickFile(DirectoryInfo? directoryInfo = null)
        {
            if (directoryInfo == null)
            {
                directoryInfo = this.startDirectory;
            }

            var directories = directoryInfo.GetDirectories("*", new EnumerationOptions { ReturnSpecialDirectories = true });
            var files = directoryInfo.GetFiles(this.fileFilter);

            var selectedName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Pick a file")
                    .AddChoices(directories.Select(d => d.Name).Concat(files.Select(f => f.Name))));

            return Directory.Exists(Path.Combine(directoryInfo.FullName, selectedName))
                ? this.PickFile(new DirectoryInfo(Path.Combine(directoryInfo.FullName, selectedName)))
                : new FileInfo(Path.Combine(directoryInfo.FullName, selectedName));
        }
    }
}