using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoScript : MonoBehaviour {
    [SerializeField] int danyoFuego = 10;
    [SerializeField] ParticleSystem incendio;

    private void Start()
    {
        Destroy(this.gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name.Equals("Player"))
        {
            other.GetComponent<Player>().RecibirDanyo(danyoFuego);
            ParticleSystem[] particulas = other.GetComponentsInChildren<ParticleSystem>();
            foreach(ParticleSystem particula in particulas)
            {
                if (particula.gameObject.name.Equals("Arder"))
                {
                    particula.Play();
                }
            }


        }
    }
}
