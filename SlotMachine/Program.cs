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
            const int UPPER_LIMIT = 3;
            const int CENTER_MODE = 1;
            const int VERTICAL_MODE = 2;
            const int HORIZONTAL_MODE = 3;
            const int DIAGONAL_MODE = 4;
            int centerRow = SLOT_ROWS / 2;  // Dynamically calculate middle row index
            int budget = 20; // Player's initial budget
            int BUDGET_INCREMENTER = 2;
            Random random = new Random(); // Random number generator for slot machine spins
            int[,] slotGrid = new int[SLOT_ROWS, SLOT_COLUMNS]; // 3x3 grid representing the slot machine
            Console.WriteLine("This is a Slot Machine Game!");
            Console.WriteLine($"You have ${budget} in your account");
            Console.Write($"You have ${budget}, Enter your wager amount ");
            int wager = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter a number between 1 & 5 to check spin: ");
            if (wager < 1 || wager > budget)
            {
                Console.WriteLine("Invalid wager amount. Please enter a value within your budget.");
                return;
            }

            for (int rows = 0; rows < SLOT_ROWS; rows++) // iterate through rows & columns to assign & print random numbers
            {
                for (int cols = 0; cols < SLOT_COLUMNS; cols++)
                {
                    slotGrid[rows, cols] = random.Next(LOWER_LIMIT, UPPER_LIMIT + 1);
                    Console.Write(slotGrid[rows, cols] + " ");

                }
                Console.WriteLine();
            }
            // Deduct wager from budget
            budget = budget - wager;

            // Get spin check mode
            Console.Write("Enter 1 to check center line: ");
            int checkSpin = Convert.ToInt32(Console.ReadLine());

            // Validate spin selection
            if (checkSpin < 1 || checkSpin > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                return;
            }

            
            bool checkWin = false;


            if (checkSpin == CENTER_MODE) // Check if the player selected center row check
            {
                for (int col = 1; col < SLOT_COLUMNS; col++)
                {
                    if (slotGrid[centerRow, 0] == slotGrid[centerRow, 1] &&
                    slotGrid[centerRow, 1] == slotGrid[centerRow, 2])
                    {
                        checkWin = true;
                    }
                }
            }
            if (checkWin)
            {
                int winnings = wager + BUDGET_INCREMENTER;
                budget += winnings;
                Console.WriteLine($"There's a match. You Won ${winnings}");
               // Console.WriteLine(++winCount);
            }
            else
            {
                Console.WriteLine("No match found");
            }
            Console.WriteLine($"Your remaining budget: ${budget}");

        } 
    }
}
