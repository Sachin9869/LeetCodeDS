using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lEETcODE1
{
    public class BinaryTree_MaximumDepth
    {
        public int MaxDepth(TreeNode root)
        {
            
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            treeNodes.Enqueue(root);
            int numberOfLevels = -1;

            while (true)
            {
                int nodeCountAtLevel = treeNodes.Count;
                if (nodeCountAtLevel == 0)
                {
                    return numberOfLevels;
                }

                while (nodeCountAtLevel > 0)
                {
                    TreeNode currElementQueue = treeNodes.Dequeue();
                    if (currElementQueue.left != null)
                        treeNodes.Enqueue(currElementQueue.left);
                    if (currElementQueue.right != null)
                        treeNodes.Enqueue(currElementQueue.right);
                    nodeCountAtLevel--;
                }
                numberOfLevels++;
            }
        }
    }
}
