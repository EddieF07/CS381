using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public float timerEndScene = 30f;
    private float remainingTime;
    private int rounds = 2;
    private int currentRound = 1;
    private int[] scores;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = timerEndScene;
    }

    void update()
    {
        while(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if(GameObject.Find("character").GetComponent<enemyMovement>().hp <= 0)
            {
                saveScore(remainingTime, GameObject.Find("character").GetComponent<CharacterControl>().health, true);
            }
            else if(GameObject.Find("character").GetComponent<CharacterControl>().health <= 0)
            {
                saveScore(0, 0, false);
            }
        }
        saveScore(0, GameObject.Find("character").GetComponent<CharacterControl>().health, false);
    }

    public void nextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void saveScore(float time, float playerHP, bool winCon)
    {
        scores[currentRound] = (int)(time*3.0f + playerHP);
        if(winCon)
            scores[currentRound] += 100;
        currentRound++;
    }
}
