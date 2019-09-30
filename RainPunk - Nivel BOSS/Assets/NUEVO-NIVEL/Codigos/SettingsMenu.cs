using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
    public AudioMixer audioMixer;//Declaramos un audiomixer publico para los cambios de volumenes dentro de la escena


	public void SetVolumen (float volumen){//Este metodo recibe un flotante que es el volumen del audio

        audioMixer.SetFloat("Cancion",Mathf.Log10( volumen) * 20f);// Multiplicamos el volumen de la cancion por el flotante de los demas sonidos en este caso del de "Cancion"

    }
}
