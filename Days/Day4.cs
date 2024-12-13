public class Day4 : IDay
{
    public string Step1(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var occurences = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == 'X')
                {
                    for (int dX = -1; dX <= 1; dX++)
                    {
                        for (int dY = -1; dY <= 1; dY++)
                        {
                            var found = LookXmas("word", lines, x, y, dX, dY);
                            if (found) occurences++;
                        }
                    }
                }
            }
        }
        return occurences.ToString();
    }

    private bool LookXmas(string word, string[] lines, int x, int y, int dX, int dY)
    {
        for (int i = 0; i < word.Length; i++)
        {
            var lookX = x + dX * i;
            var lookY = y + dY * i;
            if (lookX < 0 || lookX >= lines[0].Length || lookY < 0 || lookY >= lines.Length)
                return false;
            var charAt = lines[lookY][lookX];
            if (charAt != word[i])
                return false;
        }
        return true;
    }

    public string Step2(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var occurences = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == 'A')
                {
                    var comb = new int[][] {
                        [-1, 1],
                        [1, -1],
                        [-1, -1],
                        [1, 1]
                    };
                    if (comb.Count(c => LookXmas("MAS", lines, x - c[0], y - c[1], c[0], c[1])) == 2)
                        occurences++;
                }
            }
        }
        return occurences.ToString();
    }

}