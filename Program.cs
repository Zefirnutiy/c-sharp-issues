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
    if (s != ValidateString(s))
    {
        return ValidateString(s);
    }

    if (s.Length % 2 == 0)
    {
            result = Reverse(s.Substring(0, s.Length / 2)) +
            Reverse(s.Substring(s.Length / 2, s.Length / 2));
        return result + $"\n{CountRepeatCharacter(result)}";
    }

    result = Reverse(s) + s;

    return result + $"\n{CountRepeatCharacter(result)}";
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
    string result = "Characters:\n";
    foreach (var letter in s.Distinct().ToArray())
    {
        var count = s.Count(chr => chr == letter);
        result += $" {letter} = {count}\n";
    }
    return result;
}


Console.WriteLine(Issue1("mybeautifulmadness"));
