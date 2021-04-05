using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed;
    Animator myAnim;
    private bool movinRight = true;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        myAnim = GetComponent<Animator>();
        Invoke("patrulhar", 2);
    }
    void Update()
    {

        if(currentHealth > 0.1)
        {
            if (movinRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.localScale = new Vector2(Mathf.Sign(1), 1);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.localScale = new Vector2(Mathf.Sign(-1), 1);
            }
        }

        myAnim.SetFloat("speed", speed);

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(20);

    }
    

    void patrulhar()
    {
        if (movinRight == true)
        {
            movinRight = false;

        }
        else
        {
            movinRight = true;

        }
        Invoke("patrulhar", 2);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        myAnim.SetFloat("health", currentHealth);
        verificaMorte();
    }

    void verificaMorte()
    {
        if(currentHealth < 0.1)
        {
            transform.Translate(Vector2.left * 0 * Time.deltaTime);
            myAnim.SetFloat("speed", 0);
            Destroy(gameObject, 0.6f);
        }
    }
}