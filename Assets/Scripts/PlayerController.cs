using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    public Vector2 lastInput;
    Rigidbody2D myRB;
    Transform myAvatar;
    Animator myAnim;
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;
    public GameObject bombPrefab;
    public Transform spawnPoint;
    public string playerLook;
    public bool morreu = false;
    public Transform hand;
    public GameObject gun;
    private GameObject bombSpawned;
    

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
        playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();
        myAvatar = transform.GetChild(0);
        myAnim = GetComponent<Animator>();
        FindObjectOfType<GameManager>().VerificaVitoria();
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
        var apertou_c = keyboard.cKey.wasPressedThisFrame;
        var mouse = Mouse.current;
        
        movementInput = WASD.ReadValue<Vector2>();
        //Debug.Log(movementInput);
        if(movementInput.sqrMagnitude != 0){
            lastInput = movementInput;
        }
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

        if(apertou_c){
            plantar_Bomba();
        }
        verificaMorte();
        
    }

    private void FixedUpdate()
    {
        myRB.velocity = movementInput * movementSpeed;
    }

    public float effectTime = 0.3f;

    IEnumerator takeDamageEffect()
    {
        float deltaTime = 0;
        while(deltaTime <= effectTime)
        {
            deltaTime += Time.deltaTime;
            playerSprite.color = Color.Lerp(Color.white, Color.red, deltaTime / effectTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        deltaTime = 0;
        while (deltaTime <= effectTime)
        {
            deltaTime += Time.deltaTime;
            playerSprite.color = Color.Lerp(Color.red, Color.white, deltaTime / effectTime);
            yield return null;
        }

    }

    public void takeDamage()
    {
        StartCoroutine(takeDamageEffect());
    }
    private void plantar_Bomba(){
        GameObject bomb = Instantiate(bombPrefab, spawnPoint.position, transform.rotation);
        bombSpawned = bomb;
        Invoke("explodirBomba", 2);
    }

    void explodirBomba(){
        bombSpawned.GetComponent<BombController>().SetExplosion(true);
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
        checkPlayerLook(trigger, stateAnim);
        myAnim.SetFloat("Speed", movementInput.magnitude);
    }
    private void checkPlayerLook(string trigger, bool stateAnim){

        if(stateAnim){
            if(trigger == "apertou_a"){
                playerLook = "A";
            } else if(trigger == "apertou_d"){
                playerLook = "D";
            } else if(trigger == "apertou_s"){
                playerLook = "S";
            } else if(trigger == "apertou_w"){
                playerLook = "W";
            }
            gameObject.GetComponent<GunController>().RotateHand();            

        }
    }

    void verificaMorte()
    {

        if(gameObject.GetComponent<PlayerHealth>().getHealth() < 0.1)
        {
            transform.Translate(Vector2.left * 0 * Time.deltaTime);
            myAnim.SetFloat("speed", 0);
            myAnim.SetFloat("health", 0);
            Destroy(gameObject, 0.8f);
            morreu = true;
            FindObjectOfType<GameManager>().EndGame();
            
            
        }
    }
    
}

