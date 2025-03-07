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
            const int BUDGET_INCREMENTER = 2;
            const int UPPER_LIMIT_INCREMENTER = 1;
            const int MIN_WAGER = 1;
            const int INITIAL_BUDGET = 20;
            const int VERTICAL_MODE = 2;
            const int HORIZONTAL_MODE = 3;
            const int DIAGONAL_MODE = 4;
            const int COLUMN_ONE = 0;
            const int ROW_ONE = 0;
            string InvalideChoiceMessage = "Invalid choice. Please enter a number between " + CENTER_MODE + " and " + DIAGONAL_MODE + ".";
            string MessageForSpinCHeckMode=  ($"Enter a number to check spin. {CENTER_MODE}: Center, {VERTICAL_MODE}: Vertical, {HORIZONTAL_MODE}: Horizontal, {DIAGONAL_MODE}: Diagonal: ");

            int centerRow = SLOT_ROWS / 2;  // Dynamically calculate middle row index 
            int budget = INITIAL_BUDGET;   // Player's initial budget
            Random random = new Random(); // Random number generator for slot machine spins
            int[,] slotGrid = new int[SLOT_ROWS, SLOT_COLUMNS]; // 3x3 grid representing the slot machine

            Console.WriteLine("This is a Slot Machine Game!");
            Console.WriteLine($"You have ${budget} in your account");

            int wager;
            Console.Write($"You have ${budget}, Enter your wager amount  (Minimum: ${MIN_WAGER}): ");
            while (!int.TryParse(Console.ReadLine(), out wager) || wager < MIN_WAGER || wager > budget) // use TryParse to convert user input into an integer
            {
                Console.WriteLine(InvalideChoiceMessage);
            }

            budget = budget - wager;// Deduct wager from budget
            Console.Write(MessageForSpinCHeckMode);

            // Validate spin check
            int checkSpin;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out checkSpin) && checkSpin >= CENTER_MODE && checkSpin <= DIAGONAL_MODE)
                    break; // Valid input, exit the loop

                Console.WriteLine(InvalideChoiceMessage);
            }

            bool checkWin = true;
            if (checkSpin == CENTER_MODE) // Check if the player selected center row check
                for (int col = 1; col < SLOT_COLUMNS; col++)
                {
                    if (slotGrid[centerRow, COLUMN_ONE] != slotGrid[centerRow, col])
                    {
                        checkWin = false;
                        break;
                    }
                }
            // Check Vertical Mode for all columns
            else if (checkSpin == VERTICAL_MODE)
            {
                checkWin = false;
                for (int col = 0; col < SLOT_COLUMNS; col++) // Iterate through all columns
                {
                    bool columnMatch = true;
                    for (int row = 1; row < SLOT_ROWS; row++) // Check each row in the column
                    {
                        if (slotGrid[row, col] != slotGrid[ROW_ONE, col]) // Compare with the first row
                        {
                            columnMatch = false;
                            break;
                        }
                    }
                    if (columnMatch) // If any column matches, set checkWin to true
                    {
                        checkWin = true;
                        break;
                    }
                }
            }
            // Check Horizontal Mode
            else if (checkSpin == HORIZONTAL_MODE)
            {
                checkWin = false;
                for (int row = 0; row < SLOT_ROWS; row++)
                {
                    bool rowMatch = true;
                    for (int col = 1; col < SLOT_COLUMNS; col++)
                    {
                        if (slotGrid[row, COLUMN_ONE] != slotGrid[row, col])
                        {
                            rowMatch = false;
                            break;
                        }
                    }
                    if (rowMatch)
                    {
                        checkWin = true;
                        break;
                    }
                }
            }

            for (int rows = 0; rows < SLOT_ROWS; rows++) // iterate through rows & columns to assign & print random numbers
            {
                for (int cols = 0; cols < SLOT_COLUMNS; cols++)
                {
                    slotGrid[rows, cols] = random.Next(LOWER_LIMIT, UPPER_LIMIT + UPPER_LIMIT_INCREMENTER);
                    Console.Write(slotGrid[rows, cols] + " ");

                }
                Console.WriteLine();
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
