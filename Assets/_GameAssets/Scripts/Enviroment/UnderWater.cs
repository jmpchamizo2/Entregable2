using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour {
    private Player player;
    [SerializeField] int danyoAhogo = 1;
    [SerializeField] AudioSource sonidoAgua;
    [SerializeField] float factorCorrecion = 0.9f;
    //[SerializeField] GameObject aguaInterna;
    float alturaTerreno;
    private int tiempoBajoAgua;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        alturaTerreno = player.GetComponent<Transform>().position.y;
        tiempoBajoAgua = 0;
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        AplicarFuerzaNormalAgua();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Water();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Normal();
        }
    }

    private void Water()
    {
        player.CambioEstadoEnAgua(estadoPlayer.nadando);
        RenderSettings.fog = true;
        InvokeRepeating("Ahogar", 5, 5);
        sonidoAgua.Play();
        //aguaInterna.GetComponent<MeshRenderer>().enabled = true;

       
    }

    private void Normal()
    {
        player.CambioEstadoEnAgua(estadoPlayer.volando);
        RenderSettings.fog = false;
        CancelInvoke("Ahogar");
        sonidoAgua.Stop();
        tiempoBajoAgua = 0;
        //aguaInterna.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Ahogar()
    {
        tiempoBajoAgua++;
        player.RecibirDanyo(danyoAhogo * tiempoBajoAgua);
    }


    private void AplicarFuerzaNormalAgua()
    {
        if (RenderSettings.fog)
        {
            float fuerzaNormalAgua = (alturaTerreno - player.transform.position.y) * factorCorrecion;
            player.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, fuerzaNormalAgua, 0));
        }
    }
}

