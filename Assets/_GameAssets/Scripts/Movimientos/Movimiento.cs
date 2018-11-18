using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    protected float theta;
    [SerializeField] protected float velocidad = 1;
    [SerializeField] protected float distancia = 1;
    protected int factorCorreccionVelocidad = 1000;
    protected float zPosicionInicial;
    protected float yPosicionInicial;


    protected void Start () {
        theta = 0;
        zPosicionInicial = this.transform.position.z;
        yPosicionInicial = this.transform.position.y;
    }

    protected virtual void Update()
    {
        AumentarTheta();
    }

    protected void AumentarTheta()
    {
        theta = (theta < 360) ? theta + velocidad/ factorCorreccionVelocidad : 0;
    }
}
