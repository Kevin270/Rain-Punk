using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingPanel;//Accedo al panel de carga cuando se cambia la escena.
    public Slider slider;//El slider de carga del panel de carga
    public Text progressTx;//El texto que aparece en el panel, el porcentaje de carga
    public void startChange()
    {
        StartCoroutine("LoadAsinc",2);//Esto se encarga de llamar la coruotine para la pantalla de carga.
    }
    public void escena1()
    {
        StartCoroutine("LoadAsinc", 3);//Esto se encarga de llamar la coruotine para la pantalla de carga.
    }
    public void escena2()
    {
        StartCoroutine("LoadAsinc", 6);//Esto se encarga de llamar la coruotine para la pantalla de carga.
    }
    public void escena3()
    {
        StartCoroutine("LoadAsinc", 7);//Esto se encarga de llamar la coruotine para la pantalla de carga.
    }
    public void escena4()
    {
        StartCoroutine("LoadAsinc", 5);//Esto se encarga de llamar la coruotine para la pantalla de carga.
    }

    IEnumerator LoadAsinc(int sIndex)//En esta coroutina hacemos la pantalla de carga
    {
        loadingPanel.SetActive(true);//Activamos el panel que almacena la pantalla de carga
        yield return new WaitForSeconds(1.5f);//Es la duracion del  pantalla de carga

        
        AsyncOperation asyncOP = SceneManager.LoadSceneAsync(sIndex);

        while (!asyncOP.isDone)
        {
            float progress = Mathf.Clamp01(asyncOP.progress / 0.9f);//El slider de rpogreso de la barra de procentaje
            slider.value = progress;//El valor del slider tomado del flotante de progress
            progressTx.text = progress * 100f + "%";//Se imprime en el texto el porcentaje tomado del slider.
            yield return null;
        }
    }
}

