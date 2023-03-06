Console.Clear();

Tasks t = new Tasks();
Methods m = new Methods();

bool isWork = true;
string mainMenuText = $"Если хотите вызвать справку, напишите - /help.{Environment.NewLine}"
                    + $"Если хотите завершить работу программы, напишите - exit.{Environment.NewLine}"
                    + $"Если хотите очистить терминал, напишите clear.{Environment.NewLine}{Environment.NewLine}"
                    + $"Какую задачу хотите проверить?{Environment.NewLine}Напишите номер задачи от 1 до 2: ";

while (isWork)
{
  Console.Write(mainMenuText);
  string word = Console.ReadLine();
  Console.WriteLine();

  if (word == "1" || word == "2")
  {
    switch (word)
    {
      case "1":
      {
        t.Task41_CountOfNumsMoreThanZero_1();
        //t.Task41_CountOfNumsMoreThanZero_2();
        m.ToEndTask();
        break;
      }
      case "2":
      {
        t.Task43_FindPointOfCross();
        m.ToEndTask();
        break;
      }
    }
  }
  else if (word.ToLower() == "e" || word.ToLower() == "exit" || word.ToLower() == "у")
  {
    isWork = false;
  }
  else if (word.ToLower() == "c" || word.ToLower() == "clear" || word.ToLower() == "с")
  {
    Console.Clear();
  }
  else if (word.ToLower() == "/help" || word.ToLower() == "h" || word.ToLower() == "р")
  {
    m.ToHelp();
  }
  else
  {
    Console.WriteLine($"Команда не была распознана, повторите ввод{Environment.NewLine}");
  }
}

public class Methods
{
	#region MethodsForTasks

	public double ReadFromUser(string arg)
	{
		Console.Write($"Введите {arg}: ");
		double num;
		
		while (!double.TryParse(Console.ReadLine(), out num))
		{
			Console.Write("Значение не подходит, повторите: ");
		}

		return num;
	}

	public double[] GetFilledArray(double length)
	{
		double[] array = new double[(int)length];

		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ReadFromUser($"значение на позиции {i + 1}");
		}

		return array;
	}

	public double CalculateNumsMoreThanZero()
	{
		bool isWork = true;
		double result = 0;

		while (isWork)
		{
			Console.Write("Введите число: ");
			string s = Console.ReadLine();
			double num = 0;

			if (s.ToLower() == "s" || s.ToLower() == "stop" || s.ToLower() == "ы")
			{
				isWork = false;
			}
			else if (!double.TryParse(s, out num))
			{
				Console.WriteLine("Значение не подходит, повторите.");
			}

			if (num > 0) result++;
		}

		return result;
	}

	public double CalculateNumsMoreThanZeroInArray(double[] array)
	{
		double count = 0;

		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > 0) count++;
		}

		return count;
	}

	public double FindXOfCross(double k1, double b1, double k2, double b2)
	{
		return (b1 - b2) / (- k1 + k2);
	}

	public double FindYOfCross(double k, double b, double x)
	{
		return k * x + b;
	}

	#endregion

	#region MethodsForWork

	public void ToEndTask()
	{
  	Console.WriteLine($"{Environment.NewLine}Для возврата в главное меню, нажмите любую кнопку{Environment.NewLine}");
  	Console.ReadKey();
	}

	public void ToHelp()
	{
		Console.Clear();
  	string text = $"Справка:{Environment.NewLine}1. Посчитать, сколько введено чисел больше 0.{Environment.NewLine}"
								+ $"2. Нахождение точки пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2.{Environment.NewLine}"
								+ $"/help или /h. Справка{Environment.NewLine}Exit или E. Завершение работы программы";

  	Console.WriteLine(text);
  	ToEndTask();
		Console.Clear();
	}

	#endregion
}

internal class Tasks
{
  Methods m = new Methods();

  public void Task41_CountOfNumsMoreThanZero_1() // запрос пока пользователь не прервёт ввод
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}Посчитайте, сколько введено чисел больше 0{Environment.NewLine}"
                + $"Введите необходимое количество чисел по очереди, а в конце введите \"stop\"{Environment.NewLine}";
    Console.WriteLine(text);

    double result = m.CalculateNumsMoreThanZero();
    Console.WriteLine($"Вы ввели {result} чисел больше 0.");
  }

  public void Task41_CountOfNumsMoreThanZero_2() // через массив
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}Посчитать, сколько введено чисел больше 0.{Environment.NewLine}";
    Console.WriteLine(text);

    double result = m.CalculateNumsMoreThanZeroInArray(m.GetFilledArray(m.ReadFromUser("количество чисел для сравнения")));
    Console.WriteLine($"Вы ввели {result} чисел больше 0.");
  }

  public void Task43_FindPointOfCross()
  {
    string text = $"Вы выбрали задачу номер 2{Environment.NewLine}"
                + $"Нахождение точки пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2.{Environment.NewLine}";
    Console.WriteLine(text);

    double k1 = m.ReadFromUser("значение k1");
    double b1 = m.ReadFromUser("значение b1");
    double k2 = m.ReadFromUser("значение k2");
    double b2 = m.ReadFromUser("значение b2");
    double x = m.FindXOfCross(k1, b1, k2, b2);
    Console.WriteLine($"x = {x}");
    double y = m.FindYOfCross(k2, b2, x);
    Console.WriteLine($"y = {y}");

    if (k1 == k2 && b1 == b2)
    {
      Console.WriteLine("Прямые совпадают!");
    }
    else if (k1 == k2)
    {
      Console.WriteLine("Прямые не пересекаются!");
    }
    else
    {
      Console.WriteLine($"Координаты точки пересечения прямых ({x}, {y}).");
    }
  }
}