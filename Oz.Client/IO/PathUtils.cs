
using System;
using System.IO;

namespace Oz.Client.IO
{
    public class PathUtils
    {
        public static string GetFileNameOnDesktop(string fileName)
        {
            var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            return Path.Combine(desktopDir, fileName);
        }
    }
}