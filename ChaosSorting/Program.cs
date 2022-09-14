using System.Diagnostics;

int min = 0;
int max = 8;
int amountOfGuesses = 0;

int[] elements = new int[max];

bool isCorrectGuess = false;

string checkString = string.Empty;

for (int i = min; i < max; i++)
    checkString += i.ToString();

Stopwatch stopwatch = new Stopwatch();

GenerateStartingPoint();

string str = ElementsToString();

Console.WriteLine($"Start: {str}");

stopwatch.Start();

do
{
    var usedNumbers = new List<int>();
    var currentList = elements.ToArray();

    foreach (var element in currentList)
    {
        int chosenNumber = -1;
        chosenNumber = ReplaceNumber(usedNumbers, element, chosenNumber);
    }

    var guess = ElementsToString();
    isCorrectGuess = CheckString(guess);

    amountOfGuesses++;

} while (!isCorrectGuess);

stopwatch.Stop();

Console.WriteLine($"I guessed it correctly after: {amountOfGuesses} times!!!");
Console.WriteLine($"I needed {stopwatch.Elapsed.Days} days and {stopwatch.Elapsed.Hours}:{stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}.");

Console.ReadLine();

string ElementsToString()
{
    var str = string.Empty;

    foreach (var element in elements)
        str += element.ToString();

    return str;
}

bool CheckString(string guess) =>
    checkString == guess;

void GenerateStartingPoint()
{
    var usedNumbers = new List<int>();

    for (int i = min; i < max; i++)
    {
        int chosenNumber = -1;
        while (chosenNumber == -1)
        {
            var rnd = new Random();
            var number = rnd.Next(min, max);

            if (!usedNumbers.Any(x => x == number))
            {
                usedNumbers.Add(number);
                chosenNumber = number;
            }
        }

        elements[i] = chosenNumber;
    }
}

int ReplaceNumber(List<int> usedNumbers, int element, int chosenNumber)
{
    while (chosenNumber == -1)
    {
        var rnd = new Random();
        var number = rnd.Next(min, max);

        if (!usedNumbers.Any(x => x == number))
        {
            usedNumbers.Add(number);
            chosenNumber = number;
        }
    }

    elements[chosenNumber] = element;
    return chosenNumber;
}