using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelLost : MonoBehaviour//Este script almaecena los botones de reinicio de las diferentes escenas.
{
  
    public void reiniciar1()//Al llamar este metodo ocurre los iguiente: 
    {
        SceneManager.LoadScene(1);//Cargara esta escena designada
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
    }
    public void reiniciar2()//Al llamar este metodo ocurre los iguiente: 
    {
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
        SceneManager.LoadScene(3);//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
    }
    public void reiniciar3()//Al llamar este metodo ocurre los iguiente: 
    {
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
        SceneManager.LoadScene(5);//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
    }
    public void reiniciar4()//Al llamar este metodo ocurre los iguiente: 
    {
        SceneManager.LoadScene("Lvl-2");//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
    }
    public void reiniciar5()//Al llamar este metodo ocurre los iguiente: 
    {
        SceneManager.LoadScene(7);//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
    }

    public void niveles()//Al llamar este metodo ocurre los iguiente: 
    {
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
        SceneManager.LoadScene(4);//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
    }
    public void MainMenu()//Al llamar este metodo ocurre los iguiente: 
    {
        Time.timeScale = 1;//El tiempo general se iguala a 0 para volver el tiempo del juego a normal.
        SceneManager.LoadScene("MainMenu");//Cargara esta escena designada
        LvlTutorial.EstadoPlayer = true;//Volvemos a activar el controlador del player pata evitar errores.
    }
}
