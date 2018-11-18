using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideRojoScript : MonoBehaviour {
    [SerializeField] AudioSource caidaAsteroide;
    [SerializeField] ParticleSystem prefabLlamas;
    [SerializeField] ParticleSystem prefabExplosion;
    [SerializeField] int danyoAsteroide = 20;


    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem ps = Instantiate(prefabExplosion,this.transform.position , Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(prefabLlamas, new Vector3(this.transform.position.x, collision.transform.position.y, this.transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyoAsteroide);
            ParticleSystem[] particulas = collision.gameObject.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particula in particulas)
            {
                if (particula.gameObject.name.Equals("Arder"))
                {
                    particula.Play();
                }
            }
        }
        Destroy(this.gameObject);
    }
}
