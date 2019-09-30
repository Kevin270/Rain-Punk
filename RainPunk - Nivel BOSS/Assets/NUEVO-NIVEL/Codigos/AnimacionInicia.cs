using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionInicia : MonoBehaviour
{

    public float contador = 0f;
    public GameObject camera1, camera2;
    bool change = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (change)
        {
            contador += Time.fixedDeltaTime;


            if(contador >= 5f)
            {
                camera1.SetActive(true);
                camera2.SetActive(false);

            }

            if(contador >= 9f)
            {
                LvlTutorial.EstadoPlayer = true;
                contador = 0f;
                change = false;
            }
        }




        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "VerVillano")
        {
            change = true;
            LvlTutorial.EstadoPlayer = false;
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "VerVillano")
        {
            change = false;
            Destroy(collision.gameObject);
        }
    }
}
