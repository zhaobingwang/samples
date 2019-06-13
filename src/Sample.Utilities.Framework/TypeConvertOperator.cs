using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utilities.Framework
{
    public class TypeConvertOperator
    {
        public string ConvertBitmapToBase64String(Bitmap bitmap, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, imageFormat);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            var result = Convert.ToBase64String(arr);
            return result;
        }

        public Image ConvertBase64StringToImage(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length);
            ms.Write(bytes, 0, bytes.Length);
            Image image = Image.FromStream(ms);
            ms.Close();
            return image;
        }
    }
}
