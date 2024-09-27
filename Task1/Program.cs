using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\My\\ReposVS\\MainTask_8_6\\trash";
            DeleteAll30Min(path);
            

        }

        public static void DeleteAll30Min(string Path)
        {
            string path = Path;

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Папка по указанному пути не существует: {path}");
                return;
            }

            DateTime dateNow = DateTime.Now;

            TimeSpan timeLimit = TimeSpan.FromMinutes(30);
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    DateTime lastAccessTime = File.GetLastAccessTime(file);
                    if (lastAccessTime < dateNow - timeLimit)//<
                    {
                        File.Delete(file);
                        Console.WriteLine($"Файл удален:{file}");
                    }
                }
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {

                    DateTime lastAccessTime = Directory.GetLastAccessTime(folder);
                    if (lastAccessTime < dateNow - timeLimit)//<
                    {
                        File.SetAttributes(folder, FileAttributes.Normal); //позволяет избежать исключения access to the path
                        Directory.Delete(folder, true);
                        Console.WriteLine($"Папка удалена:{folder}");
                    }
                }
            }//Вывод ошибок
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maximum supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
        }
            public static void DeleteAll(string Path)
            {
                string path = Path;

                if (!Directory.Exists(path))
                {
                    Console.WriteLine($"Папка по указанному пути не существует: {path}");
                    return;
                }

                try
                {
                    string[] files = Directory.GetFiles(path);
                    int countFiles = 0;
                    foreach (string file in files)
                    {
                            File.Delete(file);
                            //Console.WriteLine($"Файл удален:{file}");
                    countFiles++;
                    }
                    string[] folders = Directory.GetDirectories(path);
                    int countFolders = 0;
                    foreach (string folder in folders)
                    {
                            File.SetAttributes(folder, FileAttributes.Normal); //позволяет избежать исключения access to the path
                            Directory.Delete(folder, true);
                            //Console.WriteLine($"Папка удалена:{folder}");
                    countFolders++;
                    }
                Console.WriteLine($"Удалено файлов {countFiles}");
                Console.WriteLine($"Удалено папок {countFolders}");
                }//Вывод ошибок
                catch (FileNotFoundException)
                {
                    Console.WriteLine("The file or directory cannot be found.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("The file or directory cannot be found.");
                }
                catch (DriveNotFoundException)
                {
                    Console.WriteLine("The drive specified in 'path' is invalid.");
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine("'path' exceeds the maximum supported path length.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You do not have permission to create this file.");
                }
                catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
                {
                    Console.WriteLine("There is a sharing violation.");
                }
                catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
                {
                    Console.WriteLine("The file already exists.");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"An exception occurred:\nError code: " +
                                      $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
                }

            }
    }
}
