using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorGeneracionScript : MonoBehaviour {
    [SerializeField] int distanciaActivacion = 20;
    [SerializeField] Transform player;
    [SerializeField] GameObject prefabGenerador;
    float puntoMedioActivazion;
    bool instanciado = false;
    GameObject generador;

    private void Start()
    {
        puntoMedioActivazion = this.transform.position.z;
    }

    void Update () {
        SeguirPlayer();
    }

    private void SeguirPlayer()
    {

        if (generador != null && (player.transform.position.z + distanciaActivacion < puntoMedioActivazion || player.transform.position.z > puntoMedioActivazion + distanciaActivacion))
        {
            Destroy(generador.gameObject);
            instanciado = false;
        }
        else if(!instanciado && player.transform.position.z + distanciaActivacion >= puntoMedioActivazion && player.transform.position.z <= puntoMedioActivazion + distanciaActivacion)
        {  
            generador = Instantiate(prefabGenerador, this.transform);
            instanciado = true;
        }
        if (instanciado)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, player.transform.position.z);
        }
        
    }
}
