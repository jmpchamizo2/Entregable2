using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
    [SerializeField] GameObject follow;
    [SerializeField] GameObject prefabVida;
    Vector3 posicionAnterior;
    GameObject[] personajes;

    float posicionVidasX = -7.6f;
    float posicionVidasY = 2.56f;
    float posicionVidasZ = 20.2f;
    float aumentoEnX = 0.9f;
    

    void Start () {
        posicionAnterior = follow.transform.position;
        personajes = new GameObject[3];
        for (int i = 0; i < personajes.Length; i++) {
            personajes[i] = Instantiate(prefabVida, new Vector3(posicionVidasX + aumentoEnX * i, posicionVidasY, posicionVidasZ), Quaternion.identity, this.transform);
        }
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
