using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAsteroide : MonoBehaviour {
    [SerializeField] int velocidadRotacion = 250;

	void FixedUpdate () {
        this.transform.Rotate(new Vector3(1 ,1 ,1) * Time.deltaTime * velocidadRotacion);

	}
}
