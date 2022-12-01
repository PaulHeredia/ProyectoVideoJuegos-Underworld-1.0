using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    //SerializeField ordena a Unity que guarde o restaure su estado. Unity SerializeField obliga a Unity a serializar un campo privado.
    [SerializeField] private float velocidad;
    //Controla ubiccion de ataque
    [SerializeField] private BoxCollider2D animation_Atack;
    private Rigidbody2D rigidboy2D;
    private Animator animator;
    private SpriteRenderer sprintePersonaje;
    //Define el offset del collider
    private float positionColX=0.5f;
    private float positionColY=0;
    //vida del personaje
    private int vidaPersonaje = 4;
    //comunicacion con el UIManager
    [SerializeField] UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidboy2D=GetComponent<Rigidbody2D>();
        //Buscar el Animator que se encuentra en el objeto hijo del Personaje"Ignia"
        animator=GetComponentInChildren<Animator>();
        ///Cambiar orientcion del personaje
        sprintePersonaje=GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      Movimiento();  
      Atacar();
    }
    private void Movimiento(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigidboy2D.velocity = new Vector2(horizontal,vertical)*velocidad;
        animator.SetFloat("Camina",Mathf.Abs(rigidboy2D.velocity.magnitude));
        //Control la direccion del personaje
        if(horizontal > 0){
            animation_Atack.offset=new Vector2(positionColX, positionColY);
            sprintePersonaje.flipX=false;
        }
        else if(horizontal < 0){
            animation_Atack.offset=new Vector2(-positionColX, positionColY);
            sprintePersonaje.flipX=true;
        }
    }
    private void Atacar(){
        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("Atacar");
        } 
        if (Input.GetKeyDown(KeyCode.K))
        {
            Herida();
        }
    }
    private void Herida(){
        if(vidaPersonaje > 0 )
        {
            vidaPersonaje--;
            uIManager.RstaCorazones(vidaPersonaje); 
            //si esta en 0
            if(vidaPersonaje == 0)
            {
                animator.SetTrigger("Rip");
                
                //Invoke(nameof(Morir),1f);
            }
        }
        
    }
    //private void Morir(){
        //Destroy(this,gameObject);
    //}
}

