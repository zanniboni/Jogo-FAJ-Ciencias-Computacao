using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_Patrol : MonoBehaviour
{

    public bool isHunting = false;
    public float speed;
    Animator myAnim;
    private bool movinRight = true;


    void Start()
    {
        myAnim = GetComponent<Animator>();
        Invoke("patrulhar", 2);
    }
    void Update()
    {

        if(isHunting == false){
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

        correr(1);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bullet"){
            TakeDamage(20);
        }
        

    }

    void TakeDamage(int damage)
    {
        gameObject.GetComponent<PlayerHealth>().UpdateHealth(-damage);
        myAnim.SetFloat("health", gameObject.GetComponent<PlayerHealth>().getHealth());
        verificaMorte();
    }

    void verificaMorte()
    {
        if(gameObject.GetComponent<PlayerHealth>().getHealth() < 0.1)
        {
            transform.Translate(Vector2.left * 0 * Time.deltaTime);
            myAnim.SetFloat("speed", 0);
            Destroy(gameObject, 0.6f);
        }
    }

    void patrulhar()
    {
        if(isHunting == false){
            if (movinRight == true)
            {
                movinRight = false;
            }
            else
            {
                movinRight = true;
            }
        }
        Invoke("patrulhar", 2);

    }

    public void correr(float velocidade){
        myAnim.SetFloat("speed", velocidade);
    }

    public void atacar(bool attack){
        myAnim.SetBool("atacando", attack);
        Debug.Log(attack);
    }
    public void ativarHunt(bool hunting){
        isHunting = hunting;
    }

}