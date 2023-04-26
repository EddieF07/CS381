using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour
{
    public GameObject playerCamera;
    private float yaw = 0;
    private bool screenLock = false;
    // Start is called before the first frame update


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * Time.deltaTime * 300;
        playerCamera.transform.eulerAngles = new Vector3(0.0f,yaw,0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (screenLock)
            {
                screenLock = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                screenLock = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
    }

}
