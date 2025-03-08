namespace SlotMachineTest
{
    internal class Test
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
            const int LAST_COLUMN = SLOT_COLUMNS - 1;
            const int INDEX_OFFSET = 1;

            string InvalideChoiceMessage = "Invalid choice. Please enter a number between " + CENTER_MODE + " and " + DIAGONAL_MODE + ".";
            string MessageForSpinCHeckMode = ($"Enter a number to check spin. {CENTER_MODE}: Center, {VERTICAL_MODE}: Vertical, {HORIZONTAL_MODE}: Horizontal, {DIAGONAL_MODE}: Diagonal: ");

            int centerRow = SLOT_ROWS / 2;  // Dynamically calculate middle row index 
            int budget = INITIAL_BUDGET;   // Player's initial budget
           // Random random = new Random(); // Random number generator for slot machine spins
           // int[,] slotGrid = new int[SLOT_ROWS, SLOT_COLUMNS]; // 3x3 grid representing the slot machine
            while (true) // Keep the game running
            {
                Console.WriteLine("\nThis is a Slot Machine Game!");
                Console.WriteLine($"You have ${budget} in your account");

                int wager;
                Console.Write($"You have ${budget}, Enter your wager amount  (Minimum: ${MIN_WAGER}): ");
                while (!int.TryParse(Console.ReadLine(), out wager) || wager < MIN_WAGER || wager > budget) // use TryParse to convert user input into an integer
                {
                    Console.Write($"Enter an amount within budget ${budget}: ");
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
                // Begin test section
                int[,] slotGrid = 
                    {
                      {1, 2, 3},
                      {5, 5, 5},  // Change values here to test different cases
                      {7, 8, 9}
                    };

                // Print the grid
                for (int rows = 0; rows < SLOT_ROWS; rows++)
                {
                    for (int cols = 0; cols < SLOT_COLUMNS; cols++)
                    {
                        Console.Write(slotGrid[rows, cols] + " ");
                    }
                    Console.WriteLine();
                }

                // Test section ends
                bool checkWin = true;
                if (checkSpin == CENTER_MODE)    // Check if the player selected center row check
                {
                    for (int col = 1; col < SLOT_COLUMNS; col++)
                    {
                        if (slotGrid[centerRow, col] != slotGrid[centerRow, COLUMN_ONE]) // Compare with the first column of the center row
                        {
                            checkWin = false;
                            break;
                        }
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
                // Check diagonal mode
                else if (checkSpin == DIAGONAL_MODE)
                {
                    bool diagonalMatch1 = true;
                    bool diagonalMatch2 = true;

                    for (int i = 1; i < SLOT_ROWS; i++)
                    {
                        if (slotGrid[i, i] != slotGrid[ROW_ONE, COLUMN_ONE])
                            diagonalMatch1 = false;
                        if (slotGrid[i, SLOT_COLUMNS - i - INDEX_OFFSET] != slotGrid[ROW_ONE, LAST_COLUMN])
                            diagonalMatch2 = false;
                    }

                    checkWin = diagonalMatch1 || diagonalMatch2;
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

                if (budget < MIN_WAGER)
                {
                    Console.WriteLine("\nGame Over! You're out of money");
                    break; // Exit loop/game when budget is < 1(MIN_WAGER)
                }
                Console.Write("\nEnter 'Y' to continue playing or anything else to end game: ");  // Ask if the player wants to continue playing
                string playersResponse = Console.ReadLine().ToUpper();
                if (playersResponse != "Y")
                {
                    Console.WriteLine($"Game Over");
                    break;

                }
            }
        }
    }
}
