using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject character;
    private int speed = 10;
    public bool canAttack;
    public int maxHealth = 100;
    public int maxStamina = 100;
    public int health = 50;
    public float damage;
    public int stamina;
    public double iFrames;
    private Vector3 characterVelocity;
    public Vector3 characterAcceleration;
    public GameObject groundedCheck;
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
        damage = 20.0f;
        healthBar.setMax(maxHealth);
        staminaBar.setMax(maxStamina);
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.updateBar(health);
        staminaBar.updateBar(stamina);

        //weapon.transform.position = new Vector3(0,0.05549997f,0.872f);
        if(!attackStatus())
        {
            if(Input.GetKey(KeyCode.W))
                character.transform.position += speed * Time.deltaTime * Camera.main.transform.forward;
            if(Input.GetKey(KeyCode.S))
                character.transform.position += speed * Time.deltaTime * -Camera.main.transform.forward;
            if(Input.GetKey(KeyCode.A))
                character.transform.position += speed * Time.deltaTime * -Camera.main.transform.right;
            if(Input.GetKey(KeyCode.D))
                character.transform.position += speed * Time.deltaTime * Camera.main.transform.right;
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                characterVelocity.y += characterAcceleration.y*1.5f;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            //Play animation
            canAttack = true;
        }
        if(Input.GetMouseButtonUp(0))
            canAttack = false;

        physics();
        updateInvuln();
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundedCheck.transform.position, .01f);
    } 

    void physics()
    {
        //simulates gravity

        //jump
        if(!isGrounded())
        {
            characterVelocity.y -= characterAcceleration.y*Time.deltaTime;
        }
        else if(characterVelocity.y < 0)
        {
            characterVelocity.y = 0;
        }

        character.transform.position += characterVelocity*Time.deltaTime;
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
}
