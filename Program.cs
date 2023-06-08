using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        List<char> characterList = new List<char>();

        // Add lowercase letters
        for (char c = 'a'; c <= 'z'; c++)
        {
            characterList.Add(c);
        }

        // Add uppercase letters
        for (char c = 'A'; c <= 'Z'; c++)
        {
            characterList.Add(c);
        }

        // Add numbers
        for (char c = '0'; c <= '9'; c++)
        {
            characterList.Add(c);
        }

        // Add special characters
        string specialCharacters = "!@#$%^&*()";
        characterList.AddRange(specialCharacters);

        Console.Write("Enter the maximum length of the password: ");
        int maxLength = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of attempts per second: ");
        int attemptsPerSecond = int.Parse(Console.ReadLine());

        int totalAttempts = (int)Math.Pow(characterList.Count, maxLength);
        double totalTimeInSeconds = (double)totalAttempts / attemptsPerSecond;

        TimeSpan timeSpan = TimeSpan.FromSeconds(totalTimeInSeconds);

        Console.WriteLine($"Total attempts: {totalAttempts:N0}");
        Console.WriteLine($"Estimated time: {timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds.");
    }
}
