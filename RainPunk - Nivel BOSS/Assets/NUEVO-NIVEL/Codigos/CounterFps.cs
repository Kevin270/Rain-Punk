using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CounterFps : MonoBehaviour//Esta clase nos permite visualizar los fps en la escena actual
{
    private float frequency = 1.0f;
    private string fps;
    void Start()
    {
        StartCoroutine(FPSs());//Lllamamos la coroutina cyuando comienza la escena
    }
    private IEnumerator FPSs()//Esta coroutina se encarga de acceder a los frams por seconds y mostrarlo en pantalla.
    {
        for (; ; )
        {
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;
            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }
    bool uiActiva = true;
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 10, 150, 20), fps);
    }
}