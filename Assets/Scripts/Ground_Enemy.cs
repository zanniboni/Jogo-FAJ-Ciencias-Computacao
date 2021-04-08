using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Enemy : MonoBehaviour
{
    [SerializeField] private float attackDamage = 30f;
    [SerializeField] private float attackSpeed = 0.002f;
    private float canAttack;
    private Collider2D player;

    private void Update()
    {
        atacar_jogador();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other;
    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
    
    }

    private void atacar_jogador(){

        if(player != null){
            if (player.gameObject.tag == "Player")
            {
                if (attackSpeed <= canAttack)
                {
                    
                    player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                    canAttack = 0f;

                }
                else
                {
                    canAttack += Time.deltaTime;
                }
            }   
        }

    }
}
