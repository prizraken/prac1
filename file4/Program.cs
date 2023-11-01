using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        string basePath = @"C:\test\";

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Вывести информацию о дисках и файлах");
            Console.WriteLine("2. Создать файл");
            Console.WriteLine("3. Записать строку в файл");
            Console.WriteLine("4. Прочитать файл");
            Console.WriteLine("5. Удалить файл");
            Console.WriteLine("6. Создать файл JSON");
            Console.WriteLine("7. Сериализовать и записать объект JSON в файл");
            Console.WriteLine("8. Прочитать файл JSON");
            Console.WriteLine("9. Удалить файл JSON");
            Console.WriteLine("10. Создать файл XML");
            Console.WriteLine("11. Записать данные в файл XML");
            Console.WriteLine("12. Прочитать файл XML");
            Console.WriteLine("13. Удалить файл XML");
            Console.WriteLine("14. Создать и добавить файл в архив ZIP");
            Console.WriteLine("15. Разархивировать файл из ZIP");
            Console.WriteLine("16. Удалить файл и архив ZIP");
            Console.WriteLine("0. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListDrivesAndFiles(basePath);
                    break;
                case 2:
                    CreateFile(basePath);
                    break;
                case 3:
                    WriteToFile(basePath);
                    break;
                case 4:
                    ReadFile(basePath);
                    break;
                case 5:
                    DeleteFile(basePath);
                    break;
                case 6:
                    CreateJsonFile(basePath);
                    break;
                case 7:
                    SerializeAndWriteJson(basePath);
                    break;
                case 8:
                    ReadJsonFile(basePath);
                    break;
                case 9:
                    DeleteJsonFile(basePath);
                    break;
                case 10:
                    CreateXmlFile(basePath);
                    break;
                case 11:
                    WriteToXmlFile(basePath);
                    break;
                case 12:
                    ReadXmlFile(basePath);
                    break;
                case 13:
                    DeleteXmlFile(basePath);
                    break;
                case 14:
                    CreateZipArchive(basePath);
                    break;
                case 15:
                    ExtractFromZipArchive(basePath);
                    break;
                case 16:
                    DeleteZipArchive(basePath);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }

    // Метод для вывода информации о логических дисках, файлах и директориях
    static void ListDrivesAndFiles(string basePath)
    {
        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"Диск: {drive.Name}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                Console.WriteLine($"Тип файловой системы: {drive.DriveFormat}");
                Console.WriteLine($"Доступно места: {drive.AvailableFreeSpace} байт");
            }

            // Вывод файлов и директорий в текущей директории
            DirectoryInfo directory = new DirectoryInfo(basePath);
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subDirectories = directory.GetDirectories();

            Console.WriteLine("Файлы в текущей директории:");
            foreach (FileInfo file in files)
            {
                Console.WriteLine($" - {file.Name}");
            }

            Console.WriteLine("Поддиректории в текущей директории:");
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                Console.WriteLine($" - {subDirectory.Name}");
            }
        }
    }

    // Метод для создания файла
    static void CreateFile(string basePath)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine($"Файл '{fileName}' создан успешно.");
        }
        else
        {
            Console.WriteLine($"Файл '{fileName}' уже существует.");
        }
    }

    // Метод для записи строки в файл
    static void WriteToFile(string basePath)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            Console.Write("Введите строку для записи в файл: ");
            string content = Console.ReadLine();

            File.WriteAllText(filePath, content);
            Console.WriteLine("Строка успешно записана в файл.");
        }
        else
        {
            Console.WriteLine($"Файл '{fileName}' не существует.");
        }
    }

    // Метод для чтения содержимого файла и вывода в консоль
    static void ReadFile(string basePath)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"Содержимое файла '{fileName}':");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine($"Файл '{fileName}' не существует.");
        }
    }

    // Метод для удаления файла
    static void DeleteFile(string basePath)
    {
        Console.Write("Введите имя файла для удаления: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"Файл '{fileName}' удален успешно.");
        }
        else
        {
            Console.WriteLine($"Файл '{fileName}' не существует.");
        }
    }

    // Метод для создания файла JSON
    static void CreateJsonFile(string basePath)
    {
        Console.Write("Введите имя файла JSON (с расширением .json): ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine($"Файл JSON '{fileName}' создан успешно.");
        }
        else
        {
            Console.WriteLine($"Файл JSON '{fileName}' уже существует.");
        }
    }
    // Метод для сериализации и записи объекта JSON в файл
    static void SerializeAndWriteJson(string basePath)
    {
        Console.Write("Введите имя файла JSON: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine("Введите данные для сериализации в JSON:");

            // Создание объекта и сериализация его в JSON
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            // Создание объекта для сериализации
            Person person = new Person { Name = name, Age = age };

            // Сериализация в JSON и запись в файл
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                jsonSerializer.WriteObject(fileStream, person);
                Console.WriteLine("Данные успешно сериализованы и записаны в файл JSON.");
            }
        }
        else
        {
            Console.WriteLine($"Файл JSON '{fileName}' не существует.");
        }
    }

    // Метод для чтения и десериализации файла JSON
    static void ReadJsonFile(string basePath)
    {
        Console.Write("Введите имя файла JSON: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                Person person = (Person)jsonSerializer.ReadObject(fileStream);
                Console.WriteLine($"Данные из файла JSON '{fileName}':");
                Console.WriteLine($"Имя: {person.Name}");
                Console.WriteLine($"Возраст: {person.Age}");
            }
        }
        else
        {
            Console.WriteLine($"Файл JSON '{fileName}' не существует.");
        }
    }

    // Метод для удаления файла JSON
    static void DeleteJsonFile(string basePath)
    {
        Console.Write("Введите имя файла JSON для удаления: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"Файл JSON '{fileName}' удален успешно.");
        }
        else
        {
            Console.WriteLine($"Файл JSON '{fileName}' не существует.");
        }
    }

    // Метод для создания файла XML
    static void CreateXmlFile(string basePath)
    {
        Console.Write("Введите имя файла XML (с расширением .xml): ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine($"Файл XML '{fileName}' создан успешно.");
        }
        else
        {
            Console.WriteLine($"Файл XML '{fileName}' уже существует.");
        }
    }

    // Метод для записи данных в файл XML
    static void WriteToXmlFile(string basePath)
    {
        Console.Write("Введите имя файла XML: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            Console.WriteLine("Введите данные для записи в XML:");

            // Создание объекта и сериализация его в XML
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            // Создание объекта для сериализации
            Person person = new Person { Name = name, Age = age };

            // Сериализация в XML и запись в файл
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, person);
                Console.WriteLine("Данные успешно записаны в файл XML.");
            }
        }
        else
        {
            Console.WriteLine($"Файл XML '{fileName}' не существует.");
        }
    }

    // Метод для чтения данных из файла XML
    static void ReadXmlFile(string basePath)
    {
        Console.Write("Введите имя файла XML: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                Person person = (Person)xmlSerializer.Deserialize(fileStream);
                Console.WriteLine($"Данные из файла XML '{fileName}':");
                Console.WriteLine($"Имя: {person.Name}");
                Console.WriteLine($"Возраст: {person.Age}");
            }
        }
        else
        {
            Console.WriteLine($"Файл XML '{fileName}' не существует.");
        }
    }

    // Метод для удаления файла XML
    static void DeleteXmlFile(string basePath)
    {
        Console.Write("Введите имя файла XML для удаления: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(basePath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"Файл XML '{fileName}' удален успешно.");
        }
        else
        {
            Console.WriteLine($"Файл XML '{fileName}' не существует.");
        }
    }

    // Метод для создания и добавления файла в архив ZIP
    static void CreateZipArchive(string basePath)
    {
        Console.Write("Введите имя архива ZIP (с расширением .zip): ");
        string zipFileName = Console.ReadLine();
        string zipFilePath = Path.Combine(basePath, zipFileName);

        if (File.Exists(zipFilePath))
        {
            Console.WriteLine($"Архив ZIP '{zipFileName}' уже существует.");
        }
        else
        {
            using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                Console.Write("Введите имя файла для добавления в архив: ");
                string fileNameToAdd = Console.ReadLine();
                string filePathToAdd = Path.Combine(basePath, fileNameToAdd);

                if (File.Exists(filePathToAdd))
                {
                    // Добавление файла в архив с правильным расширением
                    string entryName = Path.ChangeExtension(fileNameToAdd, ".zipentry");
                    archive.CreateEntryFromFile(filePathToAdd, entryName);
                    Console.WriteLine($"Файл '{fileNameToAdd}' добавлен в архив '{zipFileName}'.");
                }
                else
                {
                    Console.WriteLine($"Файл '{fileNameToAdd}' не существует.");
                }
            }
        }
    }

    // Метод для разархивирования файла из архива ZIP
    static void ExtractFromZipArchive(string basePath)
    {
        Console.Write("Введите имя архива ZIP (с расширением .zip): ");
        string zipFileName = Console.ReadLine();
        string zipFilePath = Path.Combine(basePath, zipFileName);

        if (File.Exists(zipFilePath))
        {
            Console.Write("Введите имя файла для извлечения: ");
            string fileNameToExtract = Console.ReadLine();
            string extractPath = basePath;

            using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.Equals(Path.ChangeExtension(fileNameToExtract, ".zipentry"), StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.Name), true);
                        Console.WriteLine($"Файл '{entry.Name}' успешно извлечен из архива.");
                        return;
                    }
                }
            }

            Console.WriteLine($"Файл '{fileNameToExtract}' не найден в архиве '{zipFileName}'.");
        }
        else
        {
            Console.WriteLine($"Архив ZIP '{zipFileName}' не существует.");
        }
    }

    // Метод для удаления файла и архива ZIP
    static void DeleteZipArchive(string basePath)
    {
        Console.Write("Введите имя архива ZIP для удаления: ");
        string zipFileName = Console.ReadLine();
        string zipFilePath = Path.Combine(basePath, zipFileName);

        if (File.Exists(zipFilePath))
        {
            File.Delete(zipFilePath);
            Console.WriteLine($"Архив ZIP '{zipFileName}' удален успешно.");
        }
        else
        {
            Console.WriteLine($"Архив ZIP '{zipFileName}' не существует.");
        }
    }
}

// Пример класса для сериализации в JSON и XML
[DataContract]
public class Person
{
    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public int Age { get; set; }
}