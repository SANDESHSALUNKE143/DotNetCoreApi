namespace Example;

public class PrintDiagonalOfMatrix
{
    public string PrintDiagonal()
    {
        List<List<int>> matrix = new List<List<int>>();
        matrix.Add(new List<int>(){1,2,3});
        matrix.Add(new List<int>(){4,5,6});
        matrix.Add(new List<int>(){7,8,9});

        int rowCount = matrix.Count;
        int colCount = matrix[0].Count;

        List<int> answer = new List<int>();

        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        
        for (int row = 0; row < rowCount; row++)
        {
            for (int col= 0; col < colCount; col++)
            {
                if (!map.ContainsKey(row + col))
                {
                    map.Add(row+col , new List<int>());
                }
                map[row+col].Add(matrix[row][col]);
            }
        }

        foreach (var key in map.Keys)
        {
            if (key % 2 == 0 )
            {
                map[key].Reverse();
                answer.AddRange(map[key]);

            }
            else
            {
                answer.AddRange(map[key]);

            }
        }

        return string.Join(',', answer);
    }
}