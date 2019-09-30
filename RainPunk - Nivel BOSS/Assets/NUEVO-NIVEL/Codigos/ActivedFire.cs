using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedFire : MonoBehaviour
{

    public float contador , contador2;//Declramos estos flotantes para suarlos como contadores
    public GameObject fuego1, fuego2;//Estos 2 objetos corresponden a la parte superior e inferior del fuego
    bool verdad, verdad2;//Boleanos para controlar las activaciones del fuego


    // Start is called before the first frame update
    void Start()
    {
        fuego1.SetActive(true);//Cuando comienza la escena el fuego superior esta prendido 
        fuego2.SetActive(false);//Cuando comienza la escena el fuego inferior esta apagado.
        verdad = true;//El boleano comienza verdadero
        verdad2 = false; // El boleano comienza falso         
    }

    // Update is called once per frame
    void Update()
    {

        if(verdad == true)//Si el boleano es verdadero hara lo siguiente :
        {
            contador += Time.deltaTime;//Comenzara a contar el flotante 
        }
      
        else if ( contador >= 4)//Si el contador de arriba es mayor a 4 
        {
            verdad = false;//El boleano del  primer contador se vuelve falso
            fuego2.SetActive(true);//La parte inferior del fuego se activa 
            fuego1.SetActive(false);//La parte superior del fuego se apaga
            contador = 0f;//Igualo el contador a 0 para evitar que se sume de nuevo
            contador2 += Time.deltaTime ;//Comienza el conteo del contador 2 del segundo estado del fuego
            verdad2 = true;//Hago verdadero el otro boleano 
        }

        else if (verdad2 == true)//Si el segundo boleano es verdadero hara lo siguiente:
        {
            contador2 += Time.deltaTime;//El segundo contador empieza a contar
        }

        else if ( contador2 >= 3.3f)//Si el segundo contador es mayor a 3.5 hara lo siguiente :
        {
            fuego2.SetActive(false);//El fuego inferior se apaga
            fuego1.SetActive(true);//El fuego superior se activa
            contador2 = 0f;//Igualamos el segundo contador a 0
            contador += Time.deltaTime ;//Comienza el primer contador de nuevo 
            verdad = true;//Y hacemos el primer boleano verdadero de nuevo
            
        }
    }
}
