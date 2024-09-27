using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\My\\ReposVS\\MainTask_8_6\\trash";

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
                foreach (string folder in folders) {

                    DateTime lastAccessTime = Directory.GetLastAccessTime(folder);
                    if (lastAccessTime > dateNow - timeLimit)//<
                    {
                        Directory.Delete(folder,true);
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
    }
}
