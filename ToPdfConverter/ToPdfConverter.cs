using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using ToPdfConverter.Factories;
using ToPdfConverter.Interface;

namespace ToPdfConverter
{
    public class ToPdfConverter
    {
        public static void ConvertFileToPdf(string pFilePath)
        {
            if (!File.Exists(pFilePath)) return;

            try
            {
                PdfConverterFactory tmpPdfConverterFactory;

                string tmpFileExtension = Path.GetExtension(pFilePath).ToLower();

                if (IsPicture(tmpFileExtension))
                    tmpPdfConverterFactory = new PictureToPdfFactory();
                else if (tmpFileExtension == ".docx")
                    tmpPdfConverterFactory = new TextDocToPdfFactory();
                else
                {
                    MessageBox.Show("Dateiformat wird nicht unterstützt.");
                    return;
                }

                IPdfConverter tmpPdfConvert = tmpPdfConverterFactory.GetPdfConverter();
                tmpPdfConvert.ConvertToPdf(pFilePath, Properties.Settings.Default.DeleteOldFile);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fehler");
            }
        }

        public static bool IsPicture(string pFileExtension)
        {
            List<string> tmpPictureFormats = new List<string>
            {
                ".jpg",".jpeg", ".png", ".svg", ".jiff"
            };

            return tmpPictureFormats.Contains(pFileExtension);
        }
    }
}