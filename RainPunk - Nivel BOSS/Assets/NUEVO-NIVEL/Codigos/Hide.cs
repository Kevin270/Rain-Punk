using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{

    public SpriteRenderer caja, caja1, caja2;//Declaramos las 3 cajas donde se podra esconder y poder acceder a su sprite renderer.
    public GameObject linterna1, linterna2, linterna3;//Decalramos como objetos las 3 linternas de los agurdias en el nivel
    public bool canHide = false;//Un boleano que permite el esconder o no dentro de las cajas
    public AudioSource esconderse;


    void Update()
    {
        if (canHide && Input.GetKey(KeyCode.DownArrow))//Al oprimir esta tecla y el bileano ser verdadero nos podremos esconder dentro de las cajas
        {
            esconderse.Play();
            caja.sortingOrder = 5;//El orden in layer de las cajas
            caja1.sortingOrder = 5;//El orden in layer de las cajas
            caja2.sortingOrder = 5;//El orden in layer de las cajas
            linterna1.SetActive(false);//Aqui desactivamos las linternas de los guardias
            linterna2.SetActive(false);//Aqui desactivamos las linternas de los guardias
            linterna3.SetActive(false);//Aqui desactivamos las linternas de los guardias
        }
        else
        {
            esconderse.Stop();
            caja.sortingOrder = 2;//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
            caja1.sortingOrder = 2;//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
            caja2.sortingOrder = 2;//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
            linterna1.SetActive(true);//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
            linterna2.SetActive(true);//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
            linterna3.SetActive(true);//Sino hace lo de arriba el orden in layer de cajas cambia y las linternas se activan
        }              
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Caja1") { //Cuando entra en coliision con este tag hara lo siguiente
            
            canHide = true;//Este boleano se activa para permitirnos esconder dentro del update
        }
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Caja1")//Si sale de la colision con la caja hara lo siguiente
        {          
            canHide = false;//Se desactiva el boleano del esconderse dentro del update y se activa el  "else".
        }      
    }
}
