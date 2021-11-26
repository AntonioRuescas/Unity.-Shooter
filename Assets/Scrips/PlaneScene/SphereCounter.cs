using System.Collections;
using System.Collections.Generic;
using TMPro; //Importamos librería para usar los textos pro de Unity
using UnityEngine;

public class SphereCounter : MonoBehaviour
{
    //Inicializamos la variable tipo entero sphereCounter a 0 y asigno otro variable para el texto de la pantalla 
    public int sphereCounter = 0;
    public TextMeshProUGUI textSphereCounter;
    // Start is called before the first frame update
    void Start()
    {
        //Inizializamos la variable sphereCounter en el Start y se muestran por pantalla y por consola
        Debug.Log("Esferas recogidas: " + sphereCounter);
        textSphereCounter.text = "Esferas recogidas: " + sphereCounter;       
    }
    //Método OnTriggerEnter para detectar la colisión de la esfera
    void OnTriggerEnter(Collider other)
    {
        //Asignamos el tag Sphere a la esfera        
        if (other.CompareTag("Sphere")) 
        {
            //Si se choca contra la esfera el contador de esferas aumenta en 1 unidad
            sphereCounter += 1;
            //La información se muestra por consola y en pantalla
            Debug.Log("Esferas recogidas: " + sphereCounter);
            textSphereCounter.text = "Esferas recogidas: " + sphereCounter;
            //Se destruye el objeto del tag, en este caso la esfera
            Destroy(other.gameObject);
        }      
    }
}
