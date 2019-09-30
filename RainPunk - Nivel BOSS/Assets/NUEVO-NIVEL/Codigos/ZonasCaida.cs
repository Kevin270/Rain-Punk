using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonasCaida : MonoBehaviour
{
    public Animator player;//Declaramos para poder acceder a la animacion del personaje 
    public GameObject panelperder;//Este es el panel declarado que esta dentro del canvas
    float cuenta = 0;//Un flotante usado como contador de tiempo
    bool change= false;//Un boleano que se activa al morir el player.7
    public AudioSource puassonido;


    // Update is called once per frame
    void Update()
    {
        if (change)//Si este boleano es verdadero entra al contador de la muerte
        {
            cuenta += Time.fixedDeltaTime;//Aqui comienza a correr el contador de tiempo

            if (cuenta >= 0.5f)//Si el contador de arriba es mayor a 0.5 se activara el panel de perder 
            {
                puassonido.Stop();
                panelperder.SetActive(true);//Se activa este panel cuando el tiempo supera 0.5
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")//Si cae en la zona de muerte con el tag de "Dead" activa lo siguiente: 
        {
            puassonido.Play();
            player.PlayInFixedTime("deadPunk");//Se activa la animacion de la muerte del player
            LvlTutorial.EstadoPlayer = false;//El controlador del player es bloqueado con este buleano estatico 
            change = true;//Hacemos al buleano del contador de la muerte verdadero aqui.
        }
    }
}
