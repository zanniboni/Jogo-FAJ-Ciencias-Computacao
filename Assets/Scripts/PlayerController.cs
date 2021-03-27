using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRB;
    Transform myAvatar;
    Animator myAnim;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;


    private void OnEnable()
    {
        WASD.Enable();
    }

    private void OnDisable()
    {
        WASD.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAvatar = transform.GetChild(0);

        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.ResetTrigger("key_down");
        myAnim.ResetTrigger("key_up");
        movementInput = WASD.ReadValue<Vector2>();


        if (movementInput.x > 0)
        {
            myAnim.SetTrigger("key_side_right");
            myAnim.ResetTrigger("key_side_left");
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        } 

        if(movementInput.x < 0)
        {
            myAnim.ResetTrigger("key_side_right");
            myAnim.SetTrigger("key_side_left");
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }

        if (movementInput.y < 0)
        {
            myAnim.ResetTrigger("key_up");
            myAnim.SetTrigger("key_down");
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        }
        if (movementInput.y > 0)
        {
            myAnim.ResetTrigger("key_down");
            myAnim.SetTrigger("key_up");
            myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);

        }



        myAnim.SetFloat("Speed", movementInput.magnitude);

    }




    private void FixedUpdate()
    {

        myRB.velocity = movementInput * movementSpeed;
    }


}

