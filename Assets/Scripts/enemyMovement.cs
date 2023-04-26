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
    public float minimumDistance;
    public float minSpeed;
    public float maxSpeed;
    public float turnRate;
    public float speed;
    public float desiredSpeed;
    Vector3 heading; //degrees
    Vector3 desiredHeading; //degrees
    public float acceleration;

    float direction;
    public float attackPause;

    //should be set to player or another entity
    public GameObject target = null;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        attackPause -= Time.deltaTime;
        entityPosition = self.transform.position;
        desiredPosition = target.transform.position;
        desiredHeading = (desiredPosition - entityPosition);
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

    void Move()
    {
        
        if(desiredHeading.magnitude >  minimumDistance)
        {
            self.transform.position += desiredHeading.normalized*speed*Time.deltaTime;
        }

        self.transform.rotation =  Quaternion.LookRotation(desiredHeading.normalized);;
        

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
}