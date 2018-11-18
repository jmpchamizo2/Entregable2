using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboteadorScript : MonoBehaviour {
    [SerializeField] int constanteElastica = 10;
    [SerializeField] Transform player;
    private float alturaInicial;


    private void Start()
    {
        alturaInicial = this.transform.position.y;
    }

    void FixedUpdate()
    {
        Rebote();
    }

    private void Rebote()
    {
        float desviacionSobreAlturaInicial = alturaInicial - this.transform.position.y;
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * constanteElastica * desviacionSobreAlturaInicial);
    }
}
