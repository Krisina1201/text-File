using workingWithTextFile;

class Program
{
    [STAThread]
    static void Main()
    {
        logic _logic = new logic();
        try
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Создать новый файл и сделать в нем записи");
            Console.WriteLine("2 - Изменить уже существующий файл");
            Console.WriteLine("3 - Вывод содержимого файла на экран");
            Console.WriteLine("4 - Удаление файла");

            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите имя файла:");
                        string nameFile = Console.ReadLine();
                        bool n = _logic.AddFile(nameFile);
                        break;
                    case "2":
                        Console.WriteLine("Введите имя файла для изменения:");
                        string fileName = Console.ReadLine();
                        bool nm = _logic.UpdateFile(fileName);
                        break;
                    case "3":
                        Console.WriteLine("Введите имя файла для чтения:");
                        string name = Console.ReadLine();
                        _logic.WriteText(name);
                        break;
                    case "4":
                        Console.WriteLine("Введите имя файла для удаления:");
                        string namee = Console.ReadLine();
                        _logic.DeleteFile(namee);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Общая ошибка: " + e.Message);
        }
    }
}