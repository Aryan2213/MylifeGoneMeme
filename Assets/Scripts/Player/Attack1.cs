using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{



    public Collider2D rightAttackTrigger;
    public Collider2D leftAttackTrigger;
    public Transform Aplayer;
    // Start is called before the first frame update
    void Start()
    {
        rightAttackTrigger.isTrigger = true;
        leftAttackTrigger.isTrigger = true;
       

    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }


    void follow()
    {
        transform.position = Aplayer.position;
    }
}
