using System;
using Xunit;
using CarPooling;

namespace CarPooling.Tests
{
    
    public class CarPoolTests
    {
        [Fact]
        public void CarPool_TakeOneTrip_Success()
        {
            int[][] trips = new int[][] { new int[] { 3, 2, 7 }};
            int capacity = 11;
            CarPool car = new CarPool();
            bool takeTravel = car.EvaluateTravel(trips, capacity);

            Assert.True(takeTravel);
        }

        [Fact]
        public void CarPool_TakeTwoTrips_WithRequiredCapacity_ShouldSucess()
        {
            int[][] trips = new int[][] { new int[] { 2, 1, 5 }, new int[] { 3, 3, 7 } };
            int capacity = 5;
            CarPool car = new CarPool();
            bool takeTravel = car.EvaluateTravel(trips, capacity);

            Assert.True(takeTravel);
        }

        [Fact]
        public void CarPool_TakeTwoTrips_WithMoreThanCapacity_ShouldFails()
        {
            int[][] trips = new int[][] { new int[] { 2, 1, 5 }, new int[] { 3, 3, 7 } };
            int capacity = 4;
            CarPool car = new CarPool();
            bool takeTravel = car.EvaluateTravel(trips, capacity);

            Assert.False(takeTravel);
        }

        [Fact]
        public void CarPool_TakeThreeTrips_WithRequiredCapacity_ShouldSucess()
        {
            int[][] trips = new int[][] { new int[] { 3, 2, 7 }, new int[] { 3, 7, 9 }, new int[] { 8, 3, 9 } };
            int capacity = 11;
            CarPool car = new CarPool();
            bool takeTravel = car.EvaluateTravel(trips, capacity);

            Assert.True(takeTravel);
        }
    }
}
