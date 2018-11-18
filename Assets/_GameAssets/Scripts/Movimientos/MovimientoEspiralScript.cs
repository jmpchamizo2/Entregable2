using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEspiralScript : Movimiento {
    [SerializeField] float velocidadDelta;
    [SerializeField] float radioEspiral;
    private float delta;
    private float variacionRadioEspiral;

    private void Awake()
    {
        variacionRadioEspiral = radioEspiral;
    }



    void FixedUpdate () {
        this.transform.position = new Vector3(this.transform.position.x, yPosicionInicial + (variacionRadioEspiral + distancia) * Mathf.Cos(theta), zPosicionInicial + (variacionRadioEspiral + distancia) * Mathf.Sin(theta));
    }

    protected override void Update()
    {
        base.Update();
        CambiarRadioEspiral();
    }

    void CambiarRadioEspiral()
    {
        
        delta = (theta < 360) ? delta + velocidadDelta / factorCorreccionVelocidad : 0;
        variacionRadioEspiral = radioEspiral * Mathf.Sin(delta);
    }
}
