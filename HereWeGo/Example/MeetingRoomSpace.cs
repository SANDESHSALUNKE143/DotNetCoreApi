using System.Collections.Immutable;

namespace Example;

public class MeetingRoomSpace
{
    public int FindSpaceWithMaximumMeetings(int space)
    {
        List<Meetings> meetingsList = new List<Meetings>();
        meetingsList.Add(new Meetings("M1", 0,7));
        meetingsList.Add(new Meetings("M2", 1,5));
        meetingsList.Add(new Meetings("M3", 4,6));
        
        //sort meet by start time
        meetingsList.OrderBy(x => x.StartTime);

        var minHeap = new SortedDictionary<int, Queue<int>>();
        
        //add all space
        for (int i = 0; i < space; i++)
        {
            if (!minHeap.ContainsKey(0))
            {
                minHeap.Add(0, new Queue<int>() );
                
            }
            
            minHeap[0].Enqueue(i);
        }

        int[] meetingsCountss = new int[space];
        
        foreach (Meetings meetings in meetingsList)
        {
            //get availeble space
            var earliestEndTime = minHeap.Keys.First();

            var spaceQueue = minHeap[earliestEndTime];

            int spacex = spaceQueue.Dequeue();
            
            // If the queue for this end time is now empty, remove it from the dictionary
            if (spaceQueue.Count == 0)
            {
                minHeap.Remove(earliestEndTime);
            }
            
            //update enedtime for spave
            int newEndTime = meetings.EndTime;
            if (!minHeap.ContainsKey(newEndTime))
            {
                minHeap.Add(newEndTime, new Queue<int>());
            }
            minHeap[newEndTime].Enqueue(spacex);
            meetingsCountss[spacex]++;
        }

        int maxCountSpace = Int32.MinValue;
        int answer = 0;
        for (int i = 0; i < meetingsCountss.Length; i++)
        {
            if (maxCountSpace < meetingsCountss[i])
            {
                answer = i;
                maxCountSpace = meetingsCountss[i];
            }
        }
        return answer ;
    }
}

class Meetings
{
    public  int StartTime { get; set; }
    public  int MeetingTime { get; set; }
    public int EndTime { get; set; }
    public  string MeetingName { get; set; }

    public Meetings( string meetingName,int startTime, int meetingTime)
    {
        StartTime = startTime;
        MeetingName = meetingName;
        MeetingTime = meetingTime;
        EndTime = startTime + meetingTime;
    }
}