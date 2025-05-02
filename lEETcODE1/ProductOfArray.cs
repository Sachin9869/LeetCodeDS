using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class ProductOfArray
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            //int[] answer = new int[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int product = 0;
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        if (i != j)
            //        {
            //            product = product * nums[j];
            //        }
            //    }
            //    answer[i] = product;
            //}
            //return answer;

            //Solution2
            //For efficiency
            //arr = [1,2,3,4]
            //left = [1,2,6,12] = left[i]=left[i]*left[i-1]
            //arr_out = product * left[i-1]
            //produt = product * left[i]

            //out = [24,12,8,6]

            int product = 1;
            int[] leftArray = new int[nums.Length];
            for (int i=0; i < nums.Length; ++i)
            {
                product = product * nums[i];
                leftArray[i] = product;
                //nums[i-nums.Length] = product * 
                //product = product * nums[i];
            }

            product = 1;
            for (int i=nums.Length-1; i>0; --i)
            {
                leftArray[i] = leftArray[i - 1] * product;
                product = product * nums[i];
            }
            leftArray[0] = product;
            return leftArray;
        }
    }  

}
