// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

//LeetCode 1
int[] nums1 = [0]; //1, 2, 3, 0, 0, 0
int[] nums2 = [1]; //2, 5, 6
var filteredArray1 = nums1.Where(x => x != 0).OrderBy(x => x).ToArray();
var filteredArray2 = nums2.Where(x => x != 0).OrderBy(x => x).ToArray();
filteredArray1 = filteredArray1.Concat(filteredArray2).ToArray();
filteredArray1 = filteredArray1.Where(x => x != 0).OrderBy(x => x).ToArray();
for (int i = 0; i < filteredArray1.Length; i++)
    Console.WriteLine("LeetCode1 - " + filteredArray1[i]);

//LeetCode2
int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
int val = 2;
nums = nums.Where(x => x != val).ToArray();
Console.WriteLine("LeetCode2 - " + nums.Length);


//LeetCode3
int[] numsArr = [1, 1, 2, 3, 4, 5, 5, 6];
List<int> output = new List<int>();
for (int i = 0; i < numsArr.Length; i++)
{
    if (!output.Contains(numsArr[i]))
        { output.Add(numsArr[i]); }
}
Console.WriteLine("LeetCode3 - " + output.Count());


//LeetCode4
int[] nummsDup = [0, 0, 1, 1, 1, 1, 2, 3, 3];
List<int> dupop = new List<int>();
for (int i=0; i < nummsDup.Length; i++)
{
    if(dupop.Count(s => s == nummsDup[i]) < 2)
        dupop.Add(nummsDup[i]);
}
Console.WriteLine("LeetCode4 - " + dupop.Count());


//LeetCode5
int[] numMaj = [2, 2, 1, 1, 1, 2, 2, 5, 5, 5, 7, 7, 5, 5]; 
int count = 0;
int maxCount = 0;
int outVar = 0;
numMaj = numMaj.OrderBy(s => s).ToArray();
for (int i=0; i < numMaj.Length; i = i+count)
{
    count = numMaj.Count(s => s == numMaj[i]);
    if (count > maxCount)
    {
        outVar = numMaj[i];
        maxCount = count;
    }
}
Console.WriteLine("LeetCode5 - " + outVar);


//LeetCode6
int[] rotArr = [1, 2]; //[1234567], k=4, 7123456,6712345,5671234,4567123 -- 123 4567 321 7654 3217654 4567123
int k = 3;
k = k % rotArr.Length;
if (k < 0) k += rotArr.Length;
if (k == 0) return;
if (rotArr.Length > 1 && rotArr.Length > k)
{
    Array.Reverse(rotArr, 0, rotArr.Length - k);
    Array.Reverse(rotArr, rotArr.Length - k, k);
    Array.Reverse(rotArr);
}


//Leetcode7
int[] maxProfArray = [2, 4, 1];
int maxProfit = 0;
int buy = 0;
for (int i = 0; i <  maxProfArray.Length; i++)
{
    if (i == 0)
        buy = maxProfArray[i];
    else
    {
        if(i < maxProfArray.Length-1 && buy > maxProfArray[i])
        { 
            buy = maxProfArray[i];
            //maxProfit = 0;
        }
        else
        {
            if (maxProfArray[i] - buy > maxProfit)
                maxProfit = maxProfArray[i] - buy;
        }
    }
}
Console.WriteLine("LeetCode7- " + maxProfit);


//LeetCode8 [7,1,5,3,6,4]
int profit = 0;
int buying = 0;
for (int i = 0; i < maxProfArray.Length; i++)
{
    if (i == 0)
        buying = maxProfArray[i];
    else
    {
        if (maxProfArray[i] > buying)
        {
            profit = profit + maxProfArray[i] - buying;
            buying = maxProfArray[i];
        }
        else
        {
            buying = maxProfArray[i];
        }
    }
}


