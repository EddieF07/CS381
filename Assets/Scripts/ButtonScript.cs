using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
  public float delay = 19.0f; // The amount of time to wait before showing the buttons
  public Button[] buttons; // Reference to the buttons

  void Start()
  {
    foreach (Button button in buttons)
    {
      button.gameObject.SetActive(false); // Initially hide each button
    }
    Invoke("ShowButtons", delay); // Call the "ShowButtons" method after the specified delay
  }

  void ShowButtons()
  {
    foreach (Button button in buttons)
     {
      button.gameObject.SetActive(true); // Show each button
     }
        
  }
}
