using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace ImageCreator
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();

            var diag = new FolderBrowserDialog();

            diag.SelectedPath = Directory.GetCurrentDirectory();

            diag.ShowDialog();

            var dir = diag.SelectedPath;

            var imgUrlFormat = "http://lorempixel.com/400/200/food/Picture-{0}/";
            for (int i = 0; i < 15; i++)
            {
                var url = String.Format(imgUrlFormat,i + 1);
                var image = webClient.DownloadData(url);
                var file = File.Create(String.Format("{0}\\{1}.png", dir, i + 1));
                file.Write(image, 0, image.Length);
            }

            Console.ReadLine();
        }
    }
}
