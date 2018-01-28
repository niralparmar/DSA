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

        public static void FinalPrice(int[] prices)
        {
            int total = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] <= prices[i])
                {
                    total += prices[i] - prices[i + 1];
                }
                else
                {

                    int minValue = FindMin(prices, i);
                    if (minValue == 0)
                    {
                        sb.Append(i);
                        sb.Append(" ");
                    }
                    total += prices[i] - minValue;
                }
            }
            total += prices[prices.Length - 1];
            sb.Append(prices.Length - 1);
            Console.WriteLine(total);
            Console.WriteLine(sb.ToString());
        }
        public static int FindMin(int[] prices, int currentIndex)
        {
            int minValue = 0;
            for (int i = currentIndex + 1; i < prices.Length; i++)
            {
                if (prices[currentIndex] > prices[i])
                {
                    return prices[i];
                }
            }

            return minValue;
        }

        public static void FinalPriceNew(int[] prices)
        {
            int PriceSum = 0;
            List<int> lst = new List<int>();
            int currentPrice = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                currentPrice = prices[i-1];
                int Minprice = 0;
                for (int j = i; j < prices.Length; j++)
                {

                    if (prices[j] <= currentPrice)
                    {
                        Minprice = prices[j];
                        break;
                    }
                }
                PriceSum += currentPrice - Minprice;
                if ((currentPrice - Minprice) >= currentPrice)
                {
                    if (i == prices.Length - 1)
                    {
                        lst.Add(i);
                    }
                    else
                    {
                        lst.Add(i - 1);
                    }
                    
                }

            }
            //lst.Add(prices.Length - 1);
            //PriceSum += prices[prices.Length - 1];

            Console.WriteLine(PriceSum);

            foreach (int val in lst)
            {
                Console.Write(val + " ");
            }


        }

        public static void FindPair(int[] arr,int sum)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if(map.ContainsKey(sum-arr[i])){
                    Console.WriteLine("[" + map[sum - arr[i]] + "," + i + "]");
                    return;
                }
                map[arr[i]] = i;
            }


        }
    }
}
