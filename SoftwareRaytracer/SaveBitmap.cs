using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SoftwareRaytracer
{
    public static class SaveBitmap
    {
        /// <summary>
        /// Saves an image with the specified dimensions and data to the current directory
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="data"></param>
        public static void Save(int width, int height, Microsoft.Xna.Framework.Color[] data)
        {
            Bitmap b = new Bitmap(width, height);
            for (int y = 0; y < Game1.ImageHeight; y++)
            {
                for (int x = 0; x < Game1.ImageWidth; x++)
                {
                    var pixel = data[y * Game1.ImageWidth + x];
                    Color c = Color.FromArgb(pixel.R, pixel.G, pixel.B);
                    b.SetPixel(x, y, c);
                }
            }

            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\img.png", FileMode.Create);
            b.Save(stream, ImageFormat.Png);
            stream.Close();
        }
    }
}
