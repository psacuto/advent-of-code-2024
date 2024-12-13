using System.Text.RegularExpressions;

public class Day3 : IDay
{
    public string Step1(string input)
    {
        var matches = Regex.Matches(input, @"mul\((?<one>\d{1,3}),(?<two>\d{1,3})\)");
        var result = matches.Select(MulMatch).Sum().ToString();
        return result;
    }

    public string Step2(string input)
    {
        var matches = Regex.Matches(input, @"(mul\((?<one>\d{1,3}),(?<two>\d{1,3})\)|do\(\)|don't\(\))");
        var enable = true;
        var result = 0;
        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                enable = true;
            }
            else if (match.Value == "don't()")
            {
                enable = false;
            }
            else if (enable == true)
            {
                result += MulMatch(match);
            }
        }
        return result.ToString();
    }

    private int MulMatch(Match match)
    {
        return int.Parse(match.Groups["one"].Value) * int.Parse(match.Groups["two"].Value);
    }
}