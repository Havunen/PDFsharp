﻿// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf.Annotations;

namespace PdfSharp.Pdf.Signatures
{
    internal class DefaultSignatureAppearanceHandler : IAnnotationAppearanceHandler
    {
        public string? Location { get; set; }
        public string? Reason { get; set; }
        public string? Signer { get; set; }


        public void DrawAppearance(XGraphics gfx, XRect rect)
        {
            var backColor = XColor.Empty;
            var defaultText = string.Format("Signed by: {0}\nLocation: {1}\nReason: {2}\nDate: {3}", Signer, Location, Reason, DateTime.Now);

            XFont font = new XFont("Verdana", 7, XFontStyleEx.Regular);

            XTextFormatter txtFormat = new XTextFormatter(gfx);

            var currentPosition = new XPoint(0, 0);

            txtFormat.DrawString(defaultText,
                font,
                new XSolidBrush(XColor.FromKnownColor(XKnownColor.Black)),
                new XRect(currentPosition.X, currentPosition.Y, rect.Width - currentPosition.X, rect.Height),
                XStringFormats.TopLeft);
        }
    }
}
