using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using ToPdfConverter.Interface;

namespace ToPdfConverter.Converter
{
    public class PictureToPdfConverter : IPdfConverter
    {
        public string FilePath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void ConvertToPdf(string pFilePath, bool pDeleteOldFile)
        {
            if (!File.Exists(pFilePath)) return;

            string tmpDestinationPath = Path.GetDirectoryName(pFilePath) + @"\" + Path.GetFileNameWithoutExtension(pFilePath) + ".pdf";

            using (var srcImage = new System.Drawing.Bitmap(pFilePath))
            {
               Rectangle tmpPageSize = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            
               using (MemoryStream tmpMemoryStream = new MemoryStream())
               {
                   Document tmpDocument = new Document(tmpPageSize, 0, 0, 0, 0);
                   PdfWriter.GetInstance(tmpDocument, tmpMemoryStream).SetFullCompression();
                   tmpDocument.Open();
                   Image image = Image.GetInstance(pFilePath);
                   tmpDocument.Add(image);
                   tmpDocument.Close();
            
                   File.WriteAllBytes(tmpDestinationPath, tmpMemoryStream.ToArray());
               }
            }

            if (File.Exists(tmpDestinationPath) &&
                pDeleteOldFile)
                File.Delete(pFilePath);
        }
    }
}
