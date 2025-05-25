namespace Итоговый_проект_5._6._1__HW_03_
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var userData = GetUserData();
            DisplayUserData(userData);
        }

        static (string Name, string Surname, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) GetUserData()
        {
            Console.WriteLine("Введите данные пользователя:");

            string name = GetInput("Имя: ");
            string surname = GetInput("Фамилия: ");
            int age = GetPositiveNumber("Возраст: ");

            bool hasPet = GetYesNoInput("Есть ли у вас питомец? (да/нет): ");
            int petCount = 0;
            string[] petNames = Array.Empty<string>();

            if (hasPet)
            {
                petCount = GetPositiveNumber("Количество питомцев: ");
                petNames = GetPetNames(petCount);
            }

            int colorCount = GetPositiveNumber("Количество любимых цветов: ");
            string[] favoriteColors = GetFavoriteColors(colorCount);

            return (name, surname, age, hasPet, petCount, petNames, colorCount, favoriteColors);
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        static int GetPositiveNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    return number;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число больше 0.");
            }
        }

        static bool GetYesNoInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.ToLower() ?? string.Empty;
                if (input == "да") return true;
                if (input == "нет") return false;
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
            }
        }

        static string[] GetPetNames(int count)
        {
            string[] names = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите кличку питомца {i + 1}: ");
                names[i] = Console.ReadLine() ?? string.Empty;
            }
            return names;
        }

        static string[] GetFavoriteColors(int count)
        {
            string[] colors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите любимый цвет {i + 1}: ");
                colors[i] = Console.ReadLine() ?? string.Empty;
            }
            return colors;
        }

        static void DisplayUserData((string Name, string Surname, int Age, bool HasPet, int PetCount, string[] PetNames, int ColorCount, string[] FavoriteColors) userData)
        {
            Console.WriteLine("\nДанные пользователя:");
            Console.WriteLine($"Имя: {userData.Name}");
            Console.WriteLine($"Фамилия: {userData.Surname}");
            Console.WriteLine($"Возраст: {userData.Age}");

            if (userData.HasPet)
            {
                Console.WriteLine($"Количество питомцев: {userData.PetCount}");
                Console.WriteLine("Клички питомцев:");
                foreach (var name in userData.PetNames)
                {
                    Console.WriteLine($"- {name}");
                }
            }
            else
            {
                Console.WriteLine("Питомцев нет");
            }

            Console.WriteLine($"Количество любимых цветов: {userData.ColorCount}");
            Console.WriteLine("Любимые цвета:");
            foreach (var color in userData.FavoriteColors)
            {
                Console.WriteLine($"- {color}");
            }
        }
    }
}


