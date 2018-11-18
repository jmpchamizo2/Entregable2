using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEstatico : Enemigo {
    [SerializeField] float distanciaAtaque = 5;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform posGeneracion;
    [SerializeField] int potenciaDisparo = 1000;
    [SerializeField] float tiempoEntreDisparos = 2;
    RotarCanyon rotacion = new RotarCanyon();

    float tiempoAtaque;
    protected GameObject player;


    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start() {
        tiempoAtaque = tiempoEntreDisparos;
    }


    protected virtual void Update()
    {
        if (distanciaDeteccion > GetDistancia().magnitude)
        {
            BuscarPlayer();
        }

    }


    private void IntentoAtaque() {
        tiempoAtaque += Time.deltaTime;
        if (tiempoAtaque >= tiempoEntreDisparos) {
            tiempoAtaque = 0;
            Disparar();
        }
    }

    private void Disparar() {
        GameObject proyectil = Instantiate(
            prefabProyectil,
            posGeneracion.position, 
            posGeneracion.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(
            Vector3.forward * potenciaDisparo);
    }

	

    private void BuscarPlayer()
    {
        if (GetDistancia().magnitude < distanciaAtaque)
        {
            IntentoAtaque();
        }
    }



    protected Vector3 GetDistancia()
    {
        return player.transform.position - this.transform.position;
    }
}
