using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:

            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are unique");
            else
                Console.WriteLine("Number of Occurences of each element are not unique");

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "lenovo" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "color";
            string ruleValue = "silver";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);

            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "ab";
            string[] words = { "ad", "bd", "aaab", "baa", "badab" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = minSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
        }


        /*
        Question 1:

        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.

        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                int l = gain.Length, max = 0;

                int[] alt = new int[l + 1];//Creating array for saving altitude
                alt[0] = 0;//Adding 1st element as 0 as biker starts his trip on point 0 with altitude equal 0
                for (int i = 0; i < l; i++)
                {

                    alt[i + 1] = gain[i] + alt[i];//Adding gain with the previous altitude to get next altitude in alt array
                    max = Math.Max(alt[i], max);//finding maximum altitiude and saving in max

                }
                alt[l] = gain[l - 1] + alt[l - 1];//Adding the last gain to get last value of altitude which was not covered in the last for loop
                return Math.Max(alt[l], max); //Finding final largest altitude

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 2:

        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search

        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2

        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1

        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4

        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                // checking for corner cases 
                if (nums == default(int[]) || nums.Length == 0 || target == 0)
                    return 0;
               
                // Implemented binary search to find the target element index
                // initializing left,pivot,right to implement binary search
                // Since the given array is sorted, this method will easily divide the array by comparing the target with element at pivot index
                int left = 0, pivot, right = nums.Length - 1;

                while (left <= right)
                {
                    pivot = left + (right - left) / 2;

                    if (target == nums[pivot])
                        return pivot;// found target here

                    else if (target < nums[pivot])
                    {
                        right = pivot - 1;
                    }
                    else
                        left = pivot + 1;

                }
                return left;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 3
       
        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]

        
        */

        public static List<string> CommonChars(string[] words)
        {
            try
            {
                List<string> commonwords = new List<string>();//Creating list to save common characters
                int[,] chars = new int[words.Length, 26];


                for (int i = 0; i < words.Length; i++)//Initializing the chars 2*2 array with the count of characters in words using the difference found in ascii codes
                    foreach (var item in words[i])
                        chars[i, item - 'a']++;

                for (int i = 0; i < 26; i++)
                {
                    int min = Int32.MaxValue;

                    for (int j = 0; j < words.Length; j++)
                        if (chars[j, i] < min)
                            min = chars[j, i]; //Finding the characters which are common in all words 

                    if (min > 0)
                        for (int j = 0; j < min; j++)
                            commonwords.Add(((char)(i + 'a')).ToString());//Adding those common characters in commonwords list that we created above by converting the ascii code to character through explicit datatype conversion
                }

                return commonwords;

            }

            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 4:

        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.

        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

        Example 2:
        Input: arr = [1,2]
        Output: false

       
         */

        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                // Using dictonary to save the occurences of each element
                Dictionary<int, int> dict = new Dictionary<int, int>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (!dict.ContainsKey(arr[i]))
                        dict.Add(arr[i], 1);
                    else
                    {
                        dict[arr[i]] += 1;
                    }

                }

                return dict.Values.Distinct().Count() == dict.Values.Count();// to check uniqueness of occurences and returning true if occurence is unique
            } 
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 5:

        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        •	ruleKey == "type" and ruleValue == type.
        •	ruleKey == "color" and ruleValue == color.
        •	ruleKey == "name" and ruleValue == name.

        Return the number of items that match the given rule.

        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].

        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 

        Note that the item ["computer","silver","phone"] does not match.

        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            try
            {
                // index is to get the index of ruleKey
                int index = 0;
                int c = 0;// c is used to hold the output to be returned

                if (ruleKey == "type")
                    index = 0;
                else if (ruleKey == "color")
                    index = 1;
                else if (ruleKey == "name")
                    index = 2;

                // iterating through all the elements and incrementing the count if ruleValue is found
                foreach (var i in items)
                {
                    if (i[index] == ruleValue)
                        c++;
                }
                return c;// returning count
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 6:
        
        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.

        Note: Solve it in O(n) and O(1) space complexity.

        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it’s useful to use pointers tracking the two ends of the array.

        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]

        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]

        */

        public static void targetSum(int[] nums, int target)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                int countSum = 0;
                //Checking in the array to find the elements index which sum upto target using left and right pointers
                while (left < right)
                {
                    countSum = nums[left] + nums[right];

                    if (countSum == target)
                    {
                        Console.WriteLine("[" + left + "," + right + "]");
                    }
                    //Moving right pointer towards left if countsum>target and moving left pointer towards right if countsum<target
                    if (countSum > target)
                    {
                        right -= 1;
                    }
                    else
                    {
                        left += 1;
                    }

                }
                //print the answer in the function itself.


            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 7:

        You are given a string allowed consisting of distinct characters and an array of strings words. A string is consistent if every character in words[i] appears in the string allowed.
        Return the number of consistent strings in the array words.

        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 

        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string “bd” is not consistent since ‘d’ is not in string allowed.

        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.

        */

        public static int CountConsistentStrings(string allowed, string[] words)
        {
            try
            {
                //dic dictonary is to keep track of occurance of each character in allowed string
                Dictionary<char, int> dic = new Dictionary<char, int>();
                for (int i = 0; i < allowed.Length; i++)
                {
                    if (!dic.ContainsKey(allowed[i]))
                    {
                        dic[allowed[i]] = 1;
                    }
                    else
                    {
                        dic[allowed[i]] += 1;
                    }
                }

                //Checking the words array to find the consistent strings in the words
                //consistentWords is used to count the consistent words in the array 
                int cw = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    string currentWord = words[i];
                    bool isConsistentWord = true;
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        if (!dic.ContainsKey(currentWord[j]))
                        {
                            isConsistentWord = false;
                            break;
                        }
                    }

                    if (isConsistentWord)
                        cw++;
                }

                return cw;//returning count of consistent words
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 8:

        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.

        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.

 
        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.

        */

        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                Dictionary<int, int> dict1 = new Dictionary<int, int>();
                int len = nums2.Length;

                //initializing the dictionary with nums2 array with element as key and index as value
                for (int i = 0; i < len; i++)
                    dict1[nums2[i]] = i;

               
                int[] result = new int[len];
                
                for (int i = 0; i < len; i++)
                    result[i] = dict1[nums1[i]]; // result is used to hold the final output

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        
        Question 9:

        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1

        */

        public static int MaximumSum(int[] arr)
        {
            try
            {
                int max = arr[0];
                int sum = 0, l = arr.Length;

                if (l == 1) return arr[0];//checking corner case

                //iterating through the array and finding the maximum sum and saving in max variable
                for (int i = 0; i < l; i++)
                {
                    sum = sum + arr[i];
                    if (arr[i] > sum) sum = arr[i];

                    if (sum > max) max = sum;
                }
                return max;// returning maximum value

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:

        Given an array of positive integers nums and a positive integer target, return the minimal length of a contiguous subarray [nums[l], nums[l+1], ..., nums[r-1], nums[r]] of which the sum is greater than or equal to target. If there is no such subarray, return 0 instead.


        Note: Try to solve it in O(n) time.

        Hint: Try to create a window and track the sum you have in the window.

        Example 1:
        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.


        Example 2:
        Input: target = 4, nums = [1,4,4]
        Output: 1

        */

        public static int minSubArrayLen(int target_subarray_sum, int[] arr10)
        {
            try
            {
                //checking for corner case
                if (arr10.Length == 0)
                {
                    return 0;
                }

                int result = int.MaxValue;
                int left = 0;
                int sum = arr10[0];
                int right = 0;

                //iterating through each element of the array
                while (left != arr10.Length)
                {
                    //for each element checking sum with target_subarray_sum and updating right and left accordingly
                    if (sum < target_subarray_sum)
                    {
                        if (right < arr10.Length - 1)
                        {
                            right++;
                            sum += arr10[right];
                        }
                        else
                        {
                            sum -= arr10[left];
                            left++;
                        }

                        continue;
                    }
                    //updating result after each iteration for array element
                    result = Math.Min(right - left + 1, result);
                    sum -= arr10[left];
                    left++;
                }

                return result!= int.MaxValue ? result : 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
/*I learned from this assignment how to use for loop, lists, strings, array,dictionary,binary search and various library funtions
like Length,MaxValue,ContainsKey.
I also learned how to restrict the complexity of a code to make it more optimized.
Recommendation- It would be great if we receive more hands on experience regarding C# code and also
if the subject is made more flexible to use other languages as well.
*/