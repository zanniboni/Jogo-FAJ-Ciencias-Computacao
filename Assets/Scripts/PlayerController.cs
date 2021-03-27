using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D myRB;
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
        myRB = GetComponent<Rigidbody2D>();
        myAvatar = transform.GetChild(0);
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var keyboard = Keyboard.current;
        var apertou_w = keyboard.wKey.isPressed;
        var apertou_s = keyboard.sKey.isPressed;
        var apertou_d = keyboard.dKey.isPressed;
        var apertou_a = keyboard.aKey.isPressed;
        var apertou_space = keyboard.spaceKey.isPressed;
        var apertou_ctrl = keyboard.ctrlKey.isPressed;

        movementInput = WASD.ReadValue<Vector2>();
        //Apertou W
        if (apertou_w)
        {
            ativarAnimacoes("apertou_w", apertou_w);
        } 
        else
        {
            ativarAnimacoes("apertou_w", apertou_w);
        }

        //Apertou S
        if (apertou_s)
        {
            ativarAnimacoes("apertou_s", apertou_s);
        } 
        else
        { 
            ativarAnimacoes("apertou_s", apertou_s); 
        }

        //Apertou D
        if (apertou_d)
        {
            ativarAnimacoes("apertou_d", apertou_d);
        }
        else
        {
            ativarAnimacoes("apertou_d", apertou_d);
        }

        //Apertou A
        if (apertou_a)
        {
            ativarAnimacoes("apertou_a", apertou_a);
        }
        else
        {
            ativarAnimacoes("apertou_a", apertou_a);
        }

        //Apertou espaço
        if (apertou_space)
        {
            ativarAnimacoes("apertou_space", apertou_space);
        }
        else
        {
            ativarAnimacoes("apertou_space", apertou_space);
        }

        //Apertou CTRL
        if (apertou_ctrl)
        {
            ativarAnimacoes("abaixar", apertou_ctrl);
        }
        else
        {
            ativarAnimacoes("abaixar", apertou_ctrl);
        }
        
    }


    private void ativarAnimacoes(string trigger, bool stateAnim)
    { 
        myAnim.SetBool(trigger, stateAnim);
        
        if(trigger == "apertou_a" && stateAnim)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(1), 1);
        } 

        if(trigger == "apertou_d" && stateAnim)
        {
            myAvatar.localScale = new Vector2(Mathf.Sign(-1), 1);
        }


        //myAvatar.localScale = new Vector2(Mathf.Sign(movementInput.x), 1);
        myAnim.SetFloat("Speed", movementInput.magnitude);
    }

    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }


}

