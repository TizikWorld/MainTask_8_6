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







        }
    }
}
