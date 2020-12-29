using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace LabRab13
{
    class Program
    {
        static void Main(string[] args)
        {

            BVOLog.WriteLog(BVODiskInfo.FreePlaceDiskInfo());
            BVOLog.WriteLog(BVOFileInfo.MethodFileInfo());
            BVOLog.WriteLog(BVODirInfo.BVODirInfoMethod());
            BVOFileManager.FileAndDirectoryWorkMethod();
            BVOFileManager.FileAndDirectoryWorkMethodTwo();
            BVOFileManager.Compress();
            BVOFileManager.Decompress();
            //ViewBVOLogFile.ViewBVOLogFileMethod();
            //BVOLog.ReadLog(); //Читает файл
            Console.Read();
        }
        static class BVOLog
        {
            static string address = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt";
            public static void WriteLog(string text)
            {
                try
                {

                    FileInfo fileInfo = new FileInfo(address);
                    fileInfo.Refresh();

                    var name = fileInfo.Name;
                    var fullName = fileInfo.FullName;
                    var creationTime = fileInfo.CreationTime;
                    var lastAccessTime = fileInfo.LastAccessTime;
                    if (!System.IO.File.Exists("BVOlogfile.txt"))
                    {
                        using (StreamWriter sw = new StreamWriter(address, false, Encoding.UTF8))
                        {
                            sw.WriteLine($"Имя файла: {name}");
                            sw.WriteLine($"Полный путь: {fullName}");
                            sw.WriteLine($"Дата и время создания файла: {creationTime}");
                            sw.WriteLine($"Дата и время последнего изменения файла пользователем: {lastAccessTime}");
                            sw.WriteLine("*****************************************************************************");
                            sw.Write(text);
                            sw.Write("\n\n");
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(address, true, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine($"Имя файла: {name}");
                            sw.WriteLine($"Полный путь: {fullName}");
                            sw.WriteLine($"Дата и время создания файла: {creationTime}");
                            sw.WriteLine($"Дата и время последнего изменения файла пользователем: {lastAccessTime}");
                            sw.WriteLine("*****************************************************************************");
                            sw.Write(text);
                            sw.Write("\n\n");
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            public static void ReadLog()
            {
                try
                {
                    using (StreamReader sr = new StreamReader(address, System.Text.Encoding.UTF8))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static class BVODiskInfo
        {
            public static string FreePlaceDiskInfo()
            {
                string text = "";
                DriveInfo[] drives = DriveInfo.GetDrives();
                try
                {
                    foreach (var drive in drives)
                    {
                        Console.WriteLine($"\n" +
                            $"Объем доступного места на диске:\n{drive.Name} {drive.AvailableFreeSpace} байт");
                        Console.WriteLine($"Файловая система: {drive.DriveFormat}");
                        Console.WriteLine($"Общий доступный объем места на диске: {drive.TotalFreeSpace} байт");
                        Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                        Console.WriteLine($"Oбщий размер диска в байтах: {drive.TotalSize} байт");
                        text += $"\nОбъем доступного места на диске:\n{drive.Name} {drive.AvailableFreeSpace} байт\n" +
                            $"Файловая система: {drive.DriveFormat}\n" +
                            $"Общий доступный объем места на диске: {drive.TotalFreeSpace} байт\n" +
                            $"Метка тома: {drive.VolumeLabel}\n" +
                            $"Oбщий размер диска в байтах: {drive.TotalSize} байт\n";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return text;

            }
        }
        public static class BVOFileInfo
        {
            public static string MethodFileInfo()
            {
                FileInfo fileInfo = new FileInfo(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt");
                Console.WriteLine($"\nИмя файла: {fileInfo.Name}");
                Console.WriteLine($"Полный путь: {fileInfo.DirectoryName}");
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт");
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
                Console.WriteLine($"Дата и время создания файла: {fileInfo.CreationTime}");

                return $"\nИмя файла: {fileInfo.Name}\n" +
                    $"Полный путь: {fileInfo.DirectoryName}\n" +
                    $"Размер файла: {fileInfo.Length}\n байт" +
                    $"Расширение файла: {fileInfo.Extension}\n" +
                    $"Дата и время создания файла: {fileInfo.CreationTime}\n";
            }
        }
        public static class BVODirInfo
        {
            public static string BVODirInfoMethod()
            {
                string text = "";
                string[] files = Directory.GetFiles("C:\\");
                Console.WriteLine($"\n" +
                    $"Количество файлов: {files.Length}");
                text += $"\nКоличество файлов: {files.Length}";
                var time = Directory.GetCreationTime("C:\\");
                Console.WriteLine($"Дата создания каталога C: {time}");
                text += $"\nДата создания каталога C: {time}";
                string[] dirs = Directory.GetDirectories("C:\\");
                Console.WriteLine($"Количество подкаталогов каталога  C = {dirs.Length}");
                text += $"\nКоличество подкаталогов каталога  C = {dirs.Length}";
                var parent = Directory.GetParent("C:\\");
                Console.WriteLine($"Родительский каталог каталога C: {parent}");
                text += $"\nРодительский каталог каталога C: {parent}";
                return text;
            }
        }
        public static class BVOFileManager
        {
            public static void FileAndDirectoryWorkMethod()
            {
                string[] listFiles = Directory.GetFiles("C:\\");
                string[] listDirectories = Directory.GetDirectories("C:\\");
                string path = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect";
                string address = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect\bvodirinfo.txt";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    Console.WriteLine("Директорий создан");
                }
                try
                {
                    using (StreamWriter sw = new StreamWriter(address, false, Encoding.Default))
                    {
                        sw.WriteLine("Some information");
                        sw.Close();
                    }
                }
                catch
                {

                }
                string newPath = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\info.txt";
                FileInfo fileInf = new FileInfo(address);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                    fileInf.Delete();
                }

            }
            public static void FileAndDirectoryWorkMethodTwo()
            {
                string path = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOFiles";
                string address = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect\BVOFiles";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    Console.WriteLine("Директорий создан");
                }
                string[] files = Directory.GetFiles(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\", "*.txt");

                foreach (var s in files)
                {
                    FileInfo info = new FileInfo(s);

                    if (info.Exists)
                    {
                        info.CopyTo(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOFiles\" + info.Name, true);
                    }
                }
                DirectoryInfo del = new DirectoryInfo(address);
                del.Create();
                del.Delete();

                dirInfo.MoveTo(address);
            }
            internal static void Compress()
            {
                string zipPath = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect\BVOFiles.zip";
                string address = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect\BVOFiles";
                ZipFile.CreateFromDirectory(address, zipPath);

            }
            public static void Decompress()
            {
                string zipPath = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOInspect\BVOFiles.zip";
                string extractPath = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOFiles";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }

    }
    //public static class ViewBVOLogFile
    //{
    //    public static void ViewBVOLogFileMethod()
    //    {
    //        string str = " ";
    //        Console.WriteLine("\nЧтение\n");
    //        FileInfo fileInfo = new FileInfo(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt");
    //        using (StreamReader streamReader = new StreamReader(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt", Encoding.GetEncoding(1251)))
    //        {
    //            Console.WriteLine();

    //            //  string stroka = streamReader.ReadToEnd();
    //            //  Console.WriteLine(stroka);
    //            int i = 0;
    //            foreach (string s in File.ReadLines(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt"))
    //            {
    //                if (s.IndexOf("Дата и время создания файла: 18.12.2019 2") == 0 || i > 0)
    //                {
    //                    str += s + "\n";
    //                    i++;
    //                }

    //            }
    //            Console.WriteLine("В файле {0} записей", i);
    //            Console.WriteLine("Вывод со строки\n");
    //            Console.WriteLine(str);
    //        }
    //        File.Delete(@"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt");
    //        string address = @"C:\Users\User\Documents\labs2K\LabRab13\bin\Debug\BVOlogfile.txt";
    //        using (StreamWriter streamReader = new StreamWriter(address, true, System.Text.Encoding.UTF8))
    //        {
    //            streamReader.WriteLine(str);
    //        }
    //    }
    //}
}

