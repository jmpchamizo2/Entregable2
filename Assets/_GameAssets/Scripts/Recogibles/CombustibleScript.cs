using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustibleScript : MonoBehaviour {

    [SerializeField] int cantidadCombustible = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            other.GetComponent<Player>().IncrementarCombustible(cantidadCombustible);
            Destroy(this.gameObject);
        }
    }
}
