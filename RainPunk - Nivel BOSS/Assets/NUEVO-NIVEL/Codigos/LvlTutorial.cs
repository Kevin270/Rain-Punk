using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlTutorial : MonoBehaviour
{
    public Rigidbody2D RB;//Declaramos al rigibody del personaje principal
    public float jumpTakeOffSpeed = 7;//Este flotante almacena la velocidad a la que desciende el personaje despues de saltar.
    public float jumpForce = 5.0f;//Este flotante almacena la potencia del salto del player.
    public GameObject player;//Este es el jugador para poder acceder a su posicion y  similares.
    public Animator algo;//Accedemos al animator del player.
    public SpriteRenderer judio;//Declaramos al sprite renderer del personaje para poder cambiarlo luego.
    public GameObject down;//El collider inferior del player .
    public GameObject idle;//El collider superior del personaje 
    public GameObject camera1, camera2, camera3, puertasola, puertabloqueada, pchack;//Las diferentes camara para cambios y otros objetos
    public GameObject key;//La llave que se agarra en el primer nivel .
    public Animator llave;//El animator de la llave.
    public Animator murito;//La animacion del muro del tutorial .
    public bool canJump = true;//Un boleano utilizado para impedir el salto infinito del player.
    public static bool EstadoPlayer = true;//El controlador del personaje es habilitado o bloqueado por este boleano.
    public Slider hacking;//El slider arriba cuando se esta hackeando un computador.
    public GameObject llavegirando;//La llave para poder acceder a su posicion y ciertas condicionales 
    public int vidaBOSS = 3;
    bool puedehack = false;
    public GameObject vida, vida1, vida2;
    public GameObject vence;

    public GameObject puertaUnlock, cosascayendo;
    


    // Use this for initialization
    void Start()
    {
        key.SetActive(true);//Hacemos que cuando empieze la escena la llave este activada
        puertabloqueada.SetActive(false);//Hacemos que cuando la empieze la escena la puerta este bloqueada y no se pueda pasar
        hacking.gameObject.SetActive(false);//Hacemos que el slider del hackeo este desactivado cuando empieze la escena.
        RB = GetComponent<Rigidbody2D>();//Obtenemos el componente rigibody del personaje
    }

    // Update is called once per frame
    void Update()
    {
        llavegirando.transform.Rotate(0f, 0f, 20f * Time.deltaTime * 10);//Hacemos que la llave del tutorial 1 este girando constantemente

        if (EstadoPlayer)//Dependiendo de este buleano si es verdadero o falso 
        {
            if (Input.GetKey(KeyCode.RightArrow))//Si oprimimos la tecla D hara lo siguiente :
            {
                if (judio.flipX == true)//Aqui preguntamos que si su flip en x es verdadero hara o siguiente:
                {
                    judio.flipX = false;//Hacemos que su flip sea falso y asi permite rotar hacia la derecha
                }
                algo.SetBool("run", true);//Si orpime la D constantemente se activa la animacion de correr             
                transform.desplazajugadorderecha(); //Esto se encarga del desplazamiento del player en "X" hacia la derecha

            }
            if (Input.GetKey(KeyCode.LeftArrow))//Si oprimimos la tecla A hara lo siguiente :
            {
                if (judio.flipX == false)//Aqui preguntamos que si su flip en x es falso hara o siguiente:
                {
                    judio.flipX = true;//Hacemos que su flip sea verdadero y asi permite rotar hacia la izquierda
                }
                algo.SetBool("run", true);//Si orpime la A constantemente se activa la animacion de correr
                transform.desplazajugadorizquierda();  //Esto se encarga del desplazamiento del player en "-X" hacia la izquierda      
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))//Si no oprimimos las teclas A y D al mismo tiempo hara lo siguiente
            {
                algo.SetBool("run", false);//La animacion de correr se apagara para evitar bugs de presionarlas al mismo tiempo

            }

            if (canJump)//Si este boleano es verdadero hara lo siguiente:
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))//Y oprimimos la tecla W hara lo siguiente:
                {
                    canJump = false;//Hacemos el boleano de salto falso para evitar saltos infinitos 
                    RB.SaltoDelPersonaje();    //Esto le da el salto en "Y" accediendo al velocity y empujando hacia arriba
                    algo.animacionsalto();  //Esto llama a la animacion de salto de PunkGomez 
                }
            }
        }
        else//Si no se ejecuta lo de arriba ocurre lo siguiente :
        {
            algo.SetBool("run", false);//La niamacion de correr se mantiene apagada para evitar errores en el animator     
        }

        if (puedehack)
        {
            if (Input.GetKey(KeyCode.E))//Y mientras oprimimos la letra E hara lo siguiente:
            {
                print("coger");

                hacking.gameObject.SetActive(true);//El slider encima de la cabeza del jugador se activa
                hacking.value += Time.deltaTime;//El valor del slider comienza a subir mientras se presione la E
                EstadoPlayer = false;//El controlador del player se apaga para evitar que se mueva
                algo.SetBool("down", true);//Se activa la animacion de hackeo del personaje 
                down.SetActive(true);//El collider inferior del personaje se activa
                idle.SetActive(true);//El collider inferior del personaje se activa

                if (hacking.value >= 5)//Si el valor del slider el mayor o igual a 5 hara lo siguiente:
                {
                    hacking.gameObject.SetActive(false);//El slider arriba del personaje se desactiva 
                    murito.SetBool("wall", true);//La animacion del muro que evita el paso se activa y deja pasar                  
                    pchack.transform.position = new Vector2(0, 0);
                    EstadoPlayer = true;//El controlador del personaje se activa de nuevo                   
                    algo.SetBool("down", false);//La animacion delp ersonaje de hackar se apaga tambien  

                }
            }
            else
            {
                algo.SetBool("down", false);//La animacion del personaje de hackar se desactiva
                idle.SetActive(true);//El collider superior se activa para evitar errores de collisiones
                hacking.value = 0;//El valor del slider se convierte en 0
                hacking.gameObject.SetActive(false);//El slider arriba del player se apaga.
                EstadoPlayer = true;
            }


        }
        if (vidaBOSS == 2)
        {
            vida.SetActive(true);
        }
        if (vidaBOSS == 1)
        {
            vida1.SetActive(true);


        }
        if (vidaBOSS == 0)
        {
            vida2.SetActive(true);
            vence.SetActive(true);
            puertaUnlock.SetActive(false);
            cosascayendo.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Flood")//Si entramos en collision con el tag ""Flood" hara lo siguiente 
        {
            canJump = true;//El boleano se vuelve verdadero para permitir al jugador saltar 
        }
        else if (other.gameObject.tag == "Player")//Si entra en collision con el tag "Player" hara lo  siguinte: 
        {
            SceneManager.LoadScene(2);//Caragara la escena nuemro 3 
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hack")//Si sale del collider de "Hack" hara lo siguiente :
        {
            Destroy(other.gameObject);
            puedehack = false;
            algo.SetBool("down", false);//La animacion del personaje de hackar se desactiva
            idle.SetActive(true);//El collider superior se activa para evitar errores de collisiones
            hacking.value = 0;//El valor del slider se convierte en 0
            hacking.gameObject.SetActive(false);//El slider arriba del player se apaga.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NUVE")
        {
            vidaBOSS = vidaBOSS - 1;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "Hack")
        {
            puedehack = true;
        }
        else if (collision.gameObject.tag == "MundoTop")//Si entro en collision con el tag "MundoTop" hara lo siguiente 
        {
            SceneManager.LoadScene(6);//Cargara la escena numero 6 
        }
        else if (collision.gameObject.tag == "CargaNivel1")//Si entro en collision con el tag "Nivel3" hara lo siguiente 
        {
            SceneManager.LoadScene(5);//Cargara la escena de nivel 5
        }

        else if (collision.gameObject.tag == "Detectar")//Si entro en collision con el tag "Detectar" hara lo siguiente 
        {
            llave.SetBool("DOOR", true);//Se activa la animacion de la llave que abre la puerta del nivel tutorial
            puertasola.SetActive(false);//La puerta falsa de apaga 
            puertabloqueada.SetActive(true);//Se activa la salida por donde gana el jugador

        }


        else if (collision.gameObject.tag == "Nivel4")//Si entro en collision con el tag "Nivel4" hara lo siguiente 
        {
            SceneManager.LoadScene("MainMenu");//Cargara la escena del menu principal 
        }

        else if (collision.gameObject.tag == "Enemy")//Si entro en collision con el tag "Enemy" hara lo siguiente:
        {
            camera1.SetActive(false);//La camara que sigue al jugador se desactiva y cambia a la otra
            camera2.SetActive(true);//La camara que apunta al nivel en genral se activa y permite ver donde esta la llave en el nivel
        }

        else if (collision.gameObject.tag == "Mundo")//Si entra en colission con el tag "Mundo" hara lo siguiente :
        {
            FindObjectOfType<LoadingScene>().escena1();//Cargara el objeto que es el panel de carga.
        }

        else if (collision.gameObject.tag == "BOSS")//Si entra en colission con el tag "Mundo" hara lo siguiente :
        {
            SceneManager.LoadScene(7);//Cargara el objeto que es el panel de carga.
        }

        else if (collision.gameObject.tag == "GANAR")//Si entra en colission con el tag "Mundo" hara lo siguiente :
        {
            SceneManager.LoadScene(0);//Cargara el objeto que es el panel de carga.
        }

    }
    
}




    


