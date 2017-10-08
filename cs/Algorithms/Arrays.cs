using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Arrays
    {
        public static int HourGlassSum(int[,] arr)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int sum = arr[i, j] + arr[i, j + 1] + arr[i, j + 2]
                                            + arr[i + 1, j + 1]
                            + arr[i + 2, j] + arr[i + 2, j + 1] + arr[i + 2, j + 2];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }
            return maxSum;
        }

        public static int coverPoints(List<int> A, List<int> B)
        {
            int ans = 0;
            for (int i = 1; i < A.Count(); i++)
            {
                ans = ans + (Math.Abs(A[i] - A[i - 1]) < Math.Abs(B[i] - B[i - 1]) ? Math.Abs(B[i] - B[i - 1]) : Math.Abs(A[i] - A[i - 1]));
            }
            return ans;
        }
    }
}
