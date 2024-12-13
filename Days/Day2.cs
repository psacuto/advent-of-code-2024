public class Day2 : IDay
{
    public string Step1(string input)
    {
        var list = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        var result = list.Where(x => IsSafe(x)).Count();
        return result.ToString();
    }

    private bool IsSafe(int[] x)
    {
        if (x.Length == 1) return true;
        var direction = x[1] - x[0];
        for (int i = 1; i < x.Length; i++)
        {
            var n0 = x[i - 1];
            var n1 = x[i];
            var diff = Math.Abs(n0 - n1);
            if (n0 * direction > n1 * direction || diff < 1 || diff > 3)
                return false;
        }
        return true;
    }

    public string Step2(string input)
    {
        var list = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        var safeCount = list.Where(x => IsSafe(x) || IsSafey(x)).Count();
        return safeCount.ToString();
    }

    private bool IsSafey(int[] arg)
    {
        for (int i = 0; i < arg.Length; i++)
        {
            var l = arg.ToList();
            l.RemoveAt(i);
            if (IsSafe(l.ToArray()))
                return true;
        }
        return false;
    }
}
