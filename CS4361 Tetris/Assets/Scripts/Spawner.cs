using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    // Groups
    public GameObject[] groups;

    public void spawnNext()
    {
        // Random Index

        // Spawn Group at current Position
        Instantiate(FindObjectOfType<NextBlock>().nextGroup,
                    transform.position,
                    Quaternion.identity);

        FindObjectOfType<NextBlock>().spawnNext();
    }
    void Start()
    {
        // Spawn initial Group
        FindObjectOfType<NextBlock>().spawnNext();
        spawnNext();
    }
}