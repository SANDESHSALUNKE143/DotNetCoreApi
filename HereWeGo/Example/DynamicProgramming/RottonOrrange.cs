namespace Example;

public class RottonOrrange
{
    static void Rotton()
    {
        int[][] grid = new int[][]
        {
            new int[]{2,1,5},
            new int[]{1,1,0},
            new int[]{0,1,1}

         };

         int [][] delay = new int[][]
         {
            new int[]{1,1,1},
            new int[]{1,1,0},
            new int[]{0,2,1}

         };


         int rowCount = grid.Length;
         int colCount = grid[0].Length;

         Queue<(int,int,int,int)> ledger = new Queue<(int, int, int, int)>();
        int totalFreshFruits = 0;

        for(int row = 0; row <rowCount; row++)
        {
            for(int col = 0; col <colCount; col++)
            {
                if(grid[row][col] == 2 || grid[row][col] == 5)
                {
                    ledger.Enqueue((row,col,grid[row][col],delay[row][col]));
                }
                else if(grid[row][col] == 1)
                {
                    totalFreshFruits++;
                }
            }
        }

        //define directions

        int[][] normalDirections = new int[][]{
            new int[]{-1,0},
            new int[]{1,0},
            new int[]{0,1},
            new int[]{0,-1},

        };


        int[][] powerDirections = new int[][]{
            new int[]{-1,0},
            new int[]{1,0},
            new int[]{0,1},
            new int[]{0,-1},
            new int[]{-2,0},
            new int[]{2,0},
            new int[]{0,2},
            new int[]{0,-2},
            new int[]{1,1},
            new int[]{-1,-1}
        };

        int timeElapsed = 0;
        while(ledger.Count > 0)
        {
            (int row, int col, int power, int waitTime) = ledger.Dequeue();

            if(waitTime >= timeElapsed)
            {
                ledger.Enqueue((row,col,power,waitTime-1));
                timeElapsed++;
                continue;
            }

            //decide directions
            int[][] chosenDirection = power == 5? powerDirections: normalDirections;

            foreach(int[] dir in chosenDirection)
            {
                int newR = dir[0] + row ;
                int newC = dir[1] + col;

                if(newR >= 0 && newR < rowCount 
                && newC >= 0 && newC < colCount && grid[newR][newC] == 1)
                {
                    //mark rotten
                    grid[newR][newC] = 2;
                    totalFreshFruits--;

                    ledger.Enqueue((newR, newC,2,  delay[newR][newC]));

                    // timeElapsed = Math.Max(timeElapsed, delay[newR][newC] + waitTime);
                }
            }


        }

        if(totalFreshFruits != 0)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine("timeElapsed "+ timeElapsed);
        }



    }
}