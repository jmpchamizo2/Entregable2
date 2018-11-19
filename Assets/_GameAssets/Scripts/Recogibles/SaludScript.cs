using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludScript : MonoBehaviour {
    [SerializeField] int sanacion = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            other.GetComponent<Player>().Sanar(sanacion);
            Destroy(this.gameObject);
        }
    }
}
