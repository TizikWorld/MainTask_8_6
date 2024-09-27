namespace Task3
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

            //Добавлены ссылки на проект Task1 и Task2

            Task2.Program.GetSize(path);//получение размера папки

            Task1.Program.DeleteAll(path);//Удаление всего из папки

            Task2.Program.GetSize(path);//получение размера папки


        }
    }
}
