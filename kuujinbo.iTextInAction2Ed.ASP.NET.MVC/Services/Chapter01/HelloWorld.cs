/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter01
{
    public class HelloWorld : IWriter
    {
        // ===========================================================================
        public void Write(Stream stream)
        {
            // step 1
            using (Document document = new Document())
            {
                // step 2
                PdfWriter.GetInstance(document, stream);
                // step 3
                document.Open();
                // step 4
                document.Add(new Paragraph("Hello World!"));
            }
        }
        // ===========================================================================
    }
}