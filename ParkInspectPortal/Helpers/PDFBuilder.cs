using System;
using System.IO;
using System.Web.Hosting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using RazorEngine;

namespace ParkInspectPortal.Helpers
{
    public class PDFBuilder : IDisposable
    {
        private string _templatePath;
        private MemoryStream _memoryStream;
        private bool _initialized = false;

        public PDFBuilder(string templatePath = null)
        {
            _memoryStream = new MemoryStream();

            _templatePath = templatePath;
        }

        public string MapPath(string path)
        {
            var fullPath = HostingEnvironment.MapPath(path);

            var folderPath = fullPath.Substring(0, fullPath.LastIndexOf(@"\"));

            Directory.CreateDirectory(folderPath);

            return fullPath;
        }

        public Stream GetPdfStream()
        {
            var bytes = GetPdfBytes();

            return new MemoryStream(bytes);
        }

        public byte[] GetPdfBytes()
        {
            return _memoryStream.ToArray();
        }

        public void AddHtml<T>(T model, string viewPath, float topMargin = 36, float rightMargin = 36, float bottomMargin = 36, float leftMargin = 36)
        {
            var html = GetHtml(viewPath, model);

            AddHtml(html, topMargin, rightMargin, bottomMargin, leftMargin);
        }

        public void SendPageBreak()
        {
            AddHtml("<div style=\"page-break-before:always\">&nbsp;</div>");
        }

        private void AddHtml(string html, float topMargin = 0, float rightMargin = 0, float bottomMargin = 0, float leftMargin = 0)
        {
            Rectangle size = null;

            PdfReader templateReader = null;

            if (IsTemplated)
            {
                templateReader = new PdfReader(_templatePath);
            }

            Rectangle docSize;


            using (var doc = new Document(PageSize.A4, leftMargin, rightMargin, topMargin, bottomMargin))
            {
                using (var writer = PdfWriter.GetInstance(doc, _memoryStream))
                {
                    doc.Open();

                    try
                    {
                        using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                        {
                            var instance = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();

                            instance.ParseXHtml(writer, doc, msHtml, System.Text.Encoding.UTF8);
                        }

                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }

            // add pages from template, if any
            if (IsTemplated && templateReader != null && templateReader.NumberOfPages >= 1)
            {
                // re-set memorystream

                try
                {
                    using (var doc = new Document())
                    {
                        using (var targetStrm = new MemoryStream())
                        {
                            using (var writer = PdfWriter.GetInstance(doc, targetStrm))
                            {
                                doc.Open();

                                using (var sourceReader = new PdfReader(GetPdfBytes()))
                                {
                                    for (var pagenum = 1; pagenum <= sourceReader.NumberOfPages; pagenum++)
                                    {
                                        doc.NewPage();

                                        // write template page, if it exists
                                        var templatePage = writer.GetImportedPage(templateReader, pagenum);

                                        if (templatePage != null)
                                        {
                                            writer.DirectContent.AddTemplate(templatePage, 0, 0);
                                        }

                                        // write document page
                                        var page = writer.GetImportedPage(sourceReader, pagenum);

                                        writer.DirectContent.AddTemplate(page, 0, 0);

                                    }
                                    doc.Close();
                                }

                            }

                            _memoryStream = new MemoryStream(targetStrm.ToArray());
                        }
                    }
                }
                catch (Exception)
                {
                    // swallow
                }
            }
        }

        private string GetHtml<T>(string viewpath, T model)
        {
            var html = File.ReadAllText(viewpath);

            return Razor.Parse(html, model);
        }

        public void Dispose()
        {
            _memoryStream?.Dispose();

            _memoryStream = null;
        }

        private bool IsTemplated => !string.IsNullOrWhiteSpace(_templatePath);
    }

}


