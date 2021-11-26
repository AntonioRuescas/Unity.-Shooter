using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{
    //Variables a utilizar, añado de la clase Agent01 y Agent02 una variable para luego encontrar la barra de salud
    public GameObject door;
    public Agent02 health2;
    public Agent01 health1;
    public Agent02 health3;
    
    // Update is called once per frame
    void Update()
    {
        EnemyHealth();
    }
    //Metodo para destruir la puerta y dar acceso al fin del nivel cuando se destruyen todos los enemigos
    void EnemyHealth() 
    {
        //Encuentro la variable currentHealth de los enemigos a través de sus scrips y si son igual a 0 la puerta de destruye y se muestra un mensaje por consola
        if ((health1.currentHealth == 0) && (health2.currentHealth == 0) && (health3.currentHealth == 0))
        {
            Destroy(door);
            Debug.Log("PUERTA DESTRUIDA!! YA PUEDES SALIR DEL LABERINTO!!");
        }

    }
}
