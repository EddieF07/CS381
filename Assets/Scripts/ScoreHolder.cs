using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public int currentRound;
    public int maxRounds;
    private int[] scores;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        scores = new int[maxRounds];
    }

    void Start()
    {
        for(int count = 0; count < maxRound; count++)
        {
            scores[count] = 0;
        }
    }

    public void addScore(int score)
    {
        scores[currentRound] = score;
    }

}
