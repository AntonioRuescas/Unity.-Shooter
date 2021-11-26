using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importamos librería para usar el manejo de escenas en Unity

public class StageClear : MonoBehaviour
{
    //Cuando se entra en el collider de la meta, cambia de escena a la pantalla de GameOver
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Goal")) 
        {
            SceneManager.LoadScene(2);
        }
    }
}
