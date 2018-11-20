using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIntroScript : MonoBehaviour {
    [SerializeField] float velocidad = 100;
    [SerializeField] int velocidadRotacion = 10;
    float xPosFinal = -100 ;
    float xPosInicial = 150;
    float xPos;
    RectTransform r;



    void Update () {
        xPos = -1 * Time.deltaTime * velocidad;
        r = this.GetComponent<RectTransform>();
        //transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * velocidad);
        this.transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * velocidadRotacion);


        if (this.transform.position.x < xPosFinal)
        {
            xPos = xPosInicial;
        }
        transform.Translate(xPos, 0, 0);
    }
}
