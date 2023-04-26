using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true; // Make the cursor visible
        Cursor.lockState = CursorLockMode.None;
    }

    void OnDestroy()
    {
        Cursor.visible = false; // Hide the cursor when the game object is destroyed
    }
}
