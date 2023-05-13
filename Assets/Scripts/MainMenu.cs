using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioS;

    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void settingS()
    {
        GameObject audioObject = new GameObject("AudioObject");
        AudioSource audioS = audioObject.AddComponent<AudioSource>();
        audioS.clip = audioClip;
        audioS.Play();
        DontDestroyOnLoad(audioObject);
        audioS.Play();

        SceneManager.LoadScene(4);
    }
    public void gameStart()
    {
        GameObject audioObject = new GameObject("AudioObject");
        AudioSource audioS = audioObject.AddComponent<AudioSource>();
        audioS.clip = audioClip;
        audioS.Play();
        DontDestroyOnLoad(audioObject);
        audioS.Play();
        SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        GameObject audioObject = new GameObject("AudioObject");
        AudioSource audioS = audioObject.AddComponent<AudioSource>();
        audioS.clip = audioClip;
        audioS.Play();
        DontDestroyOnLoad(audioObject);
        SceneManager.LoadScene(1);
    }

    public void instructionsScene()
    {
        //audioS.Play();
        //SceneManager.LoadScene(3);

        GameObject audioObject = new GameObject("AudioObject");
        AudioSource audioS = audioObject.AddComponent<AudioSource>();
        audioS.clip = audioClip;
        audioS.Play();
        DontDestroyOnLoad(audioObject);
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        GameObject audioObject = new GameObject("AudioObject");
        AudioSource audioS = audioObject.AddComponent<AudioSource>();
        audioS.clip = audioClip;
        audioS.Play();
        DontDestroyOnLoad(audioObject);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
