using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;
    public enemyMovement enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("walkingPause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator walkingPause()
    {   
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("Walking",true);  
        
    }

    public bool canMove()
    {
        return animator.GetBool("Walking");
    }

    public void continueWalking()
    {
        animator.SetBool("Walking",true);
    }

    public void attack1Call()
    {
        animator.SetBool("Attack1",true);
        animator.SetBool("Walking",false);
        StartCoroutine(attackPause("Attack1"));
    }

    public void attack2Call()
    {
        animator.SetBool("Attack2",true);
        animator.SetBool("Walking",false);
        StartCoroutine(attackPause("Attack2"));
    }

    IEnumerator attackPause(string attackType)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length-1.5f);
        animator.SetBool("Walking",true);
        animator.SetBool(attackType,false);
    }

    public string getAttackType()
    {
        if(animator.GetBool("Attack1"))
            return "Attack1";
        else
            return "Attack2";
    }
}
