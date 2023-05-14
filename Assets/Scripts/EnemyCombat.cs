using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public int healthBar;
    public GameObject boss;
    public Collider enemyHurtBox;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar<=0)
        {
            Destroy(boss);
        }
    }
}
