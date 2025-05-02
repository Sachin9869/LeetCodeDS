using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class MaximumPathSum_BT
    {
        private int max = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            postOrderSum(root);
            return max;
        }

        public int postOrderSum(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = Math.Max(postOrderSum(root.left), 0);
            int right = Math.Max(postOrderSum(root.right), 0);
            max = Math.Max(max, (left + right + root.val));
            return Math.Max(left, right) + root.val;
        }
    }
}
