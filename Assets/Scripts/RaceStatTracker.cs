using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceStatTracker : MonoBehaviour
{
    public GameObject FinishLineCollider;
    public int NumberOfLaps;

    private int currentLap;
    public int CurrentLap
    {
        get
        {
            if (currentLap == 0) return 1;
            if (currentLap >= NumberOfLaps) return NumberOfLaps;
            return currentLap; 
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.Equals(FinishLineCollider))
        {
            currentLap++;
            if(currentLap >= NumberOfLaps)
            {
                endGame();
            }
        }
    }

    void endGame()
    {
        SceneManager.LoadScene("Menu");
    }
}