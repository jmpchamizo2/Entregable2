using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrienteDescendienteScript : MonoBehaviour {
    [SerializeField] int fuerza = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down * fuerza);
        }
        
    }
}
