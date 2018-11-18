using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoListo : EnemigoMovil {

    protected GameObject player;
    bool estaInvocado = false;

    protected void Awake()
    {
        player = GameObject.Find("Player");
    }


    protected override void Update() 
    {
       
        if (GetDistancia().magnitude < distanciaDeteccion * distanciaDeteccion) {
            PararDeRotar(true);
            this.transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
        }
        else
        {
            PararDeRotar(false);
        }
        base.Update();
    }

    protected Vector3 GetDistancia()
    {
        return player.transform.position - transform.position;
    }

    protected void PararDeRotar(bool pararRotar)
    {
        if (!pararRotar && !estaInvocado)
        {
            InvokeRepeating("RotarAleatoriamente", inicioRotacion, tiempoEntreRotacion);
            estaInvocado = true;
        }
        else
        {
            CancelInvoke("RotarAleatoriamente");
            estaInvocado = false;
        }
    }
}
