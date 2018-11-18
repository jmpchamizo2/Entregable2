using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCanyon : MonoBehaviour {
    [SerializeField] Transform canyon;
    [SerializeField] float velocidadMovimiento = 2;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Rotar();
    }

    public void Rotar()
    {
        if (canyon.position.z - player.transform.position.z > 0)
        {
            if (canyon.transform.rotation.eulerAngles.y >= 0 && canyon.transform.rotation.eulerAngles.y < 180)
            {
                canyon.Rotate(Vector3.up * velocidadMovimiento * Time.deltaTime);
            }
        }
        else
        {
            if (canyon.transform.rotation.eulerAngles.y > 0 && canyon.transform.rotation.eulerAngles.y <= 180)
            {
                canyon.Rotate(Vector3.down * velocidadMovimiento * Time.deltaTime);
            }

        }

        ColocarAnguloZ();
    }

    private void ColocarAnguloZ()
    {
        if (canyon.transform.rotation.eulerAngles.y > 180 && canyon.transform.rotation.eulerAngles.y < 340)
        {
            canyon.transform.rotation = Quaternion.Euler(new Vector3(canyon.transform.rotation.eulerAngles.x, 180, canyon.transform.rotation.eulerAngles.z));
        }
        else if (canyon.transform.rotation.eulerAngles.y > 340 || canyon.transform.rotation.eulerAngles.y < 0)
        {
            canyon.transform.rotation = Quaternion.Euler(new Vector3(canyon.transform.rotation.eulerAngles.x, 0, canyon.transform.rotation.eulerAngles.z));
        }
    }
}
