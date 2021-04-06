using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    public HealthBar healthBar;
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    public void UpdateHealth(float mod)
    {
        health += mod;
        
        if(health > maxHealth){
            health = maxHealth;
        } else if(health <= 0f){
            health = 0f;
            gameObject.GetComponent<PlayerController>().killPlayer(true);
            Debug.Log("Player Respawn");
        }
        healthBar.SetHealth(health);
    }


}
