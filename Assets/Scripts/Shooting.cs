using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    public float bulletForce = 20f;

    void Update()
    {

        var keyboard = Keyboard.current;
        var hit_space = keyboard.spaceKey.wasPressedThisFrame;

        if (hit_space)
        {
            atirar();
        }
    }

    void atirar()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.root.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.root.GetComponent<PlayerController>().lastInput * bulletForce, ForceMode2D.Impulse);
    }
}
