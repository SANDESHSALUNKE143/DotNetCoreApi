namespace Example.BinarySearch;

public class MaximumDistance
{
    public double MaximumDistanceOnAdditionOfNewNodes(List<int> stations, int k)
    {
        // Binary search on the possible penalty values
        double left = 0;
        double right = stations[stations.Count - 1] - stations[0];
        
        while (right - left > 1e-6) {
            double mid = (left + right) / 2;
            if (CanPlaceStations(stations, k, mid)) {
                right = mid;
            } else {
                left = mid;
            }
        }

        return left;
    }

    private bool CanPlaceStations(List<int> stations, int k, double maxDistance) {
        int needed = 0;
        
        for (int i = 1; i < stations.Count; i++) {
            int count = (int)((stations[i] - stations[i - 1]) / maxDistance);
            needed += count;
            if (needed > k) {
                return false;
            }
        }
        
        return needed <= k;
    }
}