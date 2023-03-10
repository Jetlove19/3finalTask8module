using System;
using System.IO;

namespace _3finalTask8module
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToDirectory = @"\Users\Jetlove\Desktop\DeleteFiles30";
            double catalogSize = 0;
            double catalogSize2 = 0;
            catalogSize = SizeFolder(pathToDirectory, ref catalogSize);
            Console.WriteLine("Исходный размер {0} составляет {1} байт ", pathToDirectory, catalogSize);
            DelCatalogs30();
            SizeFolder2(pathToDirectory, ref catalogSize2);
            Console.WriteLine("Удалено {0} байт ", catalogSize - catalogSize2);
            Console.WriteLine("Текущий размер {0} составляет {1} байт ", pathToDirectory, catalogSize2);


            static void DelCatalogs30()
            {
                var DelFailDir = new DirectoryInfo("C:/Users/Dzh/Desktop/Папка для 8 модуля");
                if (DelFailDir.Exists)
                {
                    foreach (FileInfo file in DelFailDir.GetFiles())
                    {
                        var timeSpan = file.LastAccessTime;
                        var timeSpan1 = DateTime.Now;
                        var timeSpan2 = TimeSpan.FromMinutes(30);
                        var duras = timeSpan1 - timeSpan;
                        if (duras >= timeSpan2)
                        { file.Delete(); }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нет файлов,которые не используются более 30 мин.");
                            Console.WriteLine($"Прошло {duras} времени");
                            break;
                        }
                    }
                    foreach (DirectoryInfo dir in DelFailDir.GetDirectories())
                    {
                        var timeSpan = dir.LastAccessTime;
                        var timeSpan1 = DateTime.Now;
                        var timeSpan2 = TimeSpan.FromMinutes(30);
                        var duras = timeSpan1 - timeSpan;
                        if (duras >= timeSpan2)
                        {
                            dir.Delete(true);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нет папок,которыене используются более 30 мин");
                            Console.WriteLine($"Прошло {duras} времени");
                            break;
                        }
                    }
                }
            }
            static double SizeFolder(string pathToDirectory, ref double catalogSize) 
            {
                try
                {
                    DirectoryInfo Fol = new DirectoryInfo(pathToDirectory);
                    DirectoryInfo[] dir = Fol.GetDirectories();
                    FileInfo[] fi = Fol.GetFiles();
                    foreach (FileInfo f in fi)
                    {
                        catalogSize += f.Length;
                    }
                    foreach (DirectoryInfo df in dir)
                    {
                        SizeFolder(df.FullName, ref catalogSize);
                    }
                    return Math.Round((double)(catalogSize), 1);
                }

                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Папка не существует. Ошибка: " + ex.Message);
                    return 0;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Нет доступа. Ошибка: " + ex.Message);
                    return 0;
                }
            }
            static double SizeFolder2(string pathToDirectory, ref double catalogSize2)
            {
                try
                {
                    DirectoryInfo Fol = new DirectoryInfo(pathToDirectory);
                    DirectoryInfo[] dir = Fol.GetDirectories();
                    FileInfo[] fi = Fol.GetFiles();
                    foreach (FileInfo f in fi)
                    {
                        catalogSize2 += f.Length;
                    }
                    foreach (DirectoryInfo df in dir)
                    {
                        SizeFolder2(df.FullName, ref catalogSize2);
                    }
                    return Math.Round((double)(catalogSize2), 1);
                }

                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine("Папка не существует. Ошибка: " + ex.Message);
                    return 0;
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Нет доступа. Ошибка: " + ex.Message);
                    return 0;
                }
            }
        }

    }
}

