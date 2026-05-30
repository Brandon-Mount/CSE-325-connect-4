public class GameState
{
    public enum WinState
    {
        No_Winner,
        Player1_Wins,
        Player2_Wins,
        Tie
    }

    private readonly int[,] board = new int[6, 7];

    public int PlayerTurn { get; private set; } = 1;
    public int CurrentTurn { get; private set; } = 0;

    public void ResetBoard()
    {
        Array.Clear(board);
        PlayerTurn = 1;
        CurrentTurn = 0;
    }

    public int PlayPiece(byte col)
    {
        if (col > 6)
        {
            throw new ArgumentException("Invalid column.");
        }

        for (int row = 5; row >= 0; row--)
        {
            if (board[row, col] == 0)
            {
                board[row, col] = PlayerTurn;
                int landingRow = row + 1;
                PlayerTurn = PlayerTurn == 1 ? 2 : 1;
                return landingRow;
            }
        }

        throw new ArgumentException("That column is full.");
    }

    public void NextTurn()
    {
        CurrentTurn++;
    }

    public WinState CheckForWin()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                int player = board[row, col];

                if (player == 0)
                {
                    continue;
                }

                if (col + 3 < 7 &&
                    board[row, col + 1] == player &&
                    board[row, col + 2] == player &&
                    board[row, col + 3] == player)
                {
                    return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }

                if (row + 3 < 6 &&
                    board[row + 1, col] == player &&
                    board[row + 2, col] == player &&
                    board[row + 3, col] == player)
                {
                    return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }

                if (row + 3 < 6 && col + 3 < 7 &&
                    board[row + 1, col + 1] == player &&
                    board[row + 2, col + 2] == player &&
                    board[row + 3, col + 3] == player)
                {
                    return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }

                if (row + 3 < 6 && col - 3 >= 0 &&
                    board[row + 1, col - 1] == player &&
                    board[row + 2, col - 2] == player &&
                    board[row + 3, col - 3] == player)
                {
                    return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        return CurrentTurn >= 42 ? WinState.Tie : WinState.No_Winner;
    }
}