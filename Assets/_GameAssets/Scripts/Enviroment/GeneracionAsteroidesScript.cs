using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionAsteroidesScript : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidesLava = new GameObject[5];
    [SerializeField] int fuerza = 10;
    [SerializeField] int tiempoComienzo = 0;
    [SerializeField] int tiempoEntreAsteroides = 1;
    [SerializeField] int rangoDeFuerza = 5;
    private int anguloDeCaida = 25;
    private int numeroAsteroidesPosibles = 4;
    Transform player;
 



    private void Start()
    {
        InvokeRepeating("CaidaAsteroide", tiempoComienzo, tiempoEntreAsteroides);
        Transform[] tr = FindObjectsOfType<Transform>();
        foreach(Transform t in tr)
        {
            if (t.gameObject.name.Equals("Player"))
            {
                player = t;
            }
        }
    }

    private void Update()
    {
        this.transform.LookAt(player);   
    }

    private void CaidaAsteroide()
    {
        GameObject asteroide = Instantiate(asteroidesLava[(int)Random.Range(0, numeroAsteroidesPosibles)], this.transform.position, Quaternion.identity);
        asteroide.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * (fuerza + Random.Range(-rangoDeFuerza, rangoDeFuerza)), ForceMode.Impulse);
    }

}