//LeetCode9
int[] jumpArr = [2, 3, 1, 1, 4];
if (jumpArr.Length == 1) Console.WriteLine("LeetCode9- " + true);
if (jumpArr[0] == 0) Console.WriteLine("LeetCode9- " + false);
int currentLength = 0;
while (currentLength < jumpArr.Length-1)
{
    if (jumpArr[0] == 0) Console.WriteLine("LeetCode9- " + false);
    else if (currentLength == jumpArr.Length - 1) Console.WriteLine("LeetCode9- " + true);
    else
        currentLength = currentLength + jumpArr[currentLength];
}
if (currentLength > jumpArr.Length)
    Console.WriteLine("LeetCode9- " + false);


//LeetCode11
int[] citations = [3, 0, 6, 1, 5];
int countCit = 0;
if (citations.Length == 0) Console.WriteLine("LeetCode11- " + countCit);
citations = citations.OrderByDescending(x =>  x).ToArray();
for (int i=0; i < citations.Length; i++)
{
    if (citations[i] >= i+1)
        countCit = i+1;
}


//LeetCode13
int product = 1;
nums = [1, 2, 3, 4];
int[] leftArray = new int[nums.Length];
for (int i = 0; i < nums.Length; ++i)
{
    if (i > 0)
        product = nums[i] * nums[i - 1];
    leftArray[i] = product;
    //nums[i-nums.Length] = product * 
    //product = product * nums[i];
}

product = 1;
for (int i = nums.Length - 1; i > 0; --i)
{
    leftArray[i] = leftArray[i - 1] * product;
    product = product * nums[i];
}
leftArray[0] = product;
Console.WriteLine("LeetCode13- " + leftArray);
//return leftArray;


//LeetCode16
string s = "MCMXCIV";
Dictionary<char, int> roman = new();
roman.Add('I', 1);
roman.Add('V', 5);
roman.Add('X', 10);
roman.Add('L', 50);
roman.Add('C', 100);
roman.Add('D', 500);
roman.Add('M', 1000);
char[] sArr = s.ToArray();
int total = 0;
for (int i=0; i < sArr.Length-1; i++)
{
    if (roman[sArr[i]] < roman[sArr[i+1]])
    {
        total = total - roman[sArr[i]];
    }
    else
        total= total + roman[sArr[i]];
}
Console.WriteLine("LeetCode16- "+ (total + roman[sArr[sArr.Length - 1]]));


//LeetCode17
int numsVal = 3749;
int[] values = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
string[] symbols = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
string romanStr = "";
for (int i=0; i < values.Length && numsVal > 0; i++)
{
    while (numsVal >= values[i])
    {
        numsVal = numsVal - values[i];
        romanStr += values[i];
    }
}
Console.WriteLine("LeetCode17- "+ romanStr);


//LeetCode18
string Str = "   fly me   to   the moon  ";
string[] strArr = Str.Trim().Split(" ");
Console.WriteLine("LeetCode18- "+ strArr[strArr.Length - 1].ToArray().Count());


//LeetCode19
//Str = ["flower","flow","flight"];
string[] strArrPresdsd = ["flower", "flow", "flight"];

string[] sortArray = strArrPresdsd.OrderBy(x => x.Length).ToArray();
// Find the index of the shortest string
//int ind = Array.IndexOf(strArrPresdsd, shortestValue);
string pref = "";
for (int i = 0; i < sortArray[0].Length; i++)
{
    //if (strArrPresdsd[0][i].ToString() == strArrPresdsd[1][i].ToString() && strArrPresdsd[0][i].ToString() == strArrPresdsd[2][i].ToString())
    //    pref = pref + strArrPresdsd[0][i].ToString();
    string curr = sortArray[0][i].ToString();
    for (int j=1; j < sortArray.Length; j++)   //[0][0]  [1][0]  [2][0]
    {
        string firstarray = sortArray[0][i].ToString();
        string secondarray = sortArray[j][i].ToString();
        if (curr != sortArray[j][i].ToString())
        {
            curr = "";
            break;
        }
    }
    if (curr == "")
        break;
    else
        pref = pref + curr.ToString();
}

