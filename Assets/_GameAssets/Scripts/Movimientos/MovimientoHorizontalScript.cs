using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontalScript : Movimiento {

    void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x, yPosicionInicial, zPosicionInicial + distancia * Mathf.Sin(theta));

    }
}
