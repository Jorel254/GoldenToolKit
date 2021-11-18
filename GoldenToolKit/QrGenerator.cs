using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GoldenToolKit
{
   public class QrGenerator
    {
        public Bitmap Generator(string name)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(name,QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
