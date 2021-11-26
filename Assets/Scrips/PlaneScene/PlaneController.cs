using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    //Variables a utilizar y su anicialización

    public float velocityPlane = 30f;
    public GameObject bomb;
    public GameObject cannon;
    public float speedRotation = 50f;
    public float impulseForce = 2000f;
   
    // Update is called once per frame
    void Update()
    {
        PlaneMove();
    }

    void PlaneMove()
    {
        //Indicamos que el avión avance de forma autónoma hace adelante a la velocidad indicada.
        transform.Translate(Vector3.forward * velocityPlane * Time.deltaTime);
        
        //Indicamos que al pulsar las correspondientes teclas el avión rote sobre su eje x e y, he optado por hacerlo de esta manera por el diseño del nivel, ya que es más facil de controlar
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.Rotate(new Vector3(1, 0, 0) * speedRotation * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * speedRotation * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * speedRotation *  Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * speedRotation * Time.deltaTime, Space.World);
        }
        //Al pulsar la tecla izquierda del mouse hacemos que el avión dispare hacia adelante
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject Fire = Instantiate(bomb, cannon.transform.position, cannon.transform.rotation);
            Fire.GetComponent<Rigidbody>().AddForce(Fire.transform.forward * impulseForce);
            Destroy(Fire, 2);
        }
    }

    //Este codigo es más parecido al funcionamiento del avión, rotando sobre sus ejes y avanzando de forma autónoma, pero me resulta más intuitivo el mostrado arriba
    /*public float speed = 30f;
    public float speedRotation = 5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        transform.Rotate(-Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }*/

}

