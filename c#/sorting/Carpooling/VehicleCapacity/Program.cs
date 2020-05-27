using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPooling;

namespace VehicleCapacity
{
    class Program
    {
        /*
         * Input: trips = [[2,1,5],[3,3,7]], capacity = 4Output: false
         * 
         * Input: trips = [[2,1,5],[3,3,7]], capacity = 5Output: true
         * 
         * Input: trips = [[3,2,7],[3,7,9],[8,3,9]], capacity = 11Output: true
         */
        static void Main(string[] args)
        {
            int[][] trips = new int[][] { new int[]{ 3, 2, 7 }, new int[]{ 3, 7, 9 }, new int[] { 8, 3, 9 } };            
            int capacity = 11;
            CarPool car = new CarPool();            
            Console.WriteLine(car.EvaluateTravel(trips, capacity));
            Console.ReadKey();
        }        
    }
}
