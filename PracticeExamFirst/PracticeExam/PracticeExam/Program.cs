using System.Runtime.CompilerServices;

namespace PracticeExam;

class Program
{
    static void Main(string[] args)
    {
        /*
        // 1 - masala
        Console.WriteLine("Enter length of array : ");
        var length = int.Parse(Console.ReadLine());
        var array = new int[length];
        FillIntArray(array);
        var counter = GetMostRepeated(array);
        */

        /*
        // 2 - masala
        Console.WriteLine("Enter text : ");
        var text = Console.ReadLine();
        var result = DoReverseLetters(text);
        Console.WriteLine(result);
        */
        
        /*
        // 3.1 - masala
        Console.WriteLine("Enter text : ");
        var text = Console.ReadLine();
        var result = FindLastWordLength(text);
        Console.WriteLine(result);
        */
        
        /*
        // 3.2 - masala
        Console.WriteLine("Enter text : ");
        var text = Console.ReadLine();
        var result = FindLastWordLengthWithDigits(text);
        Console.WriteLine(result);
        */
    }

    public static void FillIntArray(int[] numbers)
    {
        Console.WriteLine("only int : ");
        for (int i = 0; i < numbers.Length; i++)
        {
            
            Console.Write($" {i} : ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
    }

    // 1 - masala
    public static int GetMostRepeated(int[] n)
    {
        var helper = n[0];
        var middleCount = 1;
        for (int i = 0; i < n.Length; i++)
        {
            
            var counter = 0;
            
            for (int j = 0; j < n.Length; j++)
            {
                if (n[j] == n[i])
                {
                    // helper = n[i];
                    counter++;
                }
            }

            if (counter > middleCount)
            {
                helper = n[i];
                middleCount = counter;
            }
        }

        var result = helper;
        return result;
    }

    // 2 - masala
    public static string DoReverseLetters(string input)
    {
        string collector = null;
        
        var arrayLength = input.Length-1;
        for (int i = 0; i < input.Length; i++)
        {
            
            if (char.IsLetter(input[i]) is true && char.IsLetter(input[arrayLength]) is true)
            {
                collector = input[i] + collector;
            }
            else
            {
                collector = input[arrayLength] + collector;
            }

            arrayLength--;
        }
        return collector;
    }

    // 3.1 - masala
    // works only for letters and also with "-" like ("asta-sekin" == 10)
    public static int FindLastWordLength(string input)
    {
        var counter = 0;
        for (int i = input.Length-1; i > 0; i--)
        {
            if (char.IsLetter(input[i]) || input[i] == '-')
            {
                counter++;
            }
            else if (!char.IsLetter(input[i]) && counter == 0)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return counter;
    }
    
    // 3.2 - masala
    public static int FindLastWordLengthWithDigits(string input)
    {
        // this is perfect version works for digits too
        // "   abcde agent001 456 7uy " == 6 (fgh123)
        // "   abcde agent001 456 7-uy " == 2 (uy)
        var counter = 0;
        for (int i = input.Length-1; i > 0; i--)
        {
            if (char.IsLetter(input[i]) || input[i] == '-' || char.IsDigit(input[i]))
            {
                counter++;
            }
            else if (counter == 0/*!char.IsLetter(input[i]) && !char.IsDigit(input[i]) && */)
            {
                continue;
            }
            else if (char.IsDigit(input[i + 1]) && counter > 0 /*&& !char.IsLetter(input[i])*/)
            {
                if (input[i + 2] == '-')
                {
                    counter--;
                    break;
                }
                counter = 0;
            }
            else
            {
                break;
            }
        }
        return counter;
    }
}