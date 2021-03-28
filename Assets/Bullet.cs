using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cheguei");
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);

    }
}
