using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public GameObject menu;//Declaramos este objecto que el cuadro de dialogo de la abuelita de informacion .
    bool change = true;//Este buleano maneja que si ya entro en el dialogo no vuelva a entrar.
   

   

    private void Start()
    {
        change = true;//Lo hacemos verdadero al empezar la escena para asegurarnos que el dialogo se genere
    }

    private void Update()
    {
       
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Menu")//Esto se activa si colisiono con un objeto con el tag menu
        {
            if(change == true)//Si change es verdadero activa el objecto menu y llama a la clase de dialogue manager en iotro script
            {        
                menu.SetActive(true);//Activa el cuadro de dialogo de la abuelita
                FindObjectOfType<DialogueManager>().StartDialogue();//Busca el objeto con el tipo dialogue manager y reproduce ese metodo  
                
               
            }        
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Menu")
        {
            change = false;//Cuando sale de la coliision del objeto el boleano se hace falso impidiendo que se repita el dialogo 
        }
    }
}
