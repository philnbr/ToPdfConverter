using ToPdfConverter.Converter;
using ToPdfConverter.Interface;

namespace ToPdfConverter.Factories
{
    public class PictureToPdfFactory : PdfConverterFactory
    {
        public override IPdfConverter GetPdfConverter()
        {
            return new PictureToPdfConverter();
        }
    }
}
