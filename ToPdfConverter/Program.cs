namespace ToPdfConverter
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main(string[] args)
        {
            ToPdfConverter.ConvertFileToPdf(args[0]);
        }
    }
}
