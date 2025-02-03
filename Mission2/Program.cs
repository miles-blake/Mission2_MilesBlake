// Miles Blake IS 413 Section 3

namespace ConsoleApp2
{
    public class DiceRoller
    {
        public int[] RollDice(int numberOfRolls)
        {
            // Indices 0 and 1 are unused; sums are 2..12
            int[] rollCounts = new int[13];
            Random rand = new Random();

            for (int i = 0; i < numberOfRolls; i++)
            {
                int die1 = rand.Next(1, 7);
                int die2 = rand.Next(1, 7);
                int sum = die1 + die2;
                rollCounts[sum]++;
            }

            return rollCounts;
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            // Start of simulation messages
            Console.WriteLine("Welcome to the dice throwing simulator!");

            Console.Write("How many dice rolls would you like to simulate? ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Exiting the program.");
                return;
            }

            if (!int.TryParse(input, out int numberOfRolls) || numberOfRolls <= 0)
            {
                Console.WriteLine("Invalid number entered. Exiting the program.");
                return;
            }

            DiceRoller roller = new DiceRoller();
            int[] rollResults = roller.RollDice(numberOfRolls);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numberOfRolls}.\n");

            for (int sum = 2; sum <= 12; sum++)
            {
                double percentage = (rollResults[sum] / (double)numberOfRolls) * 100;
                int numAsterisks = (int)Math.Round(percentage);

                Console.Write($"{sum}: ");
                for (int i = 0; i < numAsterisks; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }
}
