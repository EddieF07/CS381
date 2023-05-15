using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusaderAnimation : MonoBehaviour
{
    Animator animator;
    private bool canMove;
    public enemyMovement enemy;
    public CharacterControl character;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            moveAnimation();
        }
        if(Input.GetMouseButtonDown(0) && canMove && character.stamina > 10)
        {
            character.stamina -= 20;
            animator.SetBool("IsAttacking",true);
            animator.SetBool("WalkingF",false);
            animator.SetBool("WalkingB",false);
            animator.SetBool("Striding",false);
            canMove = false;
            StartCoroutine("attackAnimation");
        }
        

    }

    void moveAnimation()
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

    IEnumerator attackAnimation()
    {   
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length-1.5f);
        canMove = true;
        animator.SetBool("IsAttacking",false);  
        if(enemy.getDistance() < 2f)
        {
            //enemy.hp -= character.damage;
            //Debug.Log(enemy.hp);
        }
    }

    public bool getAttack()
    {
        return animator.GetBool("IsAttacking");
    }
}
