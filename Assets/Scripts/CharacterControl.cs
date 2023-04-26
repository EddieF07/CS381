using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject character;
    private int speed = 10;
    public bool canAttack;
    public int health;
    public int damage;
    //public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //weapon.transform.position = new Vector3(0,0.05549997f,0.872f);
        if(Input.GetKey(KeyCode.W))
            character.transform.position += speed * Time.deltaTime * Camera.main.transform.forward;
        if(Input.GetKey(KeyCode.S))
            character.transform.position += speed * Time.deltaTime * -Camera.main.transform.forward;
        if(Input.GetKey(KeyCode.A))
            character.transform.position += speed * Time.deltaTime * -Camera.main.transform.right;
        if(Input.GetKey(KeyCode.D))
            character.transform.position += speed * Time.deltaTime * Camera.main.transform.right;
        if(Input.GetMouseButtonDown(0))
        {
            //Play animation
            canAttack = true;
        }
        if(Input.GetMouseButtonUp(0))
            canAttack = false;
    }
}
