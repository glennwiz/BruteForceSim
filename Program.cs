using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using Console = Colorful.Console;

class Program
{
    static void Main()
    {
        bool repeat = true;

        while (repeat)
        {
            Console.Clear();
            Console.WriteLine("BruteForceSim - Password Strength Checker");
            Console.WriteLine();

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

            BigInteger totalAttempts = BigInteger.Pow(characterList.Count, maxLength);
            double totalTimeInSeconds = (double)totalAttempts / attemptsPerSecond;

            double years = totalTimeInSeconds / (365 * 24 * 60 * 60);
            double days = (totalTimeInSeconds % (365 * 24 * 60 * 60)) / (24 * 60 * 60);
            double hours = (totalTimeInSeconds % (24 * 60 * 60)) / (60 * 60);
            double minutes = (totalTimeInSeconds % (60 * 60)) / 60;
            double seconds = totalTimeInSeconds % 60;

            Console.WriteLine();
            Console.Write("Total attempts: ");
            Console.ForegroundColor = Color.Yellow;
            Console.WriteLine($"{totalAttempts:N0}");
            Console.ResetColor();

            Console.Write("Estimated time: ");
            Console.ForegroundColor = Color.Cyan;
            Console.WriteLine(
                $"{years:F0} years, {days:F0} days, {hours:F0} hours, {minutes:F0} minutes, {seconds:F0} seconds."
            );
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Characters in Rainbow Palette:");
            Console.WriteLine();

            // Define the colors for the rainbow palette
            Color[] rainbowColors = {
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Indigo,
                Color.Violet
            };

            // Calculate the color step size based on the number of characters
            int colorStepSize = (int)Math.Ceiling((double)characterList.Count / rainbowColors.Length);
            int colorIndex = 0;

            foreach (char c in characterList)
            {
                // Get the corresponding color based on the current color index
                Color color = rainbowColors[colorIndex % rainbowColors.Length];

                // Set the console color to the current character's color
                Console.ForegroundColor = color;

                // Print the character
                Console.Write(c);

                colorIndex += colorStepSize;
            }

            // Reset the console color to the default
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Brute Force Attempt: ");
            Console.WriteLine("A brute force attempt calculates the estimated time it takes to try all possible combinations");
            Console.WriteLine("of characters in a given character set and maximum password length. The estimation is");
            Console.WriteLine("based on the assumption of a constant rate of attempts per second. Please note that actual");
            Console.WriteLine("time may vary depending on the computational resources available and other factors.");

            Console.WriteLine();
            Console.Write("Do you want to go again? (Y/N): ");
            string response = Console.ReadLine();

            repeat = (response.ToLower() == "y");
        }
    }
}
