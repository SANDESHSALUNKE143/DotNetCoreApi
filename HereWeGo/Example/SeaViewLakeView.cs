namespace Example;

public class SeaViewLakeView
{
    public List<int> ClearViewIndices(List<int> heights)
    {
        List<int> answer = new List<int>();
        int length = heights.Count;
        int maxHeight = heights[length - 1];
        //[5, 6, 2, 3, 1]
        answer.Add(length-1);

        for (int  building = heights.Count-2;  building >= 0; building--)
        {
            if (maxHeight < heights[building])
            {
                answer.Add(building);
            }
            maxHeight = Math.Max(maxHeight, heights[building]);
        }

        return answer;
    }
    
    public List<int> SeaviewUsingLeftToRightTraerse(List<int> heights)
    {
        List<int> result = new List<int>();

        SortedSet<Building> possibleIndices = new SortedSet<Building>();
        

        // Iterate through each building's height from left to right
        for (int i = 0; i < heights.Count; i++) {
            
            while (possibleIndices.Count > 0 && possibleIndices.Min.Value < heights[i])
            {
                //remove all prevoius possblle sea view
                possibleIndices.Remove(possibleIndices.Min);
            }

            possibleIndices.Add(new Building(i, heights[i]));
        }

        List<int> answers = new List<int>();
        while (possibleIndices.Count > 0)
        {
            Building min = possibleIndices.Min;
            answers.Add(min.Index);
            possibleIndices.Remove(min);
        }
        answers.Sort(new BuildingCompareByIndex());
        return answers;
    }
    
    public List<int> SeaPlusLakeView(List<int> heights)
    {
        List<int> result = new List<int>();
        List<int> answers = new List<int>();


        SortedSet<Building> possibleIndicesForSeaView = new SortedSet<Building>();
        SortedSet<Building> possibleIndicesForLakeView = new SortedSet<Building>();

        int maxHeightOnLeft = 0;
        // Iterate through each building's height from left to right
        for (int i = 0; i < heights.Count; i++) {
            
            while (possibleIndicesForSeaView.Count > 0 && possibleIndicesForSeaView.Min.Value < heights[i])
            {
                //remove all prevoius possblle sea view
                possibleIndicesForSeaView.Remove(possibleIndicesForSeaView.Min);
            }

            
            possibleIndicesForSeaView.Add(new Building(i, heights[i]));


            if (maxHeightOnLeft < heights[i])
            {
                answers.Add(i);
            }

            maxHeightOnLeft = Math.Max(maxHeightOnLeft, heights[i]);
        }

        while (possibleIndicesForSeaView.Count > 0)
        {
            Building min = possibleIndicesForSeaView.Min;
            if (!answers.Contains(min.Index))
            {
                answers.Add(min.Index);
            }
            possibleIndicesForSeaView.Remove(min);
        }
        answers.Sort(new BuildingCompareByIndex());
        return answers;
    }
    
    
}

public class Building:IComparable<Building>
{
    public int Index { get; set; }
    public  int Value { get; set; }

    public Building(int index, int value)
    {
        Index = index;
        Value = value;
    }

    public int CompareTo(Building other)
    {
        return Value.CompareTo(other.Value);
    }
}

public class BuildingCompareByIndex:IComparer<int>
{

    public int Compare(int a, int b)
    {
        if (a < b)
        {
            return -1;
            
        }
        else if (a > b)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
