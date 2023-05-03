using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusaderAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WalkingF",true);
        }
        if(!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("WalkingF",false);
        }
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkingB",true);
        }
        if(!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkingB",false);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Striding",true);
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Striding",false);
        }
    }
}
