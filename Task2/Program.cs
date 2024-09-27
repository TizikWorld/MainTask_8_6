namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string path = "";

            while (!Directory.Exists(path)) {
                Console.WriteLine("Введите путь дирректории");
                path = Console.ReadLine();
            }

            long size = DirSize(new System.IO.DirectoryInfo(path));

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
