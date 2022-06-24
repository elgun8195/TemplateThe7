using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace The_7.Helpers
{
    public static class Helper
    {
        public static void DeleteImage(string filename ,string folder, IWebHostEnvironment env)
        {
            string path = env.WebRootPath;
            string result=Path.Combine(filename, folder,path);
            if (System.IO.File.Exists(result))
            {
                System.IO.File.Delete(result);
            }
        }
    }
}
