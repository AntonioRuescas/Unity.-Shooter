using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Importamos biblioteca de Unity

public class Agent01 : MonoBehaviour
{
    //Definimos variables
    public NavMeshAgent persecutor;
    public GameObject player;
    public int currentHealth = 8;
    private int dieHealth = 0;
    public float rangeDetection = 30f;
    public float angleDetection = 45f;
    private float readyFire;
    public float shootingInterval = 5f;
    public float impulseForce = 2500f;
    public GameObject enemySpawnFirePersecutor;
    public GameObject enemyBulletPersecutor;
    public AudioSource fireSound;
    
    // Start is called before the first frame update
    void Start()
    {
        //Asignamos en el star al perseguidor su componente NavMeshAgent
        persecutor = this.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        //Indicamos que el perseguidor vaya a donde está player
        persecutor.SetDestination(player.transform.position);
        //Metodo para determinar que ocurre si nos ve
        PlayerDetection();
    }
    void PlayerDetection()
    {
        //Calculamos distancia del centinela al jugador
        Vector3 distancePlayer = player.transform.position - this.transform.position;
        if (distancePlayer.magnitude < rangeDetection)
        {
            //Si la distancia al jugador normalizada es mejor al rango de detección el perseguidor dispara un raycast
            if (Physics.Raycast(this.transform.position, distancePlayer, out RaycastHit hit, rangeDetection))
            {
                float angle = Vector3.Angle(this.transform.forward, distancePlayer);
                if (hit.transform.CompareTag("Player"))
                {
                    //El perseguidor si detecta al jugador y está dentro de su angulo de visión ejecuta método de disparo
                    if ((angle < angleDetection))
                    {
                        FireEnemy();
                    }
                }
            }
        }
    }
    //Metodo para disparar, se ha realizado una cadencia en el disparo
    void FireEnemy()
    {
        readyFire += Time.deltaTime;
        if (readyFire > shootingInterval)
        {
            GameObject Fire = Instantiate(enemyBulletPersecutor, enemySpawnFirePersecutor.transform.position, enemySpawnFirePersecutor.transform.rotation);
            Fire.GetComponent<Rigidbody>().AddForce(Fire.transform.forward * impulseForce);
            readyFire = 0;
            Destroy(Fire, 1);
            fireSound.Play();
        }
    }
    //Metodo para la vida del perseguidor, si colisiona con la bala del jugador, se resta vida, si la vida llega a la vida de muere se detruye el perseguidor
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            currentHealth--;
            Debug.Log("Vida Perseguidor: "+ currentHealth);

            if(currentHealth == dieHealth)
            {               
                Destroy(this.gameObject);
                Debug.Log("PERSEGUIDOR DERROTADO!!");
            }          
        }       
    }
}
