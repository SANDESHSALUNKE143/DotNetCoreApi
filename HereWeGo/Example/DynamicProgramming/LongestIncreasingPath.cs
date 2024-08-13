using System.Dynamic;

namespace Example.DynamicProgramming;

public class LongestIncreasingPath
{
    
    public int GetLongestIncreasingPath()
    {
        List<List<int>> input = new List<List<int>>();
        input.Add(new List<int>(){9,8,3});
        input.Add(new List<int>(){7,4,2});
        input.Add(new List<int>(){8,5,1});

        int rowCount = input.Count;
        int colCount = input[0].Count;


        Dictionary<string, DpItem> dictionary = new Dictionary<string, DpItem>();
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                dictionary.Add($"{row}_{col}", new DpItem(){MaxValue = -1});
            }
        }

        int answer = 0;
        DpItem item;
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            { 
                item = Dfs(row, col, -1, input, dictionary);
                answer = Math.Max(answer, item.MaxValue) ;
            }
        }


        return answer;
    }

    DpItem Dfs(int row, int col, int previousValue, List<List<int>> input,Dictionary<string, DpItem> dictionary)
    {
        if (row < 0 || row == input.Count || col < 0 || col == input[0].Count || previousValue > input[row][col])
        {
            return new DpItem(){MaxValue = 0};
        }

        if (dictionary[$"{row}_{col}"].MaxValue != -1)
        {
            return dictionary[$"{row}_{col}"];
        }
        
        //check directions
        int ans = 1;

        int[][] directions = new int[][]
        {
            new int[]{-1,0},
            new int[]{1,0},
            new int[]{0,1},
            new int[]{0,-1}
        };

        List<int> path = new List<int>(){input[row][col]};

        foreach (var dir in directions)
        {
            int x = row + dir[0];
            int y = col + dir[1];
            if (x >= 0 && x < input.Count && y >= 0 && y < input[0].Count && input[x][y] >  input[row][col])
            {
                DpItem newAnser = Dfs(x, y, input[row][col], input, dictionary);
                if (newAnser.MaxValue + 1 > ans)
                {
                    ans = newAnser.MaxValue + 1;
                    path = new List<int>(){input[row][col]};
                    path.AddRange(newAnser.Paths);
                }
            }   
        }
        
        dictionary[$"{row}_{col}"] = new DpItem(){MaxValue = ans, Paths = path};
        return dictionary[$"{row}_{col}"];
    }
    
    
}

class DpItem
{
    public  int MaxValue { get; set; }
    public  List<int>  Paths { get; set; }

    public DpItem()
    {
        Paths = new List<int>();
    }
}