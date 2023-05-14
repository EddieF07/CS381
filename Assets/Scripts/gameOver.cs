using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public float timerEndScene = 30f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endScene_timer());
    }

    IEnumerator endScene_timer()
    {
        yield return new WaitForSeconds(timerEndScene);

        nextScene(5);
    }

    public void nextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
