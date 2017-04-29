using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {
    
	private decimal fallSpeed;

    public Sprite[] Sprites;

    public Group(decimal fallSpeed)
    {
        this.fallSpeed = fallSpeed;
    }

    float lastFall = 0;

    bool isValidGridPos()
    {
            /* Is the letter within the boundaries? */
           if (!Grid.isWithinBoundaries(transform.position))
           return false;
		
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

	/// <summary>
	/// Fired once on object instantiation.
	/// </summary>
    void Start () 
	{		
		/* Randomly select a sprite to use. */
		int index = Random.Range (0, Sprites.Length);
		GetComponent<SpriteRenderer> ().sprite = Sprites [index];	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Grid.deleteFullRows();

                /* Spawn the next letter once this letter stops moving. */
				FindObjectOfType<Spawner>().SpawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
        }
    }
}
