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
    if (s.Length % 2 == 0)
    {
        return Reverse(s.Substring(0, s.Length / 2)) +
            Reverse(s.Substring(s.Length / 2, s.Length / 2));
    }

    return Reverse(s) + s;
}


Console.WriteLine(Issue1("abcdef"));
