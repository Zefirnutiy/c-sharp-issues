using System;
using System.Collections.Generic;
using System.Net;

class Issue
{

    static void Main()
    {
        Console.WriteLine("Input number of sort's method:" +
            "\na - Quick sort" +
            "\nb - Tree sort");        
        string? sortMethod = Console.ReadLine();

        if (sortMethod != "a" && sortMethod != "b")
        {
            Console.WriteLine("invalid method input");
        }
        else
        {
            Console.Write("input some string: ");
            string? userInput = Console.ReadLine();
            if (userInput == null)
            {
                Console.WriteLine("string is null");
            }
            else
            {
                Console.WriteLine(Issue1(userInput, sortMethod));
            }
        }
    }


    // issue 1
    static string Issue1(string s, string sortMethod )
    {     
        if (s != ValidateString(s))
        {
            return ValidateString(s);
        }

        string operatedString = "";
        string sortedString = "";

        if (s.Length % 2 == 0)
        {
            int halfLengthOfString = s.Length / 2;

            operatedString = Reverse(s.Substring(0, halfLengthOfString)) +
            Reverse(s.Substring(halfLengthOfString, halfLengthOfString));
        }
        else
        {
            operatedString = Reverse(s) + s;
        }

        string quantityRepeatCharacters = CountRepeatCharacter(operatedString);
        string largestSubString = FindLargestSubString(operatedString);
        
        if(sortMethod == "a")
        {
            sortedString = QuickSortString(operatedString);
        }
        else
        {

            BinaryTree tree = new BinaryTree();

            foreach (char ch in operatedString)
            {
                tree.Insert($"{ch}");
            }

            string[] sortedArray = tree.InOrder();

            foreach (string ch in sortedArray)
            {
                sortedString += ch;
            }
        }

        string strWithoutRandChar = RemoveOneRandomIndex(operatedString);


        string result = $"Operated String:\n" +
                $"{operatedString}\n\n" +
                "Repeat Characters:\n" +
                $"{quantityRepeatCharacters}\n" +
                "Largest valid Substring:\n" +
                $"{largestSubString}\n\n" +
                "Sorted string:\n" +
                $"{sortedString}\n\n" +
                $"String without random char:\n" +
                $"{strWithoutRandChar}";

        return result;
    }
  

    //issue 2
    static string ValidateString(string s)
{

    string invalidUppercaseCharacters = "";
    string invalidOtherChatacters = "";

    foreach (var c in s)
    {
        if(c.ToString() != c.ToString().ToLower())
        {
            invalidUppercaseCharacters += c;
        }

        string allEnglishLetters = "abcdefghijklmnoprstuvwxxyz";
        
        if(!allEnglishLetters.Contains(c.ToString().ToLower()))
        {
            invalidOtherChatacters += c;
        }
    }

    string result = "";

    if(invalidUppercaseCharacters != "")
    {
        result += $"error: '{invalidUppercaseCharacters}' characters are in uppercase.\n";
    }

    if(invalidOtherChatacters != "")
    {
        result += $"error: '{invalidOtherChatacters}' - invalid character.\n";
    }

    if(result == "")
    {
        result += s;
    }

    return result;
}


    // issue 3
    static string CountRepeatCharacter(string s)
{
    string result = "";
    foreach (var letter in s.Distinct().ToArray())
    {
        var count = s.Count(chr => chr == letter);
        result += $" {letter} = {count}\n";
    }
    return result;
}


    // issue 4
    static string FindLargestSubString(string s)
{

    string result = "no correct substring";
    int maxLength = -1;
    for (var index = 0; index < s.Length; index++)
    {
        for(var i = s.Length; i >= 0 && i > index; i--)
        {
            string subSTR = s.Substring(index, i - index);
            if (!validateSubString(subSTR))
            {
                continue;
            }

            if (subSTR.Length > maxLength)
            {
                maxLength = subSTR.Length;
                result = subSTR;
            }
        }
    }

    return result;
}
    static bool validateSubString(string s)
{
    string validateCharacters = "aeiouy";
    bool startStringIsCorrect = false;
    bool endStringIsCorrect = false;

    foreach (var c in validateCharacters)
    {
        if (s[0] == c)
        {
            startStringIsCorrect = true;
        }
        if (s[s.Length - 1] == c)
        {
            endStringIsCorrect = true;
        }
    }


    
    return startStringIsCorrect && endStringIsCorrect;
}


    //issue 5

    // quick sort
    static string QuickSortString(string s)
    {

        int[] indexesOfLetter = stringToIntegerIndex(s);

        quickSort(indexesOfLetter, 0, indexesOfLetter.Length - 1);

        string result = integerIndexToString(indexesOfLetter);
        return result;
    }   

    static void quickSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int pivot = partition(arr, left, right);

