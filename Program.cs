// issue 1

static string Reverse(string s)
{
    string res = "";

    for (int i = s.Length - 1; i >= 0; i--)
    {
        res += s[i];
    }

    return res;
}

static string Issue1(string s)
{
    string result = "";
    string quantityRepeatCharacters = "";
    string operatedString = "";
    string largestSubString = "";

    if (s != ValidateString(s))
    {
        return ValidateString(s);
    }

    if (s.Length % 2 == 0)
    {
        int halfLengthOfString = s.Length / 2;

        operatedString = Reverse(s.Substring(0, halfLengthOfString)) +
        Reverse(s.Substring(halfLengthOfString, halfLengthOfString));

        largestSubString = FindLargestSubString(operatedString);

        quantityRepeatCharacters = CountRepeatCharacter(operatedString);

        result = $"{operatedString}\n" +
            $"Repeat Characters:\n" +
            $"{quantityRepeatCharacters}\n" +
            $"Largest valid Substring:\n" +
            $"{largestSubString}";


        return result;
    }

    operatedString = Reverse(s) + s;
    quantityRepeatCharacters = CountRepeatCharacter(operatedString);
    largestSubString = FindLargestSubString(operatedString);

    result = $"{operatedString}\n" +
            $"Repeat Characters:\n" +
            $"{quantityRepeatCharacters}\n" +
            $"Largest valid Substring:\n" +
            $"{largestSubString}";

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






Console.Write("Please input a string: ");
string? userInput = Console.ReadLine();

if (userInput != null)
{
    Console.WriteLine(Issue1(userInput));
}else
{
    Console.WriteLine("you did not enter a string");
}

Console.ReadKey(); 
