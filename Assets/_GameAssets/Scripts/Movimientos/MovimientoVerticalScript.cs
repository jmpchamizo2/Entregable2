using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVerticalScript : Movimiento {

    void FixedUpdate () {
        this.transform.position = new Vector2(zPosicionInicial , yPosicionInicial + distancia * Mathf.Sin(theta));
	}

}
