using System;
using System.IO;

namespace workingWithTextFile
{
    public class logic
    {
        
        public static string[] headers = { "Наименование услуги", "Длительность в минутах", "Стоимость услуги", "Время выполнения" };

        static string headerLine = $"| {string.Join(" | ", headers)} |";
        static string separatorLine = new string('-', headerLine.Length);

        public bool AddFile(string nameFile)
        {
            if (string.IsNullOrWhiteSpace(nameFile))
            {
                Console.WriteLine("Имя файла не может быть пустым.");
                return false;
            }

            string path = Path.Combine(@"C:\Users\Admin\OneDrive\Документы\практос", nameFile + ".txt");
            {
                
            }
            try
            {
                string fileContent = headerLine + Environment.NewLine + separatorLine + Environment.NewLine;


                Console.WriteLine("Введите наименование услуги (или 'exit' для завершения): ");
                string name = Console.ReadLine();
                

                Console.WriteLine("Введите длительность услуги в минутах: ");
                string duration = Console.ReadLine();
                Console.WriteLine("Введите стоимость услуги: ");
                string price = Console.ReadLine();
                Console.WriteLine("Введите время выполнения услуги: ");
                string time = Console.ReadLine();

                
                string userDataLine = $"| {name} | {duration} | {price} | {time} |";
                fileContent += userDataLine + Environment.NewLine; 

               
                File.WriteAllText(path, fileContent);
                Console.WriteLine("Файл и таблица созданы.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при создании файла:\n " + e.Message);
                return false;
            }
        }

        public bool UpdateFile(string nameFile)
        {
            try
            {
                string path = Path.Combine(@"C:\Users\Admin\OneDrive\Документы\практос", nameFile + ".txt");

                // Проверяем, существует ли файл
                if (!File.Exists(path))
                {
                    Console.WriteLine($"Файл '{nameFile}' не найден по пути: {path}");
                    return false;
                }

                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(path);

                // Запрашиваем данные у пользователя
                Console.WriteLine("Введите название услуги: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите время выполнения услуги: ");
                string date = Console.ReadLine();

                // Проверяем, что данные введены
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(date))
                {
                    Console.WriteLine("Название услуги и время выполнения не могут быть пустыми.");
                    return false;
                }

                // Флаг для проверки, были ли внесены изменения
                bool changesMade = false;

                // Обновляем строки
                for (int i = 0; i < lines.Length; i++)
                {
                    // Проверяем, соответствует ли строка шаблону данных
                    if (lines[i].StartsWith("|") && lines[i].Contains("|"))
                    {
                        // Разделяем строку на части
                        string[] parts = lines[i].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                        // Проверяем, совпадает ли название и время выполнения
                        if (parts.Length >= 4 && parts[1].Trim() == name && parts[4].Trim() == date)
                        {
                            // Запрашиваем новые данные
                            Console.WriteLine("Введите новое наименование услуги: ");
                            string newName = Console.ReadLine();
                            Console.WriteLine("Введите новую длительность услуги в минутах: ");
                            string newDuration = Console.ReadLine();
                            Console.WriteLine("Введите новую стоимость услуги: ");
                            string newPrice = Console.ReadLine();
                            Console.WriteLine("Введите новое время выполнения услуги: ");
                            string newDate = Console.ReadLine();

                            // Формируем новую строку
                            lines[i] = $"| {newName.Trim()} | {newDuration.Trim()} | {newPrice.Trim()} | {newDate.Trim()} |";
                            changesMade = true;
                        }
                    }
                }

                // Если изменения были внесены, записываем их обратно в файл
                if (changesMade)
                {
                    File.WriteAllLines(path, lines);
                    Console.WriteLine("Изменения успешно добавлены.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Совпадений не найдено. Файл не изменен.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при обновлении файла:\n " + e.Message);
                return false;
            }
        }

        public void WriteText (string nameFile)
        {
            try
            {
                string path = Path.Combine(@"C:\Users\Admin\OneDrive\Документы\практос", nameFile + ".txt");

                if (!File.Exists(path))
                {
                    Console.WriteLine($"Файл '{nameFile}' не найден по пути: {path}");
                }

                string[] text = File.ReadAllLines(path);
                foreach (string line in text)
                {
                    Console.WriteLine(line);
                }
            } catch (Exception e) { Console.WriteLine($"Произошла ошибка: {e.Message}"); return; }
            
        }

        public void DeleteFile(string nameFile) 
        {
            try
            {
                string path = Path.Combine(@"C:\Users\Admin\OneDrive\Документы\практос", nameFile + ".txt");

                if (!File.Exists(path))
                {
                    Console.WriteLine($"Файл '{nameFile}' не найден по пути: {path}");
                }

                File.Delete(path);
                Console.WriteLine("Файл успешно удален");
            }
            catch (Exception e) { Console.WriteLine($"Произошла ошибка: {e}"); }
        }
    }
}