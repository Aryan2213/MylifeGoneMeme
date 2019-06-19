using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int maxHealth;
    public bool enemyHit;
    public Animator anim;
    public SpriteRenderer sprite;
    [SerializeField]
    Transform[] waypoints;
    
    public float moveSpeed = 2f;
    [SerializeField]
    int waypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        Health = maxHealth;
        
    }
    private void Update()
    {
        Move();
        Death();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                     waypoints[waypointIndex].transform.position ,
                                     moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
            if(waypointIndex != waypointIndex - 1)
            {
                sprite.flipX = !sprite.flipX;
            }
            
        }
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            print("Fuck");
            Health--;
            anim.SetTrigger("Hit");

            Debug.Log("i Got hit");
        }
    }
    public void Death()
    {
        if(Health <= 0)
        {
            anim.SetBool("DeathAnim",true);
        }
    }
    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
