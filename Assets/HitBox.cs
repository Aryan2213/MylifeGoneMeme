using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Attack hit " + other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            print("Fuck");
            enemy.Health--;
            enemy.anim.SetTrigger("Hit");

            Debug.Log("i Got hit");
        }
    }
}
