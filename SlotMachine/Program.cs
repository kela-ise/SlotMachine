using System.Drawing;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SLOT_ROWS = 3;
            const int SLOT_COLUMNS = 3;
            const int LOWER_LIMIT = 1;
            const int UPPER_LIMIT = 9;
            Random random = new Random(); // Random number generator for slot machine spins
            int[,] slotGrid = new int[SLOT_ROWS, SLOT_COLUMNS]; // 3x3 grid representing the slot machine
            int budget = 20; // Player's initial budget
            Console.WriteLine("This is a Slot Machine Game!");
            Console.WriteLine($"You have ${budget} in your account");
            for (int rows = 0; rows < SLOT_ROWS; rows++) // iterate through rows & columns to assign & print random numbers
            {
                for (int cols = 0; cols < SLOT_COLUMNS; cols++)
                {
                    slotGrid[rows, cols] = random.Next(LOWER_LIMIT, UPPER_LIMIT);
                    Console.Write(slotGrid[rows, cols] + " ");

                }
                Console.WriteLine();
            }
           
        }
    }
}
