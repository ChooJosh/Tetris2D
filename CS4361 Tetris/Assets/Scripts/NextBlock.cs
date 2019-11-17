using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlock : MonoBehaviour
{
    public GameObject[] blockGroups;
    public GameObject[] groups;

    private GameObject next;
    public GameObject nextGroup;
    private int numRemaining;

    public void spawnNext()
    {
        Destroy(next);
        if(numRemaining == 1)
        {
            next = (GameObject) Instantiate(blockGroups[0], transform.position, Quaternion.identity);
            getNextGroup();
            numRemaining = blockGroups.Length;
        }
        else
        {
            // Random Index
            int i = Random.Range(0, numRemaining);

            // Spawn Group at current Position
            next = (GameObject)Instantiate(blockGroups[i], transform.position, Quaternion.identity);
            getNextGroup();

            //swap used piece to end of unused array section
            GameObject temp = blockGroups[i];
            blockGroups[i] = blockGroups[numRemaining - 1];
            blockGroups[numRemaining - 1] = temp;

            numRemaining--;
        }
       
    }

    private void getNextGroup()
    {
        if(Equals(next.name, "I(Clone)"))
        {
            nextGroup = groups[0];
        }
        else if(Equals(next.name, "J(Clone)"))
        {
            nextGroup = groups[1];
        }
        else if (Equals(next.name, "L(Clone)"))
        {
            nextGroup = groups[2];
        }
        else if (Equals(next.name, "O(Clone)"))
        {
            nextGroup = groups[3];
        }
        else if (Equals(next.name, "S(Clone)"))
        {
            nextGroup = groups[4];
        }
        else if (Equals(next.name, "T(Clone)"))
        {
            nextGroup = groups[5];
        }
        else
        {
            nextGroup = groups[6];
        }
    }

    public void deleteCurrent()
    {
        Destroy(next);
    }

    void Start()
    {
        numRemaining = 7;
        // Spawn initial Group
        spawnNext();
    }
}
