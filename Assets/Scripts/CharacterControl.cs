using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject character;
    public enemyMovement enemyDamage;
    public Rigidbody characterRb;
    public int speed;
    public bool canAttack;
    public int maxHealth = 100;
    public int maxStamina = 100;
    public float health = 100;
    public float damage;
    public float stamina;
    public double iFrames;
    private Vector3 characterVelocity;
    public Collider swordHitBox;
    public Collider playerHurtBox;
    public CrusaderAnimation crusaderAnimator;

    //state booleans
    private bool isInvuln;
    private bool staminaRegen;

    //state timers
    private double invulnTimer;
    private double staminaTimer;

    public BarScript healthBar;
    public BarScript staminaBar;

    //public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        damage = 15.0f;
        healthBar.setMax(maxHealth);
        staminaBar.setMax(maxStamina);
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.updateBar((int)health);
        staminaBar.updateBar((int)(stamina));
        stamina += 5 * Time.deltaTime;
        //weapon.transform.position = new Vector3(0,0.05549997f,0.872f);

        if(!attackStatus() && crusaderAnimator.canMove)
        {
            Vector3 inputTranslate = new Vector3(0,0,0);
            if(Input.GetKey(KeyCode.W))
                inputTranslate += speed * Camera.main.transform.forward;
            if(Input.GetKey(KeyCode.S))
                inputTranslate += speed * -Camera.main.transform.forward;
            if(Input.GetKey(KeyCode.A))
                inputTranslate += speed * -Camera.main.transform.right;
            if(Input.GetKey(KeyCode.D))
                inputTranslate += speed * Camera.main.transform.right;
            // if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
            //     characterVelocity.y += characterAcceleration.y*1.5f;

            characterRb.MovePosition(transform.position + Time.deltaTime * inputTranslate.normalized * speed);
        }

        //physics();
        updateInvuln();
        characterClamp();
        staminaClamp();
    }

    private void staminaClamp()
    {
        if(stamina <0)
            stamina = 0;
        else if(stamina > maxStamina)
            stamina = maxStamina;
    }

    void physics()
    {
        //wall check

        //simulates gravity
        // if(!isGrounded())
        // {
        //     characterVelocity.y -= characterAcceleration.y*Time.deltaTime;
        // }
        // else if(characterVelocity.y < 0)
        // {
        //     characterVelocity.y = 0;
        // }

        // character.transform.position += characterVelocity*Time.deltaTime;
    }

    void updateInvuln()
    {
        if(invulnTimer <= 0)
        {
            isInvuln = false;
        }
        invulnTimer -= Time.deltaTime;
    }

    public bool attackStatus()
    {
        return crusaderAnimator.getAttack();
    }

    void OnTriggerEnter(Collider collision)
    {
        //need to change to enemy script to get damage
        if(collision.gameObject.tag == "Boss" && !isInvuln)
        {
            invulnTimer = 1;
            isInvuln = true;
            health -= enemyDamage.attackType();
        }
    }

    void characterClamp()
    {
        // if(character.transform.position.y > .675)
        // {
        //     character.transform.position = new Vector3(character.transform.position.x, (float).675, character.transform.position.z);;
        // }

        // if(character.transform.position.y < .65)
        // {
        //     character.transform.position = new Vector3(character.transform.position.x, (float).65, character.transform.position.z);;
        // }
    }
}
