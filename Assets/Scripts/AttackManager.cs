using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if(collision.gameObject.tag == "Boss")
        //{
        //    collision.gameObject.GetComponent<EnemyCombat>().healthBar -= character.GetComponent<CharacterControl>().damage;
        //    Debug.Log(collision.gameObject.GetComponent<EnemyCombat>().healthBar);
        //}
        
    }
}
