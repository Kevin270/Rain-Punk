using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{

    public GameObject MenuPause, Opcione, Creditos, botonPause;//Declaramos esto para acceder a los difentes paneles dentro del canvas
    public Image taparMundo;//Una imagen que tapa la camara para el efecto de brillo
    public Slider sliderTono;//Un slider que controla la transparencia de la imagen declarada arriba


    // Update is called once per frame
    void Update()
    {
        Color cTemp = taparMundo.color; //Iualamos el color de la imagen a la un color nuevo
        taparMundo.color = new Color(cTemp.r, cTemp.g, cTemp.b, sliderTono.value < 0.85f ? sliderTono.value : 0.85f);//Dependiendo del valor de slider, es la transparencia que tiene la imagen.
    }

    public void Detener()//Este metodo se encarga de que al darle al boton pausa el juego se pausa y se ativa el menu pausa.
    {
        botonPause.SetActive(false);//Desactivo el boton pausa de la escena
        MenuPause.SetActive(true);//Activo el panel que es el menu de pausa 
        Time.timeScale = 0f;//El juego se pone en pause
    }

    public void Reanudar()//Al llamar este metodo se desactiva el menu de pausa y la escena vuelve a su velocidad normal.
    {
        botonPause.SetActive(true);//El boton de pausa se activa
        MenuPause.SetActive(false);//El panel de pausa se desactiva
        Time.timeScale = 1f;//El tiempo general del juego vuelve a ser normal.
    }

    public void Opcioncitas()//Este metodo almacena el panel de opciones dentro del panel de menu pausa.
    {
        Opcione.SetActive(true);//Activamos el panel de opciones.
        MenuPause.SetActive(false);//Desactivamos el menu pausa
    }

    public void RegresarMenuPause()//Este metodo se llama dentro del menu de opciones 
    {
        MenuPause.SetActive(true);//El menu de pausa se activa
        Opcione.SetActive(false);//El panel de opciones se desactiva tambien
        Creditos.SetActive(false);//El panel de creditos se desactiva tambien para evitar fallos      
    }

    public void Iniciamundo()//Este metodo permite  cargar la escena 4
    {
        SceneManager.LoadScene(4);
    }

    public void CerrarAll()//Este metodo se utiliza para cerrar el juego, el boton de salir esta en el menu principal del juego
    {
        Application.Quit();//Esto sirve para cerrar el juego.
    }


    public void MenuPrincipal()//Dentro del menu de pausa esta el boton menu principal con este metodo
    {
        SceneManager.LoadScene("MainMenu");//Carga la escena del menu principal 
        Time.timeScale = 1f;//El tiempo del juego se reanuda a su tiempo normal.
    }

    public void creditis()//Esto llama al panel de creditos delntro del menu de pausa
    {
        Creditos.SetActive(true);//Se activa el panel de creditos
        MenuPause.SetActive(false);//Se desactiva el panel de menu de pausa.
    }

    public void regresadeopcionesmainmenu()
    {
        Opcione.SetActive(false);
    }
}
