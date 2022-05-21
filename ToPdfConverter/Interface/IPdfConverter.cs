namespace ToPdfConverter.Interface
{
    public interface IPdfConverter
    {
        string FilePath { get; set; }
        void ConvertToPdf(string pFilePath, bool pDeleteOldFile);
    }
}
