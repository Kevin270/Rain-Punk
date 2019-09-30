using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject Police;//Accedmos al policia que es quein tiene el codigo ahora mismo
    bool entro;//Un boleano encargado del rotado en el patrullaje del guardia al empezar la escena
    public Animator PoliceWalk;// Accedemos al animator del policia 
    public float roundTime;//Declaramos este flotante para encargarse de la distancia del patrullaje del guardia
    public bool girar;// Un boleano que controla cuando el guardia va a girar en el patrullaje
    public  static bool policia = true;//Declaramos este boleano para acceder al controlador del policia y activarlo o desactivarlo
    public GameObject particulaataca;

    private void Update()
    {
        if (policia)//El boleano que controla todo lo del policia
        {
            if (entro)
            {
                //Esto se encarga del desplamiento del policia cuando comienza la escena
                this.transform.muevepolicia();
            }
            else
            {
                roundTime = roundTime + Time.deltaTime;//Aqui comienza el contador de la distancia

                if (roundTime < 2)//Si es menor a 2 se desplazara en esa dirreccion
                {
                    Police.transform.Translate(1f * Time.deltaTime, 0, 0);
                    //Esto accede al local scale del policia cuando gire para el patrullaje
                    transform.RutaGuaradia();         
                }
                 if (roundTime >= 2 && roundTime < 8)//Si en contador es mayor o igual a 2 y menor hara lo siguiente.
                {
                    Police.transform.Translate(-1f * Time.deltaTime, 0, 0);//Se desplazara hacia el otro lado 
                    //Esto accede al local sacale del policia en negativo cuando viene de regreso del patrullaje
                    transform.RutaGuaradiaDeRegreso();                
                }

                 if (roundTime >= 6)//Indica la distancia limite del patrullaje 
                {
                    roundTime = -2;
                }
            }           
        }
        else
        {
          
            PoliceWalk.AnimacionPoli();     //Activa la animacion de embestir del policia a PunkGomez
            particulaataca.SetActive(true);
        }

    }
    public void policiaparticulaPunch()
    {
        //Se activan estas particulas cuando atrapa al player
        particulaataca.SetActive(true);
    }
}
