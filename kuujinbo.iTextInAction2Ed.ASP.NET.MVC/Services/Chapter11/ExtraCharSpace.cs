/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System;
using System.IO;
using Ionic.Zip;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter11 {
  public class ExtraCharSpace : IWriter {
// ===========================================================================
    /** A movie title. */
    public const string MOVIE = "Aanrijding in Moscou";      
// ---------------------------------------------------------------------------
    public void Write(Stream stream) {
      // step 1
      using (Document document = new Document()) {
        // step 2
        PdfWriter.GetInstance(document, stream);
        // step 3
        document.Open();
        // step 4
        BaseFont bf1 = BaseFont.CreateFont(
          "c:/windows/fonts/arial.ttf",
          BaseFont.CP1252, BaseFont.EMBEDDED
        );
        Font font1 = new Font(bf1, 12);
        document.Add(new Paragraph("Movie title: Moscou, Belgium", font1));
        document.Add(new Paragraph(
          "directed by Christophe Van Rompaey", font1
        ));
        Chunk chunk = new Chunk(MOVIE, font1);
        chunk.SetCharacterSpacing(10);
        document.Add(new Paragraph(chunk));
      }
    }
// ===========================================================================
  }
}