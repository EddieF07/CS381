using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(intro_timer());
    }
    IEnumerator intro_timer()
    {
        yield return new WaitForSeconds(timer);

        SceneManager.LoadScene(1);
    }

  
}
