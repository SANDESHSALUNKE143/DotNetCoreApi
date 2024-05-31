namespace Example.DynamicProgramming;

public class MaximumScorePath
{
    public (int,int,int) GetMaximumScorePath()
    {

        int[][] input= new int[][]
        {
        new []{5,4,5},
        new []{1,2,6},
        new []{7,4,6},
        };

        int rowCount = input.Length;
        int colCount = input[1].Length;

        Dictionary<string, DpObject> dp = new Dictionary<string, DpObject>();
        dp.Add($"0_0" ,new DpObject(new SortedSet<int>(),input[0][0])
        {
            Value = input[0][0],
            Path = input[0][0].ToString(),
        });

        //address first row
        for (int col = 1; col < colCount; col++)
        {
            dp.Add($"0_{col}" ,new DpObject(dp[$"0_{col-1}"].Heap,input[0][col] )
            {
                Value = dp[$"0_{col-1}"].Value + input[0][col],
                Path = dp[$"0_{col-1}"].Path + input[0][col],
            });
            

        }
        
        //address first column
        for (int row = 1; row < colCount; row++)
        {
            dp.Add($"{row}_0" ,new DpObject(dp[$"{row-1}_0"].Heap, input[row][0])
            {
                Value = dp[$"{row-1}_0"].Value + input[row][0],
                Path = dp[$"{row-1}_0"].Path + input[row][0],
            });

        }

        for (int row = 1; row < rowCount; row++)
        {
            for (int col = 1; col < colCount; col++)
            {
                var heap = dp[$"{row - 1}_{col}"].Value > dp[$"{row}_{col - 1}"].Value
                    ? dp[$"{row - 1}_{col}"].Heap
                    : dp[$"{row}_{col - 1}"].Heap;

                int value = Math.Max(dp[$"{row - 1}_{col}"].Value, dp[$"{row}_{col - 1}"].Value) +input[row][col];
                dp.Add($"{row}_{col}" ,new DpObject(heap,input[row][col])
                {
                    Value = value,
                    Path = dp[$"{row-1}_{col}"].Value >  dp[$"{row}_{col-1}"].Value ? 
                         "," +dp[$"{row-1}_{col}"].Path + input[row][col] 
                         : "," +dp[$"{row}_{col-1}"].Path  +input[row][col]
                    

                });

            }
            
        }
        return (dp[$"{rowCount-1}_{colCount-1}"].Value
            ,dp[$"{rowCount-1}_{colCount-1}"].Heap.Min
            , dp[$"{rowCount-1}_{colCount-1}"].Heap.Max);
    }
    
}

class DpObject
{
    public int Value { get; set; }
    public  string Path { get; set; }
    public SortedSet<int>  Heap { get; set; }

     public DpObject(SortedSet<int> sourceDat, int newVlaueToAdd)
     {
         Heap = new SortedSet<int>();

         while (sourceDat.Count > 0)
         {
             Heap.Add(sourceDat.Min);
             sourceDat.Remove(sourceDat.Min);
         }
         
         Heap.Add(newVlaueToAdd);

     }
}