using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour

{
    public Animator policia;//Declaramos y accedemos al animator del policia.
    public Animator player;//Declaramos y accedemos al animator del  player.
    public GameObject  PanelLost;//Invocamos el panel de perder que se activa mas adelante.
    public float contar = 0f;//Un contador que se usa mas adelante
    public float contar2 = 0f;//Un contador que se usa mas adelante
    public bool change = false;//Un boleano para poder activar los contadores .
   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;//Igualamos la velocidad del juego a 1 para qu7e transcurra de manera normal al iniciarse el nivel.
    }
    // Update is called once per frame
    void Update()
    {
        if (change)//Si el boleano de la collision es verdadero pasa lo siguiente
        {
            contar2 += Time.fixedDeltaTime;//El contador de tiempo empieza a correr    
        }

        if(contar2 >= 0.7f)//Si el contador de arriba es superior a 0.7 segundos ocurre lo siguiente:
        {
            Time.timeScale = 0f;//El tiempo general del juego se pausa al igualarlo a 0
            PanelLost.SetActive(true);//El panel de perder se activa 
            follow.policia = true;//El controlador del polciia se activa ya que el panel tapa la pantalla no se ve 

        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linterna1")//Se activaran las siguientes cosas cuando estoy dentro del tag "Linterna1" 
        {
            contar += Time.fixedDeltaTime;//Mientras estemos en ese collider  el contador de tiempo estara contando

            if(contar >= 0.15f)//Si el contador es mayor a 0.15 segundos ocurrira lo siguiente:
            {
                policia.PlayInFixedTime("atackPoli");//Se reproduce la aniamcion del policia de atrapar al player
                player.PlayInFixedTime("deadPunk");//Se reproduce la animacion del player de morir atrapado por el policia
                follow.policia = false;//El controlador del policia se apaga al hacer esa animacion 
                LvlTutorial.EstadoPlayer = false;//El controlador del personaje se apaga al ser atrapado
                change = true;//El boleano del update se vuelve verdadero 
            }
        }  
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Linterna1")
        {
            contar = 0f;  //Si sale del collider la linterna1 el contador se convierte en 1 y se resetea.         
        }
    }
}
