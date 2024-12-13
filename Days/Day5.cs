
public class Day5 : IDay
{
    public string Step1(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var rules = parts[0].Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(r => r.Split('|').Select(int.Parse).ToArray()).ToArray();
        var updates = parts[1].Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToArray();

        var ok = new List<int>();
        foreach (var update in updates)
        {
            if (IsInRightOrder(update, rules))
            {
                ok.Add(MiddlePage(update));
            }
        }
        return ok.Sum().ToString();
    }

    private int MiddlePage(int[] update)
    {
        return update[update.Length / 2];
    }

    private bool IsInRightOrder(int[] update, int[][] rules)
    {
        for (int i = 0; i < update.Length; i++)
        {
            var pageNumber = update[i];
            var occurrences = rules.Where(r => r[0] == pageNumber).Select(r => r[1]).ToArray();
            if (update.Skip(i + 1).Any(n => !occurrences.Contains(n)))
                return false;
        }
        return true;
    }

    private int[] Fix(int[] update, int[][] rules)
    {
        var result = update.ToList();
        for (var nextIndex = 1; nextIndex < update.Length; nextIndex++)
        {
            var prev = result[nextIndex - 1];
            var toCheck = result[nextIndex];
            var occurrences = rules.Where(r => r[0] == prev).Select(r => r[1]).ToArray();
            if (occurrences.Contains(toCheck))
            {
                // result[nextIndex] = prev;
                // result[nextIndex - 1] = toCheck;
                result.Remove(toCheck);
                result.Insert(nextIndex - 1, toCheck);
                nextIndex = 0;
            }
        }
        return result.ToArray();
    }

    public string Step2(string input)
    {
        var parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var rules = parts[0].Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(r => r.Split('|').Select(int.Parse).ToArray()).ToArray();
        var updates = parts[1].Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToArray();

        var corrected = new List<int>();
        foreach (var update in updates)
        {
            if (!IsInRightOrder(update, rules))
            {
                var fix = Fix(update, rules);
                corrected.Add(MiddlePage(fix));
            }
        }
        return corrected.Sum().ToString();
        return string.Join(",", corrected);
    }

}