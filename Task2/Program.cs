using System.Security.Cryptography.X509Certificates;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = "";

            GetSize(path);


            
        }
        public static void GetSize(string Path)
        {


            while (!Directory.Exists(Path))
            {
                Console.WriteLine("Введите путь дирректории");
                Path = Console.ReadLine();
            }

            long size = DirSize(new System.IO.DirectoryInfo(Path));

            Console.WriteLine($"Вес дирректории:{size} байт");

            static long DirSize(DirectoryInfo d)
            {
                long Size = 0;

                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    Size += fi.Length;
                }

                DirectoryInfo[] dis = d.GetDirectories();

                foreach (DirectoryInfo di in dis)
                {
                    Size += DirSize(di);
                }
                return (Size);
            }
        }


    }
}
