using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 *  In a town, there are N people labelled from 1 to N.  There is a rumor that one of these people is secretly the town judge.

    If the town judge exists, then:
    1. The town judge trusts nobody.
    2. Everybody (except for the town judge) trusts the town judge.

    There is exactly one person that satisfies properties 1 and 2.

    You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.

    If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.

    Example 1:
    --------
    Input: N = 2, trust = [[1,2]]
    Output: 2

    Example 2:
    --------
    Input: N = 3, trust = [[1,3],[2,3]]
    Output: 3

    Example 3:
    ---------
    Input: N = 3, trust = [[1,3],[2,3],[3,1]]
    Output: -1

    Example 4:
    ---------
    Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
    Output: 3
 * 
 * 
 */

namespace TownJudge.Graph
{
    /// <summary>
    ///  Class used to check exist a Judge in a people town based on array of trust relationships and the number of people in the town
    /// </summary>
    /// <remarks>
    ///     There is a method called GetJudge that return the person who is the judge in the town
    /// </remarks>
    public class PeopleTown
    {
        private readonly int _personTrustFromIndex = 0;
        private readonly int _personTrustToIndex = 1;

        private int[] _peopleTrustIn;
        private int[] _peopleTrustOut;

  
        
        /// <summary>
        /// Return the person (integer) who is the judge based on the trusted array parameter
        /// </summary>
        /// <param name="N">Number of person in the town</param>
        /// <param name="trust">Array of arrays with the people in the town and the trust relationships. For example [[1,3] [2,3]]. Person 1 and 2 trust in person 3</param>
        /// <returns>
        /// The person(integer) who is the judge of the town follow by next rules:
        ///  1. The town judge trusts nobody.
        ///  2. Everybody(except for the town judge) trusts the town judge.
        /// </returns>
        public int GetJudge(int N, int[][] trust)
        {
            this._peopleTrustIn = new int[N+1];
            this._peopleTrustOut = new int[N+1];
            int minPerson = N;
            for(int relationIndex = 0; relationIndex < trust.Length; relationIndex++)
            {
                // Get person who trust to someone else 
                int personTrustOut = trust[relationIndex][this._personTrustFromIndex];

                // Get the min person to use in the next loop to avoid start from not requied value like 0
                if (personTrustOut < minPerson) minPerson = personTrustOut;

                // Get person that someone else trust on
                int personTrustIn = trust[relationIndex][this._personTrustToIndex];

                // Increment peopleTrustIn by one because a new person is trusted on this person
                this._peopleTrustIn[personTrustIn]++;

                // Increment peopleTrustOut by one because the person is trusted in someone else
                this._peopleTrustOut[personTrustOut]++;

            }

            // Loop to check if some person is the judge based on the 2 rules of the requierment
            for(int person = minPerson; person <= N; person++)
            {
                // this._peopleTrustOut[person] == 0 -> person does not trust someone else
                // this._peopleTrustIn[person] == N-1 -> people from town trust on this person
                if (this._peopleTrustOut[person] == 0 && this._peopleTrustIn[person] == (N - 1))
                    return person;
            }

            return -1;
        }


    }    
}
