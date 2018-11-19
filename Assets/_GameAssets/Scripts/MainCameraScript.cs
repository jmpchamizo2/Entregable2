using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    [SerializeField] GameObject follow;
    Vector3 posicionAnterior;

    //float posicionInicialXAvatarVida = 59.87777f;
    //float posicionInicialYAvatarVida = 507.f;
    //float posicionInicialZAvatarVida = 11.44031f;
    //float anchoAvatarVida = 0.5f;



    void Start()
    {
        posicionAnterior = follow.transform.position;
        
    }


    void Update()
    {
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

