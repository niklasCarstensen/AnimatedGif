using System.Drawing;

namespace AnimatedGif.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 33ms delay (~30fps)
            using (var gif = AnimatedGif.Create("gif.gif", 33))
            {
                var img1 = Image.FromFile("001.jpg");
                gif.AddFrame(img1, delay: -1, quality: GifQuality.Bit8);
                var img2 = Image.FromFile("002.jpg");
                gif.AddFrame(img2, delay: -1, quality: GifQuality.Bit8);
                var img3 = Image.FromFile("003.jpg");
                gif.AddFrame(img3, delay: -1, quality: GifQuality.Bit8);
            }
        }
    }
}