Console.WriteLine("LeetCode19- "+ pref);


//LeetCode20
Str = "   fly me   to   the moon  ";
Str = Str.Trim();
string[] splitArr = Str.Split(" ");
string outputStr = "";
for (int i= splitArr.Length-1; i >= 0; i--)
{
    if(outputStr == "")
        outputStr += splitArr[i].ToString();
    else if(splitArr[i].ToString() != "")
        outputStr += " " + splitArr[i].ToString();
}
Console.WriteLine("LeetCode20- "+ outputStr);

//LeetCode21
s = "Tracy, no panic in a pony-cart.";
//Regex rgx = new Regex("[^a-zA-Z0-9 -]");
//str = rgx.Replace(str, "");
s = new string(s.ToLower().Trim().Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray());
char[] p = s.Replace("--", "").ToCharArray();
Array.Reverse(p);
string rev = new string(p);
if (s.Replace(" ", "") == rev.Replace(" ", ""))
    s = "true"; 
Console.WriteLine(s);


//LeetCode22 - Container with most water
int area = 0;
int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
for (int i = 0; i < height.Length - 1; i++)
{
    if (height[i] * height.Length - i < area) continue;

    for (int j = i + 1; j < height.Length; j++)
    {
        int smallest = height[i] < height[j] ? height[i] : height[j];
        int distance = j - i;
        int currentArea = smallest * distance;

        if (currentArea > area)
        {
            area = currentArea;
        }
    }
}
//return area;
//Solution 2
int maxArea = 0;
int left = 0;
int right = height.Length - 1;
while (left < right)
{
    int currentArea = Math.Min(height[left], height[right]) * (right - left);
    maxArea = Math.Max(maxArea, currentArea);
    if (height[left] > height[right])
        right--;
    else left++;
}


//LeetCode23 - Two Sum Array
//[2,7,11,15]
int[] numbers = [-1,-1,1,1,1,1,1,1,1,1];
int target = -2;
int[] outputInd = new int[2];
for (int i=0; i < numbers.Length-1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] + numbers[j] == target)
        {
            outputInd[0] = i + 1;
            outputInd[1] = j + 1;
            break;
        }
    }
    if (outputInd[0] > 0)
        break;
}
Console.WriteLine("LeetCode23- "+ outputInd);


//LeetCode24
nums = [-1, 0, 1, 2, -1, -4];
//Array.Sort(nums);
//HashSet<List<int>> outputSet = new HashSet<List<int>>();
//for (int i = 0; i < nums.Length-2; i++)
//{
//    int leftInd = i + 1;
//    int rightInd = nums.Length;
//    while (leftInd > rightInd)
//    {
//        int sum = nums[i] + nums[left] + nums[right];
//        if (sum == 0)
//        {
//            outputSet.Add(new List<int> { nums[i], nums[left], nums[right] });
//        }
//        if(sum < 0)
//            leftInd++;
//        if (sum > 0)
//            rightInd--;
//    }
//}
//return ArrayList<>(outputSet);


Array.Sort(nums); // Sort the array to simplify logic
IList<IList<int>> outputList = new List<IList<int>>(); // Use IList<IList<int>> for the result

for (int i = 0; i < nums.Length - 2; i++)
{
    if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicates for nums[i]
        continue;

    int leftInd = i + 1;
    int rightInd = nums.Length - 1;

    while (leftInd < rightInd)
    {
        int sum = nums[i] + nums[leftInd] + nums[rightInd];
        if (sum == 0)
        {
            outputList.Add(new List<int> { nums[i], nums[leftInd], nums[rightInd] });
            leftInd++;
            rightInd--;

            // Skip duplicates to avoid duplicate triplets
            while (leftInd < rightInd && nums[leftInd] == nums[leftInd - 1]) leftInd++;
            while (leftInd < rightInd && nums[rightInd] == nums[rightInd + 1]) rightInd--;
        }
        else if (sum < 0)
        {
            leftInd++;
        }
        else
        {
            rightInd--;
        }
    }
}

