
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoldenToolKit
{
    public class PDFActions
    {
        public string ReadPDF(string file)
        {

            string line = "";
            if (File.Exists(file))
            {
                file = file.Replace("\\", "/");
                PdfReader reader = new PdfReader(file);
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                    line = PdfTextExtractor.GetTextFromPage(reader, page, its);
                    line = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(line)));
                    reader.Close();
                }
                return line;
            }
            return "";
        }
    }
}
