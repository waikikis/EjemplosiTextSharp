/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter14 {
  public class Text2ToPdf3 : IWriter {
// ===========================================================================
    public void Write(Stream stream) {
      throw new NotImplementedException(
        "iTextSharp does not implement Java Graphics2D class"
      );
    }
// ===========================================================================
  }
}