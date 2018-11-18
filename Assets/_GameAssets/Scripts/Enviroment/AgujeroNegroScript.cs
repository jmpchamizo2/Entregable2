using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroNegroScript : MonoBehaviour {

    [SerializeField] int atraccion = 100;
    [SerializeField] float radioAccion = 5;
    private Vector3 vectorDistancia;
    private Player player;


	

    private void FixedUpdate()
    {
        AplicarFuerzaAtraccion();
    }



    private void AplicarFuerzaAtraccion()
    {
        Collider[] objetosAtraidos = Physics.OverlapSphere(this.transform.position, radioAccion);
        foreach(Collider objeto in objetosAtraidos)
        {
            if(objeto.GetComponent<Rigidbody>() != null)
            {
                vectorDistancia = this.transform.position - objeto.transform.position;
                objeto.GetComponent<Rigidbody>().AddRelativeForce((atraccion / vectorDistancia.sqrMagnitude) * (vectorDistancia.normalized));
            }     
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