//return outputList; // Return IList<IList<int>>


//LeetCode25
nums = [2, 3, 1, 2, 4, 3];
target = 7;
int currentSum = 0;
int minArrayLen = int.MaxValue;

int low = 0;
int high = 0;

while (high < nums.Length)
{
    currentSum += nums[high];
    high++;
    while (currentSum >= target)
    {
        minArrayLen = Math.Min(minArrayLen, high-low);
        currentSum = currentSum - nums[low];
        low++;
    }
}


//LeetCode26
s = "pwwkew";
char[] charArr = s.ToCharArray();
string currentStr = "";
int longest = int.MinValue;
int lowInd = 0;
int highInd = 0;

while (highInd < charArr.Length)
{
    //currentStr = currentStr + charArr[highInd];
    while (highInd < charArr.Length && !currentStr.Contains(charArr[highInd]))
    {
        currentStr = currentStr + charArr[highInd];
        highInd++;
    }
    longest = Math.Max(longest, highInd - lowInd);
    currentStr = currentStr.Replace(Convert.ToString(charArr[lowInd]), "");
    lowInd++;
}

Console.WriteLine("LeetCode26- "+ (longest == int.MinValue ? 0 : longest));


//LeetCode27 Substring with Concatenation of all words
s = "barfoothefoobarman";
string[] words = ["foo", "bar"];
IList<int> result = new List<int>();

int wordLength = words[0].Length;
int windowLength = wordLength * words.Length;
Dictionary<string, int> wordCount = new Dictionary<string, int>();
foreach (var word in words)
{
    if (!wordCount.ContainsKey(word))
        wordCount[word] = 0;
    wordCount[word]++;
}

for (int i = 0; i <= s.Length - windowLength; i++)
{
    string currentWindow = s.Substring(i, windowLength);
    Dictionary<string, int> seenWords = new Dictionary<string, int>();

    for (int j = 0; j < windowLength; j += wordLength)
    {
        string currentWord = currentWindow.Substring(j, wordLength);
        if (wordCount.ContainsKey(currentWord))
        {
            if (!seenWords.ContainsKey(currentWord))
                seenWords[currentWord] = 0;

            seenWords[currentWord]++;
            if (seenWords[currentWord] > wordCount[currentWord])
                break;
        }
        else
        {
            break;
        }
    }

    if (seenWords.SequenceEqual(wordCount))
    {
        result.Add(i);
    }
}


//LeetCode28 - Minimum window substring

s = "ADOBECODEBANC";
string t = "ABC";
char[] searchChars = t.ToCharArray();
string window = "";
int leftSlide = 0;
int rightSlide = s.Length - 1;

Dictionary<char, int> wordCounter = new Dictionary<char, int>();
foreach (var word in searchChars)
{
    if (!wordCounter.ContainsKey(word))
        wordCounter[word] = 0;
    wordCounter[word]++;
}

while (leftSlide < rightSlide)
{
    char[] currentWindow = s.Substring(leftSlide, rightSlide-leftSlide).ToCharArray();
    Dictionary<char, int> seenWords = new Dictionary<char, int>();

    for (int j = 0; j < currentWindow.Length; j++)
    {
        char currentWord = currentWindow[j];
        if (wordCounter.ContainsKey(currentWord))
        {
            if (!seenWords.ContainsKey(currentWord))
                seenWords[currentWord] = 0;

            seenWords[currentWord]++;
            if (seenWords[currentWord] == wordCounter[currentWord])
            {
                rightSlide--;
                window = s.Substring(leftSlide, rightSlide - leftSlide);
                break;
            }
                
        }
        //else
        //{
        //    break;
        //}
    }
    leftSlide++;
}


