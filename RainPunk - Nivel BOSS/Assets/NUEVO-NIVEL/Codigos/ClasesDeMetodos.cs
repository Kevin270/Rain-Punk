using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClasesDeMetodos
{  
    public static void RutaGuaradia(this Transform policia) //Este metodo accede  a un transform para llamarlo en otro codigo
    {
        policia.localScale = new Vector3(0.18915f, 0.18915f, 0.18915f);//Cambiamos la rotacion del guardia 
    }

    public static void RutaGuaradiaDeRegreso (this Transform policiavuelve)//Este metodo accedemos al mismo transform de los policias.
    {
        policiavuelve.localScale = new Vector3(-0.18915f, 0.18915f, 0.18915f);//Cambia la  rotacion del guardia al otro lado
    }

    public static void SaltoDelPersonaje(this Rigidbody2D salta)//Este metodo es para el stalto del personaje 
    {
        salta.velocity = new Vector3(0, 10, 0);//Le damos un velocity para saltar en Y al player.
    }

    public static void animacionsalto( this Animator player)//Accedemos al animator del player con este metodo .
    {
        player.PlayInFixedTime("GomezJump");//Se activa la animacion del salto del player
    }

    public static void AnimacionPoli( this Animator policia)//En este metodo accedemos al animator de los policias
    {
        policia.PlayInFixedTime("atackPoli");//Se activa la aniamcion del policia de atacar o atrapar al player.
    }

    public static void desplazajugadorderecha ( this Transform player)//Accedemos al transform del player en este metodo 
    {
        player.Translate(0.05f * Time.deltaTime * 50, 0, 0);//Este translate se encarga del desplazamiento del jugador hacia la derecha
    }

    public static void desplazajugadorizquierda ( this Transform player)//Accedemos al transform del player en este metodo 
    {
        player.Translate(-0.05f * Time.deltaTime * 50, 0, 0);//Este translate se encarga del desplazamiento del jugador hacia la izquierda
    }
    public static void muevepolicia ( this Transform policia)//En este metodo llamamos al transform de los policias
    {
        policia.Translate(policia.localScale.x * 3f * Time.deltaTime, 0, 0);//Esto se encarga del desplazamiento del policia en X
    }
}