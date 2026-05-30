namespace ConnectFour.Models;

public class State
{
    public bool[] Pieces { get; private set; }

    public State()
    {
        Pieces = new bool[42];
    }

    public void ResetGame()
    {
        Pieces = new bool[42];
    }

    public void PlayPiece(int position)
    {
        Pieces[position] = true;
    }
}