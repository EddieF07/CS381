using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public float timerEndScene = 90f;
    private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timerEndScene;
    }

    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime=0;
            nextScene(5, false);
        }
    }

    public void nextScene(int sceneIndex, bool win)
    {
        if(GameObject.Find("crusader").GetComponent<CharacterControl>().health <= 0)
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreHolder>().addScore(calcScore(0,0,win));
        }
        else
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreHolder>().addScore(calcScore(remainingTime, GameObject.Find("crusader").GetComponent<CharacterControl>().health, win));
        }
        print(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public int calcScore(float time, float playerHP, bool winCon)
    {
        int returnScore = 0;
        returnScore += (int)(time*3.0f + playerHP);
        returnScore += 100;
        return returnScore;
    }
}
