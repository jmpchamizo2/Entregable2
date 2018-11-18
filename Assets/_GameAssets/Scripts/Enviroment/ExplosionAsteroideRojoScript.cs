using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAsteroideRojoScript : MonoBehaviour
{
    [SerializeField] AudioSource sonidoExplosion;

    void Start()
    {
        Destroy(this.gameObject, 4);
    }
}
	

