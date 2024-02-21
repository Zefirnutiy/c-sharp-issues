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
    if(s != ValidateString(s))
    {
        return ValidateString(s);
    }

    if (s.Length % 2 == 0)
    {
        return Reverse(s.Substring(0, s.Length / 2)) +
            Reverse(s.Substring(s.Length / 2, s.Length / 2));
    }

    return Reverse(s) + s;
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


Console.WriteLine(Issue1("some string"));
