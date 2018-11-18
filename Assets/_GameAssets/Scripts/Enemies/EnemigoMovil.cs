using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estado { idle, andando, corriendo, volando, nadando, inmune, sinEstado }
public class EnemigoMovil : Enemigo {
    [Header("Enemigo Movil")]
    [SerializeField] protected int speed = 1;
    [SerializeField] protected int inicioRotacion = 1;
    [SerializeField] protected int tiempoEntreRotacion = 2;
    protected Estado estado;
    Animator animador;


    protected virtual void Start()
    {
        InvokeRepeating("RotarAleatoriamente", inicioRotacion, tiempoEntreRotacion);
        animador = this.GetComponent<Animator>();
        estado = Estado.idle;
    }

    protected virtual void Update()
    {
        Avanzar();
        Animar();
    }

    protected void Avanzar() {
        if (estaVivo)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            estado = Estado.andando;
        }
    }

    protected void RotarAleatoriamente() {
        float rotacion = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, rotacion, 0);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        RotarAleatoriamente();
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
            Morir();
        }
    }

    private void Animar()
    {
        animador.SetInteger("estadoPersonaje", (int)estado);
    }


}
