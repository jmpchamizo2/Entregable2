using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
    [SerializeField] GameObject follow;
    Vector3 posicionAnterior;
	void Start () {
        posicionAnterior = follow.transform.position;		
	}
	

	void Update () {
        FollowGameObject();
        AlmacenarPosicionAnterior();
	}


    private void FollowGameObject()
    {
        this.transform.position += follow.transform.position - posicionAnterior;
    }
    private void AlmacenarPosicionAnterior()
    {
        posicionAnterior = follow.transform.position;
    }
}
