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
        StartCoroutine(endScene_timer());
    }

    IEnumerator endScene_timer()
    {
        while(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        nextScene(5);
    }

    public void nextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void saveScore(float time, float playerHP, bool winCon)
    {
        scores[currentRound] = time*3 + playerHP;
        if(winCon)
            scores[currentRound] += 100;
    }
}
