using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameritas : MonoBehaviour
{
    public Animator player;//Declaramos este animator para poder llamarlo 
    public GameObject panellost;//El panel de perder para activarlo o apagarlo
    float contar = 0f;//Declaramos un flotante para usarlo de contador
    float contar2 = 0f;//Declaramos un flotante para usarlo de contador
    bool change = false;//Un boleano para manejar el contador cuando muera


    // Update is called once per frame
    void Update()
    {
        if (change)//Si este boleano es verdadero hara lo siguiente:
        {
            contar2 += Time.fixedDeltaTime;//Comienza a contar este flotante  para cargar todo lo despues de la muerte.
        }

        if(contar2 >= 0.5f)//Si el contador de arriba es 2 o superior hara lo siguiente: 
        {
            panellost.SetActive(true);//El panel de perder se activa 
            Time.timeScale = 0;//La velocidad del juego se vuelve cero.
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TopCamera")//Si entra en collision con un objecto con este tag hara lo siguiente:
        {
            contar += Time.fixedDeltaTime;//Empeza un contador mientras este en collision con el tag
            if(contar >= 1f)//Si el contador llega a ser 1 o mayor hara lo siguiente:
            {
              player.PlayInFixedTime("deadPunk");//Se activa la nimacion de muerte del player
              LvlTutorial.EstadoPlayer = false;//Se desactiva el controlador del jugadorp ara no mmoverse cuando muera
                change = true;  //Volvemos verdadero el boleano que se llama en update
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopCamera")//Si sale de la collision con el objeto con ese tag pasa lo siguiente:
        {
            contar = 0f;//Este contador de muerte se convierte en cero al salir del tag.
        }
    }
}
