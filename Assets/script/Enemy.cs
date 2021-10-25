using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private float timeBtwAttack;
    private float stopTime;
    private float startTimeBtwAttack;
    public int damage;
    public float startStopTime;
    public float normalSpeed;
    private player player;
    private Animator anim;


    private void Start()
    {
        player = FindObjectOfType<player>();
        anim = GetComponent<Animator>();
        normalSpeed = speed;
    }
    private void Update()
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");
            }

            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        player.health -=damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}

