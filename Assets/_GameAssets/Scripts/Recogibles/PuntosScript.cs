using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            other.GetComponent<Player>().incrementarPuntuacion();
            Destroy(this.gameObject);
        }
    }
}
