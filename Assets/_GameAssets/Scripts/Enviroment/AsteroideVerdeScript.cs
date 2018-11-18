using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideVerdeScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
