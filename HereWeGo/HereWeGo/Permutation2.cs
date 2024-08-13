namespace HereWeGo;



public class Permutation2 {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>>  resultList = new List<IList<int>>();
        bool[] used=new bool[nums.Length];

        BackTrack(resultList,new List<int>(),used, nums);

        return resultList;
    }

    private void BackTrack(IList<IList<int>> resultList,IList<int> tempList,bool[] used,int[] nums  )
    {

        if(tempList.Count ==nums.Length  )
        {
            bool isDuplicate=false;
            foreach(var s in resultList)
            {
                if(s.SequenceEqual(tempList))
                {
                    isDuplicate=true;
                }
            }
            
            if(!isDuplicate)
            {
                resultList.Add(new List<int>(tempList));
            }
            return;
        }

        for(int i=0; i< nums.Length; i++)
        {
            if(used[i])
            {
                continue;
            }

 
            used[i]=true;
            tempList.Add(nums[i]);
           

            BackTrack(resultList,tempList,used,nums );
                        
            used[i]=false;

        
            tempList.RemoveAt(tempList.Count-1);

        }
        

       
    }
}




