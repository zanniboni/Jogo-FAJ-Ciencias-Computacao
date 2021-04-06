using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hunter : MonoBehaviour
{

    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;

    private void Update()
    {
        seguirJogador();

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;

            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void seguirJogador()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Enemy_Patrol>().ativarHunt(true);
            target = other.transform;
        }       


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Enemy_Patrol>().ativarHunt(false);
            target = null;
        }
    }
}
