using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 5, 4, -1, 7, 8 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>



        /// <logic>
        ///used dictionaries to find whether there is common intersection between two arrays
        ///looped through the hash set to find whether element is present or not
        /// <selfReflection>
        /// time complexity is o(m)
        /// space complexity is 0(n)
        /// Learnt how to use hashset

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                var a = new List<int>();
                var b = new HashSet<int>();

                foreach (var num in nums1)
                {
                    b.Add(num);
                }
                foreach (var num in nums2)
                {
                    if (b.Contains(num) && !a.Contains(num))
                    {
                        a.Add(num);
                    }
                }
                foreach (var x in a)
                {
                    Console.Write(x + " ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>


        /// <logic>
        ///used binary search to find whether element is present or not
        /// if element is present will return index of element, if it is not present we will return the closest index
        /// <selfReflection>
        /// time complexity is o(logN)
        /// space complexity is 0(1)
        ///learnt while loop
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int a = 0;
                int c = nums.Length - 1;

                while (a <= c)
                {
                    int b = (c + a) / 2;
                    if (nums[b] < target)
                    {
                        a = b + 1;
                    }
                    else if (nums[b] > target)
                    {
                        c = b - 1;
                    }
                    else
                    {
                        return b;
                    }
                }
                return a;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>
        /// 

        /// <logic>
        ///used dictionaries to find most frequent element
        ///looped through the hash set to find whether element is present or not
        /// <selfReflection>
        /// time complexity is o(m)
        /// space complexity is 0(n)
        ///learnt how to use hashset

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                var inputDict = new Dictionary<int, int>();
                foreach (int x in nums)
                {
                    if (inputDict.ContainsKey(x))
                    {
                        inputDict[x] += 1;

                    }
                    else
                    {
                        inputDict[x] = 1;
                    }
                }

                int maxVal = -1;
                foreach (var keyValue in inputDict)
                    if (keyValue.Key == keyValue.Value)
                        maxVal = Math.Max(maxVal, keyValue.Key);

                return maxVal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //• nums[0] = 0
        //• nums[1] = 1
        //• nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //• nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        /// 



        /// <logic>
        ///used array to generate the sequence if element is divisible by 2 inputArray[i] = inputArray[x] where x=i/2
        ///using the previous value to calculate the present value
        /// <selfReflection>
        /// time complexity is o(N)
        /// space complexity is 0(N)
        /// Learnt Dyanmic Programming

        private static int GenerateNums(int n)
        {
            try
            {
                int[] inputArray = new int[n + 2];
                inputArray[0] = 0;
                inputArray[1] = 1;
                if (n == 0)
                {
                    return 0;
                }

                for (int i = 2; i < n + 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        int x;
                        x = i / 2;
                        inputArray[i] = inputArray[x];
                    }
                    else
                    {
                        int y;
                        y = i / 2;
                        inputArray[i] = inputArray[y] + inputArray[y + 1];
                    }
                }
                return inputArray.Max();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        /// 


        /// <logic>
        ///used dictionaries to find most frequent element
        ///looped through the hash set to find whether element is present or not
        /// <selfReflection>
        /// time complexity is o(m)
        /// space complexity is 0(n)
        ///learnt to use hashset
        /// 
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                var originCity = new HashSet<string>();
                var destinationCity = new HashSet<string>();
                for (int x = 0; x < paths.Count; x++)
                {
                    originCity.Add(paths[x][0]);
                    destinationCity.Add(paths[x][1]);
                }
                string output = null;
                for (int x = 0; x < paths.Count; x++)
                {
                    if (!originCity.Contains(paths[x][1]))
                    {
                        output = paths[x][1];
                    }
                }
                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        /// 

        /// <logic>
        ///used two pointers x and y where x=0 and y=array.Length
        ///looped through the nums to find the target using condition x<y
        /// <selfReflection>
        /// time complexity is o(m)
        /// space complexity is 0(1)
        ///learnt how to use pointers

        private static void targetSum(int[] nums, int target)
        {
            try
            {
                int x = 0;
                int a = 0;
                int b = 0;
                int y = nums.Length - 1;
                while (x < y)
                {
                    if (nums[x] + nums[y] == target)
                    {
                        a = x + 1;
                        b = y + 1;

                        break;

                    }
                    else if (nums[x] + nums[y] > target)
                    {
                        y = y - 1;
                    }
                    else
                    {
                        x = x + 1;
                    }




                }
                Console.Write(a + " " + b);


            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        /// 

        /*
           Logic:
           used  dictionary to store the values associated with each ID in the list as value,
           after that sorted the values for each key and used inbuilt list functions to extract first 5 elements
           and cacluated the Average.
           */

        private static void HighFive(int[,] items)
        {
            try
            {
                List<List<int>> ans = new List<List<int>>();
                Dictionary<int, List<int>> track = new Dictionary<int, List<int>>();
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    if (!track.ContainsKey(items[i, 0]))
                    {
                        track.Add(items[i, 0], new List<int>());
                        track[items[i, 0]].Add(items[i, 1]);
                    }
                    else
                        track[items[i, 0]].Add(items[i, 1]);
                }

                foreach (var x in track)
                {
                    track[x.Key].Sort();
                    track[x.Key].Reverse();
                }

                foreach (var x in track)
                {
                    List<int> temp = new List<int>();
                    temp.Add(x.Key);
                    temp.Add((int)track[x.Key].GetRange(0, 5).AsQueryable().Sum() / 5);
                    ans.Add(temp);

                }

                foreach (var x in ans)
                {
                    Console.Write("[");
                    foreach (var j in x)
                        Console.Write(j + " ");
                    Console.Write("]");
                }
                Console.WriteLine();


            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>
        /// 


        /// <logic>
        ///used given array in question, swapped the index with first element to last last element until the total swaps are equal to k
        /// <selfreflection>
        /// time complexity is o(m)
        /// space complexity is 0(1)
        ///learnt how to use function call by reference

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                int length = arr.Length;
                n %= length;
                if (n == 0)
                    foreach (var k in arr)
                    {
                        Console.Write(k + " ");
                    }

                int count = 0;
                for (int i = 0; count < length; i++)
                {
                    int curInd = i;
                    int prev = arr[i];
                    do
                    {
                        int nextInd = (curInd + n) % length;
                        int temp = arr[nextInd];
                        arr[nextInd] = prev;
                        curInd = nextInd;
                        prev = temp;
                        count++;
                    } while (curInd != i);
                    foreach (var k in arr)
                    {
                        Console.Write(k + " ");
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>


        ///<logic>
        ///used two variables x and y where x is initilized to arr[0] and y to 0
        ///looped through the array and compare max value between y and x
        /// <selfreflection>
        /// timecomplexity=O(N)
        /// spacecomplexity=O(1)


        private static int MaximumSum(int[] arr)
        {
            try
            {
                int x = arr[0];
                int y = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    y = Math.Max(arr[i], y + arr[i]);
                    x = Math.Max(y, x);



                }
                return x;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>
        /// 

        ///<logic>
        ///used dynamic programming to solve this question where we make decision whether to take 1 step or 2 steps
        /// where we use to calculate arr[i] = costs[i] + Math.Min(arr[i - 1], arr[i - 2])
        ///finally return Min(arr[x - 1], arr[x - 2])
        /// <selfreflection>
        /// timecomplexity=O(N)
        /// spacecomplexity=O(N)
        ///learnt looping through the aarray

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                int x = costs.Length;
                int[] arr = new int[x];
                arr[0] = costs[0];
                arr[1] = costs[1];
                if (x == 1)
                {
                    return costs[0];
                }
                if (x == 2)
                {
                    return costs.Min();
                }

                for (int i = 2; i < x; i++)
                {
                    arr[i] = costs[i] + Math.Min(arr[i - 1], arr[i - 2]);
                }
                return Math.Min(arr[x - 1], arr[x - 2]);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}