using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    /* Grid settings. */
	public static decimal w = right - left;
	public static decimal h = top - bottom;
    public static Transform[,] grid = new Transform[w, h];
    public static string currentWord;
	public static decimal top = 14.5m;
	public static decimal bottom = 0.5m;
	public static decimal left = -0.5m;
	public static decimal right = 9.5m;

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

	/// <summary>
	/// Determines if the game piece is within the side and bottom boundaries for movement.
	/// </summary>
	/// <returns>Boolean denotign whether game piece is within boundaries.</returns>
	/// <param name="pos">Position.</param>
    public static bool isWithinBoundaries(Vector2 pos)
    {
		return ((decimal)pos.x >= left &&
			(decimal)pos.x < right &&
			(decimal)pos.y >= bottom);
    }

	/// <summary>
	/// Determines if the game piece once place is outside of the top boundary.
	/// </summary>
	/// <returns></returns>
	/// <param name="pos">Position.</param>
	public static bool isAboveTopBoundry(Vector2 pos)
	{
		return (int)pos.y > top;
	}		

    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }

    public static void deleteFullRows()
    {
		/* Is word spelled? */
        for (int y = 0; y < h; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
            }
        }
    }
}
