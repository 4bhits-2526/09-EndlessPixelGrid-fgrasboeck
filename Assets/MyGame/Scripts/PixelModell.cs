using UnityEngine;

public class PixelModell : MonoBehaviour
{
    public bool[,] grid = new bool[10, 7];
    public bool[] inputLine = new bool[7];

    public void CommitInputLine()
    {
        
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                grid[r, c] = grid[r + 1, c];
            }
        }

        
        for (int c = 0; c < 7; c++)
        {
            grid[9, c] = inputLine[c];
            inputLine[c] = false;
        }
    }

}
