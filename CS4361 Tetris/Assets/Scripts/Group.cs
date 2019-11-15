﻿using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour
{
    // Time since last gravity tick
    public static float lastFall = 0f;
    public static double speed = 1.0;
    public static double tempSpeed = speed;
    public static double startTime;
    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);

            // Not inside Border?
            if (!Playfield.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
    void Update()
    {
		if(Time.timeScale > 0)
		{
			// Move Left
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

			// Move Right
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

			// Rotate
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				transform.Rotate(0, 0, -90);

				// See if valid
				if (isValidGridPos())
					// It's valid. Update grid.
					updateGrid();
				else
					// It's not valid. revert.
					transform.Rotate(0, 0, 90);
			}

			// Move Downwards and Fall
			else if (Input.GetKeyDown(KeyCode.DownArrow) ||
					 Time.time - lastFall >= speed)
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
					// increments deleted every time a row is deleted
					Playfield.deleteFullRows();

					// speed up game every 10 deleted lines
					if (Playfield.deleted % 10 == 0)
					{
						if (speed > 0.0)
						{
							speed -= 0.1;
						}
					}

					// Spawn next Group
					FindObjectOfType<Spawner>().spawnNext();

					// Disable script
					enabled = false;
				}
				lastFall = Time.time;
				speed = tempSpeed;
			}
		}
    }
    void Start()
    {
        // Default position not valid? Then it's game over
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
}