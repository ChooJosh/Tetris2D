using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject gameOverObject;

    void Start()
    {
        gameOverObject = GameObject.FindGameObjectsWithTag("GameOverCanvas")[0];
        gameOverObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetGameOver()
    {
        gameOverObject.SetActive(true);
    }
}
