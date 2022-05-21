using ToPdfConverter.Interface;

namespace ToPdfConverter.Factories
{
    public abstract class PdfConverterFactory
    {
        public abstract IPdfConverter GetPdfConverter();
    }
}
