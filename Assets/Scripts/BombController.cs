using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private Collider2D target;
    public GameObject hitEffect;
    [SerializeField] private float danoBomba = 70f;
    public bool explodiu = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        target = other;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        target = null;
    }

    void Update(){
        verificaExplosao();
    }
    public void verificaExplosao()
    {
        Debug.Log(explodiu);
        if (explodiu)
        {
            if (target != null)
            {
                if (target.gameObject.tag == "Player" || target.gameObject.tag == "Enemy")
                {
                    Debug.Log("dano bomba recebido");
                    target.GetComponent<PlayerHealth>().UpdateHealth(-danoBomba);
                    explodirBomba();
                }
            } else {
                explodirBomba();
            }
        }

    }
    public void explodirBomba()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
    
    public void SetExplosion(bool explosion){
        explodiu = explosion;
    }
}
