namespace Example.BinarySearch;

public class BinarySearch
{
    public int FindElementInArray(List<int> input, int k)
    {
        int l = 0;
        int r = input.Count - 1;
        while (l < r)
        {
            int mid = l + (r - l) / 2;

            if (k == input[mid])
            {
                return 1;
            }

            if (k < input[mid])
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return 0;
    }


    public int FindFirstOccurrence(List<int> input, int k)
    {
        int l = 0;
        int r = input.Count - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (input[mid] == k)
            {
                //check for occurence

                while (input[mid] == k)
                {
                    mid--;
                }

                return mid + 1;
            }

            if (k < input[mid]) //move left
            {
                r = mid - 1;
            }

            if (k > input[mid]) //move right
            {
                l = mid + 1;
            }
        }

        return -1;
    }

    //2 2 3 3 5 3
    //2 2 3 4 4 
    public int FindUniqueElement(List<int> input)
    {
        int l = 0;
        int r = input.Count - 1;

        if (input[0] != input[1])
        {
            return input[0];
        }

        if (input[r] != input[r - 1])
        {
            return input[r];
        }

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (input[mid] != input[mid - 1] && input[mid] != input[mid + 1])
            {
                return input[mid];
            }

            int firstOccurence = 0;
            if (input[mid] == input[mid - 1])
            {
                firstOccurence = mid - 1;
            }
            else
            {
                firstOccurence = mid;
            }

            if (firstOccurence % 2 == 0) //target is on right
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return -1;
    }


    public int FindPeak(List<int> input)
    {
        int l = 0;
        int r = input.Count - 1;

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            //check if mid is peak
            if (input[mid] > input[mid - 1] && input[mid] > input[mid + 1])
            {
                return input[mid];
            }

            if (input[mid] < input[mid + 1])
            {
                //move right

                l = mid + 1;
            }

            if (input[mid] > input[mid + 1])
            {
                //move left

                r = mid - 1;
            }
        }

        return -1;
    }


    public int LocalMinima(List<int> input)
    {
        int l = 0;
        int r = input.Count - 1;

        // edge case
        if (input[0] < input[1])
        {
            return input[0];
        }

        if (input[r] < input[r - 1])
        {
            return input[r];
        }

        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (input[mid] < input[mid-1]  && input[mid] < input[mid+1])
            {
                return input[mid];
            }
            
            //check for deep
            if (input[mid] < input[mid +1])
            {
                
                //deep is on left side so move left

                r = mid - 1;
            }
            
            //check for deep
            if (input[mid] > input[mid +1])
            {
                
                //deep is on right side so move right

                l = mid + 1;
            }
        }

        return -1;
    }

    //10 20 30 1 4 5
    public int FindInRotatedArray(List<int> input, int k)
    {
        //get peak

        int l = 0;
        int r = input.Count - 1;

        if (input[0] == k)
        {
            return 0;
        }
        
        if (input[r] == k)
        {
            return r;
        }

        while (l <= r )
        {
            int mid = l + (r - l) / 2;
            if (input[mid] == k)
            {
                return mid;
            }
            
            //check where is target

            if (input[0] < k)
            {
                //target is in first part
                
                //check mid

                if (input[mid] < input[0])
                {
                    //mid is in second part so  move left
                    r = mid - 1;

                }
                else
                {
                    //mid is in first part and k is in first part

                    if (input[mid] < k)
                    {
                        //move right 
                        l = mid + 1;
                    }
                    else
                    {
                        //move left
                        r = mid - 1;
                    }
                }
            }
            else //target in second part
            {
                //check mid

                if (input[mid] < input[0])
                {
                    // mid is in second part
                    //both target and mid in second part, so check for k
                    if (input[mid] < k)
                    {
                        //move right
                        l = mid + 1;
                    }
                    else
                    {
                        //move left
                        r = mid - 1;
                    }
                }
                else
                {
                    //move left
                    r = mid -1;
                }
            }

        }

        return -1;
    }

    public int FindSquareRoot(int number)
    {
        int l = 0;
        int r = number ;
        int answer = 0;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;

            if (mid  == number/mid)
            {
                return mid;
            }

            if (mid  < number /mid)
            {
                // go right
                l = mid + 1;
                answer = mid;
            }
            else
            {
                //go left
                r = mid - 1;
            }
        }

        return answer;
    }

    public int MagicalNumber(int A, int B, int C)
    {
        int l = 0;
        int r = A * Math.Min(B, C);

        long lcm = LCM(B, C);
        long answer = 0;
        while (l <=  r)
        {
            //find mid

            int mid = l + (r - l) / 2;

            long count = mid / B + mid / C - mid / lcm;

            

            if (count < A)
            {
                //go right
                l = mid + 1;
            }
            else if (count > A)
            {
                r = mid - 1;
            }
            else
            {
                answer = mid;
                r = mid - 1;
            }
        }

        return (int)answer;
    }

    private long LCM(int x, int y)
    {
        return (long) (x * y)/ GCD(x,y);
    }

    private int GCD(int x, int y)
    {
        if (x == 0)
        {
            return y;
        }

        return GCD(y % x, x);
    }
}