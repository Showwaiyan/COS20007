using System;

class Program
{
    // Function to calculate the average of an array of integers
    static double Average(int[] numbers)
    {
        int sum = 0;
        int count = numbers.Length;

        // Loop through the array and calculate the sum
        for (int i = 0; i < count; i++)
        {
            sum += numbers[i];
        }

        // Return the average (sum divided by count)
        return (double)sum / count; // Cast to double for decimal precision
    }

    static void Main()
    {
        // Sample data values (converted to integers, since the function accepts int[])
        int[] data = { 2, -1, -7, -11, -13, -13, -14, -15, -14, -9, -2, 2 };

        // Call the function and store the result
        double avg = Average(data);

        // Print the result
        Console.WriteLine("The average of the data set is: " + avg);

        // Print student information
        Console.WriteLine("Student Name: Show Wai Yan");
        Console.WriteLine("Student ID: 12345678"); // Replace with actual ID

        // Business logic:
        // Check if the average is multiple digits or single digits
        if (avg >= 10)
        {
            Console.WriteLine("Multiple digits");
        }
        else
        {
            Console.WriteLine("Single digits");
        }

        // Check if the average is negative
        if (avg < 0)
        {
            Console.WriteLine("Average value negative");
        }

        // Check last digit of average vs last digit of student ID
        int lastDigitAvg = Math.Abs((int)avg) % 10; // Get last digit of the absolute average
        int lastDigitID = 8; // Last digit of Student ID (12345678)

        if (lastDigitAvg > lastDigitID)
        {
            Console.WriteLine("Larger than my last digit");
        }
        else if (lastDigitAvg < lastDigitID)
        {
            Console.WriteLine("Smaller than my last digit");
        }
        else
        {
            Console.WriteLine("Equal to my last digit");
        }
    }
}
