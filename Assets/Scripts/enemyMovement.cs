using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public static enemyMovement inst;
    private void Awake()
    {
        inst = this;
    }

    public Vector3 entityPosition = Vector3.zero;
    public Vector3 entityVelocity = Vector3.zero;
    public Vector3 desiredPosition;
    private float currentDistance;
    public float minimumDistance;
    public float minSpeed;
    public float maxSpeed;
    public float turnRate;
    public float speed;
    public float desiredSpeed;
    Vector3 heading; //degrees
    Vector3 desiredHeading; //degrees
    public float acceleration;
    public EnemyAnimation animator;
    private int aiMovement;
    public Rigidbody entityRigidBody;
    public int attack1;
    public int attack2;
    public int sceneIndex;
    bool death;

    public float hp;
    public gameControl winCon;
    public BarScript healthBar;

    //there is a rng function that will change current attack to be between 0 to numAttacks, changeAttack()
    private int currentAttack;
    private int numAttacks;

    float direction;
    public float attackPause;

    //should be set to player or another entity
    public GameObject target = null;
    public GameObject self;
     


    // Start is called before the first frame update
    void Start()
    {
        winCon = GameObject.Find("GameControl").GetComponent<gameControl>();
        changeAttack();
        death = false;
        healthBar.setMax((int)hp);
    }

    // Update is called once per frame
    void Update()
    {   
        healthBar.updateBar((int)hp);
        currentDistance = desiredHeading.magnitude;
        attackPause -= Time.deltaTime;
        entityPosition = self.transform.position;
        desiredPosition = target.transform.position;
        desiredHeading = (desiredPosition - entityPosition);

        if(currentDistance <.4f)
        {
            entityRigidBody.isKinematic = true;
        }
        else
        {
            entityRigidBody.isKinematic = false;
        }

        
        aiMovement = Random.Range(0,3);

        if(hp <= 0)
        {
            if(!death)
            {
                StartCoroutine(deathAnimation());
            }
        }
        if(animator.canMove() && aiMovement == 1 && currentDistance < 2)
        {
            
            animator.attack1Call();
        }
        else if(animator.canMove() && aiMovement == 2 && currentDistance < 3)
        {
            animator.attack2Call();
        }
        else if(animator.canMove())
        {
            if(target != null && attackPause <= 0)
            {
                Move();
                //Debug.DrawLine(entityPosition, entityPosition + desiredPosition * 10, Color.red, Mathf.Infinity);
            }
            if(desiredHeading.magnitude <=  minimumDistance)
            {
                attackPause = 3;
            }
        }


    }

    IEnumerator deathAnimation()
    {
        death = true;
        Debug.Log("enemy death");
        yield return new WaitForSeconds(5f);
        winCon.nextScene(6, true);
    }

    public void changeAttack()
    {
        currentAttack = Random.Range(0,numAttacks);
    }

    public float getDistance()
    {
        return currentDistance;
    }

    void Move()
    {
        
        if(currentDistance >  minimumDistance)
        {
            self.transform.position += desiredHeading.normalized*speed*Time.deltaTime;
        }

        
        self.transform.rotation =  Quaternion.LookRotation(desiredHeading.normalized);
        

       // self.transform.rotation *= Quaternion.Euler(0,180f,0);
        // if(Utils.ApproximatelyEqual(speed, desiredSpeed)) {
        //     ;
        // } else if(speed < desiredSpeed) {
        //     speed = speed + acceleration * Time.deltaTime;
        // } else if (speed > desiredSpeed) {
        //     speed = speed - acceleration * Time.deltaTime;
        // }
        // speed = Utils.Clamp(speed, minSpeed, maxSpeed);

        //heading
        // if (Utils.ApproximatelyEqual(heading, desiredHeading)) {
        //     ;
        // } else if (Utils.AngleDiffPosNeg(desiredHeading, heading) > 0) {
        //     heading += turnRate * Time.deltaTime;
        // } else if (Utils.AngleDiffPosNeg(desiredHeading, heading) < 0) {
        //     heading -= turnRate * Time.deltaTime;
        // }
        // heading = Utils.Degrees360(heading);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "crusader")
        {
            if(collision.gameObject.GetComponent<CharacterControl>().attackStatus())
            {
                hp -= collision.gameObject.GetComponent<CharacterControl>().damage;
                Debug.Log(hp);
            }
        }
    }

    public int attackType()
    {
        if(animator.getAttackType() == "Attack1")
        {
            return attack1;
        }
        else
        {
            return attack2;
        }
    }
}
