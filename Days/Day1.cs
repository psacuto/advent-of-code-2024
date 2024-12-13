public class Day1 : IDay
{
    public string Step1(string input)
    {
        var numbers = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

        var l0 = numbers.Select(x => x[0]).Order();
        var l1 = numbers.Select(x => x[1]).Order();

        var zip = l0.Zip(l1);

        var sum = zip.Select(x => Math.Abs(x.First - x.Second)).Sum();

        return sum.ToString();
    }

    public string Step2(string input)
    {
        var numbers = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        var l0 = numbers.Select(x => x[0]);
        var l1 = numbers.Select(x => x[1]).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

        var sum = l0.Select(x => x * (l1.ContainsKey(x) ? l1[x] : 0)).Sum();
     
        return sum.ToString();
    }
}