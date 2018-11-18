using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCircularScript : Movimiento
{

    void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x, yPosicionInicial + distancia * Mathf.Cos(theta), zPosicionInicial + distancia * Mathf.Sin(theta));   
	}
}
