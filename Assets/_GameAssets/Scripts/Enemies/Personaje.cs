using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Personaje : MonoBehaviour
{

    [Header("ESTADO")]
    [SerializeField] protected bool estaVivo = true;
    [SerializeField] protected int vidaActual = 10;
    

    [Header("ATAQUE")]
    //Daño que infringe
    [SerializeField] protected int danyo = 2;


    //[Header("FX")]
    //[SerializeField] protected AudioSource sonidosPersonaje;



    public virtual void RecibirDanyo(int danyo)
    {
        Debug.Log("RECIBIENDO DAÑO" + danyo);
        vidaActual = vidaActual - danyo;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Morir();
        }

    }

    public virtual void Morir()
    {
        estaVivo = false;

    }






}
