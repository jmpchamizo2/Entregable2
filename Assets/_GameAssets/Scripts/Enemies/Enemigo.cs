using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : Personaje
{
    [Header("ATAQUE")]
    [SerializeField] protected int distanciaDeteccion = 20;

    //[Header("FX")]
    //[SerializeField] protected ParticleSystem psMuerte;
    //[SerializeField] protected ParticleSystem psHerido;
    //[SerializeField] protected Transform generacionSangre;
    //[SerializeField] protected AudioSource herido;
    //[SerializeField] protected AudioSource sonidoMuerte;


    public override void RecibirDanyo(int danyo)
    {
        base.RecibirDanyo(danyo);
        //ParticleSystem ps = Instantiate(psHerido, generacionSangre.position, Quaternion.identity);
        //herido.Play();
        //Destroy(ps.gameObject, 3);
    }

    public override void Morir()
    {
        //ParticleSystem ps = Instantiate(psMuerte, generacionSangre.position, Quaternion.identity);
        //AudioSource aSource = Instantiate(sonidoMuerte, generacionSangre.position, Quaternion.identity);
        //aSource.Play();
        //Destroy(aSource.gameObject, 3);
        //Destroy(ps.gameObject, 3);
        Destroy(this.gameObject);
    }


}
