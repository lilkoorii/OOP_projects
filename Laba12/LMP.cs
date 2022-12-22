using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    public static class LMPLog
    {
        public const string sourceFile = @"C:\Users\Maria\OOP_projects\Laba12\lmplogfile.txt";
        static LMPLog() //очистка файла
        {
            using (StreamWriter w = new StreamWriter(sourceFile, false))
            {
                w.WriteLine(DateTime.Now);
            }
        }
        public static void WriteLine(string str)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(sourceFile, true))
                {
                    w.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public static void SearchByString(string str)
        {
            using (StreamReader sr = new StreamReader(sourceFile, false))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine().StartsWith(str))
                        Console.WriteLine(sr.ReadLine());
                }
            }
        }

    }

    public class LMPDiskInfo
    {
        public void DiskInfo()
        {
            LMPLog.WriteLine("DiskInfo:");
            DriveInfo[] drives = DriveInfo.GetDrives(); //получение массива дисков
            foreach (DriveInfo drive in drives)
            {
                LMPLog.WriteLine("\tName: " + drive.Name);
                LMPLog.WriteLine("\tType: " + drive.DriveType);
                if (drive.IsReady)
                {
                    LMPLog.WriteLine("\tFileSystem: " + drive.DriveFormat);
                    LMPLog.WriteLine($"\tFreeSpace: total - {drive.TotalFreeSpace / 1000 / 1000 / 1000} GB, available - {drive.AvailableFreeSpace / 1024 / 1024 / 1024} GB");
                    LMPLog.WriteLine($"\tTotalSize: {drive.TotalSize / 1024 / 1024 / 1024} GB");
                    LMPLog.WriteLine("\tVolumeLabel: " + drive.VolumeLabel);
                }
                LMPLog.WriteLine("");
            }
        }
    }


    public class LMPFileInfo
    {
        public void FileData(string path)
        {
            LMPLog.WriteLine("FileInfo:");
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                LMPLog.WriteLine($"\tFull way : {fileInf.DirectoryName}");
                LMPLog.WriteLine($"\tName: {fileInf.Name}");
                LMPLog.WriteLine($"\tCapacity: {fileInf.Length}\n\tExtension: {fileInf.Extension}\n\tCreationTime: {fileInf.CreationTime}");
            }
            else
            {
                LMPLog.WriteLine("This file doesn't exists");
            }
        }
    }

    public class LMPDirInfo
    {
        public void DirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            LMPLog.WriteLine("\nDirInfo:");

            LMPLog.WriteLine($"\tFilesCount: {dirInfo.GetFiles().Count()}");
            LMPLog.WriteLine($"\tCreateon time: {dirInfo.CreationTime}");
            LMPLog.WriteLine($"\tSubDirectories: {dirInfo.GetDirectories("*", SearchOption.AllDirectories).Count()}");
            LMPLog.WriteLine($"\tParents: {dirInfo.Parent}");
        }
    }

    public class LMPFileManager
    {
        public void FileManager(string path)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(path);
                DirectoryInfo dirInfo = Directory.CreateDirectory(driveInfo.Name + "LMPInspect");
                using (StreamWriter writer = File.CreateText(dirInfo.FullName + "\\lmpdirinfo.txt"))
                {
                    writer.WriteLine("This is information");
                }
                File.Copy(dirInfo.FullName + "\\lmpdirinfo.txt", dirInfo.FullName + "\\copied.txt");
                File.Delete(dirInfo.FullName + "\\lmpdirinfo.txt");


                using (StreamWriter writer = File.CreateText(dirInfo.FullName + "\\lmpdirinfo.txt"))
                {
                    writer.WriteLine("This is information");
                }
                File.Copy(dirInfo.FullName + "\\lmpdirinfo.txt", dirInfo.FullName + "\\copied.txt");
                File.Delete(dirInfo.FullName + "\\lmpdirinfo.txt");



                DirectoryInfo dirInfo1 = Directory.CreateDirectory(driveInfo.Name + "LMPFiles");
                DirectoryInfo currentDirectory = new DirectoryInfo("./");
                foreach (var item in currentDirectory.GetFiles())
                    item.CopyTo(dirInfo1.FullName + "\\" + item.Name, true);
                dirInfo1.MoveTo(dirInfo.FullName + "\\" + dirInfo1.Name);



                string dirpath = @"LMPInspect\LMPFiles";
                string zippath = @"LMPInspect\LMPFiles.zip";
                string unzippath = @"Unzipped";

                //ZipFile.CreateFromDirectory(dirpath, zippath);
                //ZipFile.ExtractToDirectory(zippath, unzippath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
