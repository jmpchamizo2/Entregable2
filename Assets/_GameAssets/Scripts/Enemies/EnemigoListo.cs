using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoMovil {

    protected GameObject player;
    bool estaInvocado = true;

    protected void Awake()
    {
        player = GameObject.Find("Player");
    }


    protected override void Update() 
    {       
        if (GetDistancia().magnitude <= distanciaDeteccion) {
            PararDeRotar(true);
            rotacion = (this.transform.position.z - player.transform.position.z > 0) ? -1 : 1;
            this.transform.localScale = new Vector3(1, 1, rotacion);
        }
        else
        {
            PararDeRotar(false);
        }
        base.Update();
    }

    protected Vector3 GetDistancia()
    {
        return player.transform.position - this.transform.position;
    }

    protected void PararDeRotar(bool pararRotar)
    {
        if (pararRotar && estaInvocado)
        {
            CancelInvoke("Rotar");
            estaInvocado = false;
        }
        else if(!estaInvocado)
        {
            InvokeRepeating("Rotar", inicioRotacion, tiempoEntreRotacion);
            estaInvocado = true;
        }
    }
}
