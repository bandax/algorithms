using System;
using Xunit;
using TownJudge.Graph;

namespace TownJudge.Tests
{  
    public class PeopleTownTests
    {
        [Fact]
        public void GetJudge_OneTrust_ReturnsValidJudge()
        {
            int[][] trust = new int[][] { new int[] { 1, 2 } };
            int N = 2;
            int expectedJudge = 2;

            var peopleTown = new PeopleTown();
            int resultJudge = peopleTown.GetJudge(N, trust);

            Assert.Equal(expectedJudge, resultJudge);
        }

        // Example 2:
        // --------
        // Input: N = 3, trust = [[1,3],[2,3]]
        // Output: 3
        [Fact]
        public void GetJudge_TwoTrust_ReturnsValidJudge()
        {
            int[][] trust = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } };
            int N = 3;
            int expectedJudge = 3;

            var peopleTown = new PeopleTown();
            int resultJudge = peopleTown.GetJudge(N, trust);

            Assert.Equal(expectedJudge, resultJudge);
        }

        //Example 3:
        //---------
        //Input: N = 3, trust = [[1,3],[2,3],[3,1]]
        //Output: -1
        [Fact]
        public void GetJudge_ThreeTrustedRelations_ReturnsNotValidJudge()
        {
            int[][] trust = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 1} };
            int N = 3;
            int expectedJudge = -1;

            var peopleTown = new PeopleTown();
            int resultJudge = peopleTown.GetJudge(N, trust);

            Assert.Equal(expectedJudge, resultJudge);
        }


        //Example 4:
        //---------
        //Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
        //Output: 3
        [Fact]
        public void GetJudge_SeveralTrustedRelations_ReturnsValidJudge()
        {
            int[][] trust = new int[][] {   new int[] { 1, 3 },
                                            new int[] { 1, 4 },
                                            new int[] { 2, 3 },
                                            new int[] { 2, 4 },
                                            new int[] { 4, 3 }
                                        };
            int N = 4;
            int expectedJudge = 3;

            var peopleTown = new PeopleTown();
            int resultJudge = peopleTown.GetJudge(N, trust);

            Assert.Equal(expectedJudge, resultJudge);
        }

    }
}
