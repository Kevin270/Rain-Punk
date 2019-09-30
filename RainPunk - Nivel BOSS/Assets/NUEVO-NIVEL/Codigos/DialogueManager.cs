using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [TextArea(3, 10)]
    public string[] sentences;//Declaramos un array de strings que seran las oraciones que dira la abuelita
    public Animator GrandMa;//Accedemos al animator del cuadro de dialogo de la abuelita
    public Text dialogueText;//Esto es el texto que se ve en el cuadro de dialogo
	private Queue<string> sentencesQueue;//Esto sirve para poder hacer bien el recorrdio del array
 


    // Use this for initialization
    void Start () {
		sentencesQueue = new Queue<string>();       
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue ()//Este metodo permite iniciar el cuadro de dialogo 
	{
   
        LvlTutorial.EstadoPlayer = false;//Apago el controlador del personaje para que lea el dialogo y comprenda historia y controles
        GrandMa.SetBool("Paso1", true);//Activo la animacion del cuadro de dialogo inicial.

        foreach (string sentence in sentences)
		{
 			sentencesQueue.Enqueue(sentence);//Esto permite el recorrido del array de los textos
		}
        print(sentencesQueue.Count);//Esto detecta cuantos oraciones hay en el array para recorrerlos y ennumerarlos
		DisplayNextSentence();//Esto llama al metodo de abajo para cuando acabe el array de oraciones.
	}





	public void DisplayNextSentence ()//Este metodo se llama cuando ya no hay oraciones por recorrer
	{
		if (sentencesQueue.Count == 0)//Si la cantidad de oracion es igual a 0 hara lo siguiente:
		{           
            EndDialogue(); //LLama al metodo de EndDialogue que esta mas abajo       
            return;
		}

		string sentence = sentencesQueue.Dequeue();//Se asegura de la cantidad de oraciones en el array
		StopAllCoroutines();//Detiene la coroutina de la generacion de oraciones
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)//Esta corroutina se encarga de mostrar y recorrer las oraciones
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())//Un for para que las oraciones aparezcan de manera procedural cuando aparezcan
		{
			dialogueText.text += letter;//Se encargara de ir haciendo aparecer letra por letra de las oraciones
			yield return null;
		}
	}

    void EndDialogue()//Este metodo se encargue de lo siguiente:
    {
        LvlTutorial.EstadoPlayer = true;//Activo el controlador del personaje de nuevo
        GrandMa.SetBool("Paso2", true);//La animacion del cuadro de dialogo de la abuelita de bajar y ocultarse de la pantalla.
       
    }
}
