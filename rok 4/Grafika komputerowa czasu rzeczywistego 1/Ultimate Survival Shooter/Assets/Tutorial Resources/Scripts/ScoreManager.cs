using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.

    void Awake()
    {
        // Reset the score.
        score = 0;
    }

    void Update()
    {
    }
}