        quickSort(arr, left, pivot - 1);
        quickSort(arr, pivot + 1, right);
    }
}
    static int partition(int[] arr, int left, int right)
{
    int pivot = arr[right];
    int i = left - 1;

    for (int j = left; j < right; j++)
    {
        if (arr[j] <= pivot)
        {
            i++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    int temp1 = arr[i + 1];
    arr[i + 1] = arr[right];
    arr[right] = temp1;

    return i + 1;
}


    //crutches
    static int[] stringToIntegerIndex(string s)
    {
        var letters = new Dictionary<char, int>()
    {
        {'a', 0},
        {'b', 1},
        {'c', 2},
        {'d', 3},
        {'e', 4},
        {'f', 5},
        {'g', 6},
        {'h', 7},
        {'i', 8},
        {'j', 9},
        {'k', 10},
        {'l', 11},
        {'m', 12},
        {'n', 13},
        {'o', 14},
        {'p', 15},
        {'q', 16},
        {'r', 17},
        {'s', 18},
        {'t', 19},
        {'u', 20},
        {'v', 21},
        {'w', 22},
        {'x', 23},
        {'y', 24},
        {'z', 25},
    };

        int[] indexesOfLetters = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            indexesOfLetters[i] = letters[s[i]];
        }

        return indexesOfLetters;
    }

    static string integerIndexToString(int[] indexesOfLetter)
    {
        var reverseLetters = new Dictionary<int, char>()
    {
        {0, 'a'},
        {1, 'b'},
        {2, 'c'},
        {3, 'd'},
        {4, 'e'},
        {5, 'f'},
        {6, 'g'},
        {7, 'h'},
        {8, 'i'},
        {9, 'j'},
        {10, 'k'},
        {11, 'l'},
        {12, 'm'},
        {13, 'n'},
        {14, 'o'},
        {15, 'p'},
        {16, 'q'},
        {17, 'r'},
        {18, 's'},
        {19, 't'},
        {20, 'u'},
        {21, 'v'},
        {22, 'w'},
        {23, 'x'},
        {24, 'y'},
        {25, 'z'},
    };

        string result = "";

        foreach (var ch in indexesOfLetter)
        {
            result += reverseLetters[ch];
        }

        return result;
    }


    // utilities 
    static string Reverse(string s)
    {
        string res = "";

        for (int i = s.Length - 1; i >= 0; i--)
        {
            res += s[i];
        }

        return res;
    }

    // issue 6
    static int GetRandomNum(int min, int max)
    {
        Random random = new Random();
        int randomNumberInRange = random.Next(min, max);

        return randomNumberInRange;

    }

    static string removeCharByIndex(string str, int index)
    {
        string result = "";
        for(int i = 0; i < str.Length; i++)
        {
            if (i != index)
            {
                result += str[i];
            }
        }

        return result;
    }

    static string RemoveOneRandomIndex(string s)
    {

        string result = "";
        try
        {
            QueryRandom request = new QueryRandom();

            request.min = 0;
            request.max = s.Length;
            request.count = 1;

            string randomNum = WebRequest.GetRandomNumbers(request);

            int charIndex;

            // пришлось сделать такой костыль по скольку запрос к api возвращает [random num] - в скобках.
            // конечно можно использовать trim, но так быстрее.
            bool success = int.TryParse($"{randomNum[1]}", out charIndex);
            if (!success)
            {
                Console.WriteLine("failed convert string to integer");
                return "";
            }

            result = removeCharByIndex(s, charIndex);

            return result;

        }
        catch
        {
            int randomNum = GetRandomNum(0, s.Length);

            result = removeCharByIndex(s, randomNum);

            return result;
        }
    }

}

class Node
{
    public string Value;
    public Node Left;
    public Node Right;
    public int Count;

    public Node(string value)
    {
        Value = value;
        Left = null;
        Right = null;
        Count = 1;
    }
}

class BinaryTree
{
    private Node root;
    private List<string> sortedList;

    public BinaryTree()
    {
        root = null;
        sortedList = new List<string>();
    }

    public void Insert(string value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node root, string value)
    {
        if (root == null)
        {
            root = new Node(value);
            return root;
        }

        if (string.Compare(value, root.Value) < 0)
        {
            root.Left = InsertRec(root.Left, value);
        }
        else if (string.Compare(value, root.Value) > 0)
        {
            root.Right = InsertRec(root.Right, value);
        }
        else
        {
            root.Count++;
        }

        return root;
    }

    public string[] InOrder()
    {
        InOrderRec(root);
        return sortedList.ToArray();
    }

    private void InOrderRec(Node root)
    {
        if (root != null)
        {
            InOrderRec(root.Left);
            for (int i = 0; i < root.Count; i++)
            {
                sortedList.Add(root.Value);
            }
            InOrderRec(root.Right);
        }
    }
}



// issue 6
public struct QueryRandom
{
    public int min { get; set; }
    public int max { get; set; }
    public int count { get; set; }
}
class WebRequest
{
    private WebClient webClient = new WebClient();
    

    public static string GetRandomNumbers(QueryRandom param)
    {
        System.Net.WebRequest reqGET = System.Net.WebRequest.Create($"http://www.randomnumberapi.com/api/v1.0/random?min={param.min}&max={param.max}&count={param.count}");
        System.Net.WebResponse resp = reqGET.GetResponse();
        System.IO.Stream stream = resp.GetResponseStream();
        System.IO.StreamReader sr = new System.IO.StreamReader(stream);
        
        string result = sr.ReadToEnd();

        return result;
    }
}