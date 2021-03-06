/*
 * This class is part of the book "iText in Action - 2nd Edition"
 * written by Bruno Lowagie (ISBN: 9781935182610)
 * For more info, go to: http://itextpdf.com/examples/
 * This example only works with the AGPL version of iText.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Chapter15 {
  public class ExtractPageContent : IWriter {
// ===========================================================================
    /** The original PDF that will be parsed. */
      public readonly string PREFACE = System.IO.Path.Combine(
      Utility.ResourcePdf, "preface.pdf"
    );    
    /** The resulting text file. */
    public const String RESULT = "preface.txt";
// --------------------------------------------------------------------------- 
    public void Write(Stream stream) {
      using (ZipFile zip = new ZipFile()) {
        zip.AddFile(PREFACE, "");
        PdfReader reader = new PdfReader(PREFACE);
        PdfReaderContentParser parser = new PdfReaderContentParser(reader);
        StringBuilder sb = new StringBuilder();
        ITextExtractionStrategy strategy;
        for (int i = 1; i <= reader.NumberOfPages; i++) {
          strategy = parser.ProcessContent(i, new SimpleTextExtractionStrategy());
          sb.AppendLine(strategy.GetResultantText());
        }
        zip.AddEntry(RESULT, sb.ToString());
        zip.Save(stream);             
      }
    }
// ===========================================================================
  }
}