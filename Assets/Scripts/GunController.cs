using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator gunAnim;
    Transform myGun;    
    public Transform hand;
    private string lookPos;
    public GameObject gun;
    private SpriteRenderer mySpriteRenderer;

   private void Awake()
   {
        gunAnim = gun.GetComponent<Animator>();
        mySpriteRenderer = gun.GetComponent<SpriteRenderer>();
   }
    public void RotateHand(){
        
        
        resetAnimGun();

        hand.position = transform.position;
        hand.rotation = transform.rotation;

        lookPos = gameObject.GetComponent<PlayerController>().playerLook;

        if(lookPos == "A" || lookPos == "D") {
            gunAnim.SetTrigger("gun_side");
            
            // Debug.Log("set gun side");
        } else if(lookPos == "W") {
            gunAnim.SetTrigger("gun_up");
            // Debug.Log("set gun up");
        } else {
            gunAnim.SetTrigger("gun_down");
            // Debug.Log("set gun donw");
        }

        if(lookPos == "A"){
            //myGun.localScale =  new Vector2(Mathf.Sign(1), 1);
            mySpriteRenderer.flipX = false;
        } else if(lookPos == "D"){
            // myGun.localScale =  new Vector2(Mathf.Sign(-1), 1);
            mySpriteRenderer.flipX = true;
        }

    }

    void resetAnimGun(){
        gunAnim.ResetTrigger("gun_side");
        gunAnim.ResetTrigger("gun_up");
        gunAnim.ResetTrigger("gun_down");
    }
}
