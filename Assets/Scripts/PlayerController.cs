using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myRB;
    Transform myAvatar;
    Transform firePoint;
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
        var apertou_space = keyboard.spaceKey.wasPressedThisFrame;
        var apertou_ctrl = keyboard.ctrlKey.isPressed;
        
        movementInput = WASD.ReadValue<Vector2>();
        //Apertou W
        ativarAnimacoes("apertou_w", apertou_w);
        //Apertou S
        ativarAnimacoes("apertou_s", apertou_s);
        //Apertou D
        ativarAnimacoes("apertou_d", apertou_d);
        //Apertou A
        ativarAnimacoes("apertou_a", apertou_a);
        //Apertou espa�o
        ativarAnimacoes("apertou_space", apertou_space);
        //Apertou CTRL
        ativarAnimacoes("abaixar", apertou_ctrl);

        verificaMorte();
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

    void verificaMorte()
    {
        if(gameObject.GetComponent<PlayerHealth>().getHealth() < 0.1)
        {
            transform.Translate(Vector2.left * 0 * Time.deltaTime);
            myAnim.SetFloat("speed", 0);
            myAnim.SetFloat("health", 0);
            Destroy(gameObject, 0.6f);
        }
    }
}