//LeetCode29 - Sudoko Validation

char[][] board = [['5', '3', '.', '.', '7', '.', '.', '.', '.'],
['6', '.', '.', '1', '9', '5', '.', '.', '.'],
['.', '9', '8', '.', '.', '.', '.', '6', '.'],
['8', '.', '.', '.', '6', '.', '.', '.', '3'],
['4', '.', '.', '8', '.', '3', '.', '.', '1'],
['7', '.', '.', '.', '2', '.', '.', '.', '6'],
['.', '6', '.', '.', '.', '.', '2', '8', '.'],
['.', '.', '.', '4', '1', '9', '.', '.', '5'],
['.', '.', '.', '.', '8', '.', '.', '7', '9']];

var row = new HashSet<char>[9];
var col = new HashSet<char>[9];
var box = new HashSet<char>[9];

for (int i=0; i < 9; i++)
{
    row[i] = new HashSet<char>();
    col[i] = new HashSet<char>();
    box[i] = new HashSet<char>();
}

for (int rowInd = 0; rowInd < board.Length; rowInd++)
{
    for (int colInd = 0; colInd < board[rowInd].Length; colInd++)
    {
        char cell = board[rowInd][colInd];
        if (cell == '.') continue;
        int boxInd = ((rowInd/3)*3) + (colInd / 3);
        if (row[rowInd].Contains(cell) || col[colInd].Contains(cell) || box[boxInd].Contains(cell))
        {
            //false
        }
        row[rowInd].Add(cell);
        col[colInd].Add(cell);
        box[boxInd].Add(cell);
    }
}

//true


//LeetCode30
string ransomNote = "aa", magazine = "aab";
if (magazine.Length < ransomNote.Length)
{
    //false
}
Dictionary<char, int> charCount = new();
foreach (var item in magazine)
{
    if (charCount.ContainsKey(item))
    {
        charCount[item]++;
    }
    else
        charCount[item] = 1;
}

foreach (var item in ransomNote)
{
    if (!charCount.ContainsKey(item) || charCount[item] == 0)
    {
        //return false;
    }
    else
    {
        charCount[item]--;
    }
}

//true


//LeetCode31
s = "badc"; t = "baba";
Dictionary<char, char> charPresent = new();
char[] tArray = t.ToCharArray();
char[] sArray = s.ToCharArray();
for (int i=0; i < tArray.Count(); i++)
{
    if (charPresent.ContainsKey(sArray[i]))           
    {                                                   
        if (charPresent[sArray[i]] != tArray[i])
        {
            //return false;
        }                           
    }
    else if (charPresent.ContainsValue(tArray[i]))
    {
        //return false;
    }
    else
    {
        charPresent[sArray[i]] = tArray[i];
    }
}
//return true;
Console.WriteLine("LeetCode31", true);


//LeetCode32

s = "(]";
Stack<char> stack = new Stack<char>();
foreach (var c in s)
{
    if (c == '(')
        stack.Push(')');
    else if (c == '[')
        stack.Push(']');
    else if (c == '{')
        stack.Push('}');
    else if (stack.Count() == 0|| stack.Pop() != c)
    {
        //return false;
    }
}
Console.WriteLine("LeetCode32- ");


s = "/home/user/Documents/../Pictures";
//s = "/home//foo/";
//s = "/.../a/../b/c/../d/./";
Stack<string> pathStack = new Stack<string>();
string[] pathStr = s.Split("/");
foreach (string str in pathStr)
{
    if (str == "/")
    {
        //if()
    }
}

nums = [0, 0, 1, 1, 1, 1, 2, 3, 3];
dupop = new List<int>();
for (int i = 0; i < nums.Length; i++)
{
    int numCount = dupop.Count(s => s == nums[i]);
    if (numCount < 2)
        dupop.Add(nums[i]);
}
Console.WriteLine();


//LeetCode - Linked List Cycle



