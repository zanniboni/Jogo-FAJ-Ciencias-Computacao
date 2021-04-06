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