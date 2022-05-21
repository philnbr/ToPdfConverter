using System;
using ToPdfConverter.Interface;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace ToPdfConverter.Converter
{
    public class TextDocToPdfConverter : IPdfConverter
    {
        public string FilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ConvertToPdf(string pFilePath, bool pDeleteOldFile)
        {
            if (Path.GetExtension(pFilePath) != ".docx" || !File.Exists(pFilePath)) return;

            Document tmpWordDocument = null;

            try
            {
                Application tmpAppWord = new Application();
                tmpWordDocument = tmpAppWord.Documents.Open(pFilePath);
                string tmpDestinationPath = Path.GetDirectoryName(pFilePath) + @"\" + Path.GetFileNameWithoutExtension(pFilePath) + ".pdf";
                tmpWordDocument.ExportAsFixedFormat(tmpDestinationPath, WdExportFormat.wdExportFormatPDF);
                tmpWordDocument.Close();

                if (File.Exists(tmpDestinationPath) &&
                    pDeleteOldFile)
                    File.Delete(pFilePath);
            }
            catch (Exception)
            {
                tmpWordDocument?.Close();
                throw;
            }
        }
    }
}
