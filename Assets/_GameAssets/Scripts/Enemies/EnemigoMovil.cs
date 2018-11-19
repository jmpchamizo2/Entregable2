using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estado { idle, andando, corriendo, volando, nadando, inmune, sinEstado }
public class EnemigoMovil : Enemigo {
    [Header("Enemigo Movil")]
    [SerializeField] protected int speed = 1;
    [SerializeField] protected int inicioRotacion = 1;
    [SerializeField] protected int tiempoEntreRotacion = 4;
    protected Estado estado;
    Animator animador;
    protected int rotacion = 1;


    protected virtual void Start()
    {
        InvokeRepeating("Rotar", inicioRotacion, tiempoEntreRotacion);
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
            if(rotacion > 0)
            {
                this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                this.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            estado = Estado.andando;
        }
    }

    protected void Rotar() {

        rotacion = -rotacion;
        this.transform.localScale = new Vector3(1, 1, rotacion);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Rotar();
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
