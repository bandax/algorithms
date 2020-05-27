using System;
using System.Collections.Generic;
using System.Linq;

/*
You are driving a vehicle that has capacity empty seats initially available for passengers.
The vehicle only drives east (ie. it cannot turn around and drive west.)
Given a list of trips, trip[i] = [num_passengers, start_location, end_location] contains information about the i-th trip:
the number of passengers that must be picked up, and the locations to pick them up and drop them off.
The locations are given as the number of kilometers due east from your vehicle's initial location.
Return true if and only if it is possible to pick up and drop off all passengers for all the given trips.
Example 1:
---------
Input: trips = [[2,1,5],[3,3,7]], capacity = 4
Output: false
Example 2:
---------
Input: trips = [[2,1,5],[3,3,7]], capacity = 5
Output: true
Example 3:
----------
Input: trips = [[2,1,5],[3,5,7]], capacity = 3
Output: true
Example 4:
---------
Input: trips = [[3,2,7],[3,7,9],[8,3,9]], capacity = 11
Output: true
 */

/*
  t = number of trips
  d = distinct number of location
  Time complexity = O complexity O(t) + O(dictionary)
  Space complexity = O(d)
 */

namespace CarPooling
{
    public class CarPool
    {
        private readonly int passengersIndex = 0;
        private readonly int startLocationIndex = 1;
        private readonly int endLocationIndex = 2;

        private SortedDictionary<int, int> locations = new SortedDictionary<int, int>();
        public bool EvaluateTravel(int[][] trips, int capacity)
        {             
            for (int trip = 0; trip < trips.Length; trip++)
            {
                onBoardPassengers(trips[trip][startLocationIndex], trips[trip][passengersIndex]);
                offBoardPassengers(trips[trip][endLocationIndex], trips[trip][passengersIndex]);               
            }

            int availableSeats = capacity;            
            foreach (var item in locations)
            {
                availableSeats += item.Value;                
                if (availableSeats < 0) return false;
            }
            return true;

        }

        private void onBoardPassengers(int startLocationKey, int numberOfPassengers)
        {
            if (locations.ContainsKey(startLocationKey))
                locations[startLocationKey] += -numberOfPassengers;
            else
                locations[startLocationKey] = -numberOfPassengers;
        }

        private void offBoardPassengers(int endLocationKey, int numberOfPassengers)
        {
            if (locations.ContainsKey(endLocationKey))
                locations[endLocationKey] += numberOfPassengers;
            else
                locations[endLocationKey] = numberOfPassengers;
        }
    }

   
}
