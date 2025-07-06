using System;
using System.Collections.Generic;


public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // inside this function  which accepts two parameters as imput
        // i will create an aray to hold the result which my itteration or my looping  will return
        // after looping through the length, i will add the values to the reult aray variabel and return it. 

        double[] result = new double[length];

        // this line below  counts from 1 and keep counting till it reaches the number of the imput in this case is length and then it will stop
        for (int i = 1; i <= length; i++)
        {
            // this line below 'result[i -1]' is ensuring that when the number is multiplieed and added it will be in the 0 location of the array.
            result[i - 1] = number * i;
        }

        return result; // This return the results which have been properly positioned 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //.....................//
        // First  understand that i am given a list and a number
        // in the list i will need to divide or split it so that i will have a head and tail which i can join letter as pleased
        // Therefor i need a funtion that will take two parameteres  -  a list and a number
        //  in this fuction i will use a c# object library .Count to get the number of items in the list
        /// then use another c# object .GetRange to split then or in this case move them around



        // bellow i created a count variabe  to hold the numbers of items of my list  which the .Count gave me    }
        int count = data.Count;

        //we get the last item in the list by substracting the amount from the count, then take the amount
        List<int> tail = data.GetRange(count - amount, amount);

        // since we have taken the tail out we can get the reamining as our head 
        List<int> head = data.GetRange(0, count - amount);

        // the step below will clear the former list we have then we add fresh items into the same former list but now new items but not new seperate list
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);

        // since we have promied to return a list in the heading of this function 
        // eg.  List<int> RotateListRight ,  so we will keep that promise by returning the data (same list we have been given but with new item in it)

         return data;


      
    }


}
