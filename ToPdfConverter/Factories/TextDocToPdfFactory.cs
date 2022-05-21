using ToPdfConverter.Converter;
using ToPdfConverter.Factories;
using ToPdfConverter.Interface;

namespace ToPdfConverter
{
    public class TextDocToPdfFactory : PdfConverterFactory
    {
        public override IPdfConverter GetPdfConverter()
        {
            return new TextDocToPdfConverter();
        }
    }
}
