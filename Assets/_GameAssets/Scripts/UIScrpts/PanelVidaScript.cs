using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVidaScript : MonoBehaviour {
    GameObject[] personajes;
    [SerializeField] GameObject prefabVida;
    [SerializeField] Player player;    

    void Start() {
        personajes = new GameObject[3];
        for (int i = 0; i < personajes.Length; i++) {
            personajes[i] = Instantiate(prefabVida, this.transform);   
        }
        RestarVidas();
    }

    public void RestarVidas() {
        for (int i = player.getVidas(); i < personajes.Length; i++) {
            //personajes[i].color = new Color32(160, 160, 160, 128);
        }
    }
    public void SumarVidas() {
        for (int i = player.getVidas() - 1; i > 0; i--) {
           // personajes[i].color = new Color(255, 255, 255, 255);
        }
    }


}
