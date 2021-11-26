using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    //Variables a utlilizar

    public float range = 30f;
    public GameObject particleEfectFire;
    public GameObject cam;
    public AudioSource fireSound;
    
    // Update is called once per frame
    void Update()
    {
        // Indicamos que al pusar el botón izquierdo del ratón se ejecute el metodo FireRay

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            FireRay();
            fireSound.Play();
        }               
    }
    //Metodo para controlar el RayCast
    void FireRay() {        
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) {
            Debug.Log("Has tocado " + hit.collider.name);
            
            GameObject efectFire = Instantiate(particleEfectFire, hit.point, this.transform.rotation);
            Destroy(efectFire, 0.5f);
            
            //He añadido al scrip de los enemigos como destruirlos, aunque inicialmente lo tenía aquí para destruirlos de forma directa
            /*if (hit.transform.CompareTag(("Enemy"))) {
                Destroy(hit.transform.gameObject);
            }*/
        }

    }
}
