using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importamos la biblioteca para manejo de escenas

public class StageClearFPS : MonoBehaviour
{
    //Cuando se entra en el collider de la meta, cambia de escena
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
