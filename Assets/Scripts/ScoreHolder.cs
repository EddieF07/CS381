using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    ScoreHolder inst;
    public int currentRound;
    public int maxRounds;
    private int[] scores;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        scores = new int[maxRounds];
        inst = this;
    }

    void Start()
    {
        for(int count = 0; count < maxRounds; count++)
        {
            scores[count] = 0;
        }
    }

    void Update()
    {
        if(GameObject.Find("ScoreText") != null)
        {
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Encounter 1: " + scores[0] + "\n" + 
                                                                     "Encounter 2: " + scores[1]; 
        }
    }

    public void addScore(int score)
    {
        scores[currentRound] = score;
    }

}
