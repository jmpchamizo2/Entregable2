using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoElipticoScript : Movimiento
{
    [SerializeField] int altura = 3;

	void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x, yPosicionInicial + altura * Mathf.Cos(theta), zPosicionInicial + distancia * Mathf.Sin(theta));
    }
}
