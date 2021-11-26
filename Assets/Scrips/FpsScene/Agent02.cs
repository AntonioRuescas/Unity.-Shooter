using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Importamos biblioteca de Unity


public class Agent02 : MonoBehaviour
{
    //Definimos variables
    public NavMeshAgent sentinel;
    public GameObject player;
    public GameObject patrolPoint1;
    public GameObject patrolPoint2;
    public int actuallyDestiny;
    public float margin = 1;
    public float rangeDetection = 30f;
    public float angleDetection = 60f;
    public int currentHealth = 5;
    private int dieHealth = 0;
    public float shootingInterval = 2f;
    private float readyFire;
    public float impulseForce = 2500f;
    public GameObject enemyBullet;
    public GameObject enemySpawnFire;
    public AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        //Asignamos en el star al perseguidor su componente NavMeshAgent
        sentinel = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Metodos para detectar al jugador y patrullar
        PlayerDetection();
        Patrol();       
    }

    //Metodo para detectar al jugador
    void PlayerDetection(){
        //Calculamos distancia del centinela al jugador
        Vector3 distancePlayer = player.transform.position - this.transform.position;
        if (distancePlayer.magnitude < rangeDetection) 
        {
            if (Physics.Raycast(this.transform.position, distancePlayer, out RaycastHit hit, rangeDetection))
            {
                float angle = Vector3.Angle(this.transform.forward, distancePlayer);
                if (hit.transform.CompareTag("Player"))
                {
                    if ((angle < angleDetection))
                    {
                        //Si nos ve el centinela he añadido esta linea para que nos siga hasta que salimos de su rango de visión y además dispare el player
                        sentinel.SetDestination(player.transform.position);
                        FireEnemy();
                    }
                }
            }
        }        
    }

    //Metodo para pratruyar, cuando llega a un punto se resetea el punto de destino actual y envia al centinela al otro punto establecido
    void Patrol() {
        //Calculamos distancia del centinela al destino de patrulla
        Vector3 distanceDestiny = this.transform.position - sentinel.destination;
        
        if (distanceDestiny.magnitude < margin)
        {
            //Llegamos al destino
            if (actuallyDestiny == 1)
            {
                //Nuevo destino
                actuallyDestiny = 2;
                //Enviamos al punto 2
                sentinel.SetDestination(patrolPoint2.transform.position);
            }
            else
            {
                //Nuevo destino
                actuallyDestiny = 1;
                //Enviamos al punto 1
                sentinel.SetDestination(patrolPoint1.transform.position);
            }
        }
    }
    //Metodo de disparo del enemigo con cadencia en el disparo
    void FireEnemy() {

        readyFire += Time.deltaTime;
        
        if (readyFire > shootingInterval)
        {
            GameObject Fire = Instantiate(enemyBullet, enemySpawnFire.transform.position, enemySpawnFire.transform.rotation);
            Fire.GetComponent<Rigidbody>().AddForce(Fire.transform.forward * impulseForce);
            fireSound.Play();
            readyFire = 0;
            Destroy(Fire, 1);
        }
    }
    //Metodo para la vida del centinela, si colisiona con la bala del jugador, se resta vida, si la vida llega a la vida de muere se detruye el centinela
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            currentHealth--;
            Debug.Log("Vida centinela: " + currentHealth);
            
            if (currentHealth == dieHealth)
            {
                Destroy(this.gameObject);
                Debug.Log("CENTINELA DERROTADO!!");
            }
        }
    }
}
    

