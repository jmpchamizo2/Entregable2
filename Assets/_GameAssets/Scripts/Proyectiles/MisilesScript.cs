using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilesScript : MonoBehaviour {
    [SerializeField] int fuerzaMisil = 100;
    [SerializeField] int danyoMisil = 20;
    [SerializeField] AudioSource sonidoExplosion;


    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, -1) * fuerzaMisil);
            other.GetComponent<Player>().RecibirDanyo(danyoMisil);
            ParticleSystem[] particulas = other.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particula in particulas)
            {
                if (particula.gameObject.name.Equals("ExplosionMisil"))
                {
                    particula.Play();
                }
            }
            sonidoExplosion.Play();
           
        }
    }

}
