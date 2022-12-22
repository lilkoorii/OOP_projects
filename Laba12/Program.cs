using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    internal class Program
    {
        static void Main(string[] args)
        {
                LMPDiskInfo diskInfo = new LMPDiskInfo();
                diskInfo.DiskInfo();

                LMPFileInfo fileInfo = new LMPFileInfo();
                fileInfo.FileData(@"C:\Users\Maria\OOP_projects\Laba12\LMP.cs");

                LMPDirInfo dirInfo = new LMPDirInfo();
                dirInfo.DirInfo(@"C:\Users\Maria\OOP_projects");

                LMPFileManager fileManager = new LMPFileManager();
                fileManager.FileManager(@"C:\Users\Maria\OOP_projects\Laba12");

                LMPLog.SearchByString("FileInfo:");

                Console.ReadKey();
        }
    }
}
