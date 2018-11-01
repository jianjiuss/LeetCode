using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution60
    {
        public string GetPermutation(int n, int k)
        {
            List<int> array = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                array.Add(i);
            }

            var list = GetPermutation2(array, k);

            StringBuilder stringBuilder = new StringBuilder();
            foreach(var i in list)
            {
                stringBuilder.Append(i);
            }
            return stringBuilder.ToString();
        }

        public List<int> GetPermutation2(List<int> array, int k)
        {
            int n = array.Count;
            if(n == 1)
            {
                if(k == 1)
                {
                    return array;
                }
                else
                {
                    return null;
                }
            }

            if (n == 2)
            {
                if(k == 1)
                {
                    return array;
                }
                else if(k == 2)
                {
                    return new List<int>() { array[1], array[0]};
                }
                else
                {
                    return null;
                }
            }

            int curPermutationCount = 1;
            for(int i = 1; i <= n; i++)
            {
                curPermutationCount *= i;
            }

            //int lastPermutationCount = curPermutationCount / n;

            int headIndex = GetHeadIndex(curPermutationCount, n, k);
            int nextK = GetNextK(curPermutationCount, n ,k);

            int head = array[headIndex];
            if(headIndex > k)
            {
                return null;
            }

            array.RemoveAt(headIndex);
            List<int> lastPermutation = GetPermutation2(array, nextK);

            if(lastPermutation == null)
            {
                return null;
            }

            List<int> curPermutation = new List<int>() { head };
            curPermutation.AddRange(lastPermutation);
            return curPermutation;
        }

        int GetHeadIndex(int permutationCount, int n, int k)
        {
            int lastPermutationCount = permutationCount / n;
            return k % lastPermutationCount == 0 ? k / lastPermutationCount - 1 : k / lastPermutationCount;
        }

        int GetNextK(int permutationCount, int n, int k)
        {
            int lastPermutationCount = permutationCount / n;
            int nextK = k % lastPermutationCount;
            return nextK == 0 ? lastPermutationCount : nextK;
        }
    }
}
