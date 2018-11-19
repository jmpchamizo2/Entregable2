using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum estadoPlayer { parado, andandoIzq, andandoDer, corriendoIzq,  corriendoDer, volando, nadando, inmune, sinEstado }

public class Player : MonoBehaviour
{
    float zPos;
    float ySpeedActual;
    estadoPlayer estado;
    Rigidbody rb;
    bool corriendo = false;
    Animator playerAnimator;
    bool mostrarVida = false;

    [Header ("Características")]
    [SerializeField] int velocidad;
    [SerializeField] int fuerzaSalto = 10;
    [SerializeField] GameObject posicionPies;
    [Header("Objetos")]
    [SerializeField] int cantidadCombustibleDeVuelo = 100;
    bool ignicion = false;
    float tiempoActivarTrigger = 1f;
    [Header("Salud")]
    [SerializeField] int salud = 100;
    private int saludMaxima = 100;
    [SerializeField] int vidas = 1;
    private int vidasMaximas = 3;
    [Header("FX")]
    [SerializeField] ParticleSystem explosionIgnicion;
    [SerializeField] AudioSource sonidoIgnicion;
    [SerializeField] ParticleSystem lanzallamas;
    [SerializeField] ParticleSystem laser;
    [Header("Armas")]
    [SerializeField] Transform disparoVolando;
    [SerializeField] Transform disparoTierra;
    [SerializeField] int energiaArmas = 100;
    private int energiaMaximaArmas = 100;
    private int puntuacion = 0;
    [Header("UI")]
    [SerializeField] Text puntuacionTxt;
    [SerializeField] Image frontalBarraVida;
    [SerializeField] CanvasGroup barraVida;



    private void Start()
    {

        estado = estadoPlayer.parado;
        rb = this.GetComponent<Rigidbody>();
        playerAnimator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        CorrerEstaApretado();
        IgnicionEstaApretado();
        Animar();
        Disparar();
    }


    private void FixedUpdate()
    {
        zPos = Input.GetAxis("Horizontal");
        ySpeedActual = rb.velocity.y;
        VolarSaltarCaminar();
        CambiarDireccion();
        if (mostrarVida)
        {
            MostrarBarraDeVida();
        }else
        {
            OcultarBarraDeVida();
        }
    }


    private void CorrerEstaApretado()
    {
        if(estado != estadoPlayer.volando || estado != estadoPlayer.nadando)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                velocidad *= 2;
                corriendo = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                velocidad /= 2;
                corriendo = false;
            }
        }
        
    }


    private void IgnicionEstaApretado()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estado == estadoPlayer.nadando)
            {
                if (cantidadCombustibleDeVuelo > 0)
                {
                    CambioEstadoEnAgua(estadoPlayer.volando);
                    Invoke("ActivarTrigger", tiempoActivarTrigger);
                    ignicion = true;
                }

            }
            else
            {
                CambioEstado(estadoPlayer.volando);
                Invoke("ActivarTrigger", tiempoActivarTrigger);
                ignicion = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ignicion = false;
        }
        
    }



    private void CambiarDireccion()
    {
        estadoPlayer estadoNuevo = estadoPlayer.sinEstado;
        if (zPos > 0.01f)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            if (this.estado != estadoPlayer.volando && EstaEnSuelo())
            {
                estadoNuevo = (corriendo) ? estadoPlayer.corriendoDer : estadoPlayer.andandoDer;
            }

        }
        if (zPos < -0.01f)
        {
            this.transform.localScale = new Vector3(1, 1, -1);
            if (this.estado != estadoPlayer.volando && EstaEnSuelo())
            {
                estadoNuevo = (corriendo) ? estadoPlayer.corriendoIzq : estadoPlayer.andandoIzq;
            }
        }
        if (zPos < 0.01f && zPos > -0.01f)
        {
            if (this.estado != estadoPlayer.volando && EstaEnSuelo())
            {
                estadoNuevo = estadoPlayer.parado;
            }
        }
        CambioEstado(estadoNuevo);
    }

    private void Animar()
    {
        playerAnimator.SetInteger("estadoPlayer", (int)estado);
    }


    private void VolarSaltarCaminar()
    {
        float velocidadY = ySpeedActual;
         
        if (estado == estadoPlayer.volando && EstaEnSuelo())
        {
            velocidadY = fuerzaSalto;
        }
        else if (ignicion && cantidadCombustibleDeVuelo > 0)
        {
            velocidadY = fuerzaSalto;
            explosionIgnicion.Play();
            sonidoIgnicion.Play();  
            cantidadCombustibleDeVuelo -= 1;
        }
        rb.velocity = new Vector3(0, velocidadY, zPos * velocidad);


    }


    private bool EstaEnSuelo()
    {
        bool enSuelo = false;
        float radio = 0.1f;
        Collider[] col = Physics.OverlapSphere(posicionPies.transform.position, radio);
        foreach (Collider c in col)
        {
            if (c != null && c.gameObject.tag.Equals("Suelo"))
            {
                    enSuelo = true;
            }
        }
        return enSuelo;

    }


    private void ActivarTrigger()
    {
        posicionPies.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other.tag.Equals("Suelo"))
        {
            posicionPies.GetComponent<BoxCollider>().enabled = false;
            CambioEstado(estadoPlayer.parado);
        }   
    }

    private void Disparar()
    {
        Transform posicionDisparo = null;
        ParticleSystem ps = null;
        int tiempoParaDesaparecer = 2;

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (estado == estadoPlayer.parado)
            {
                posicionDisparo = disparoVolando;
                ps = Instantiate(lanzallamas, posicionDisparo.transform);
            }
            else
            {
                posicionDisparo = disparoTierra;
                ps = Instantiate(laser, posicionDisparo.transform);
            }
            ps.Play();
            Destroy(ps.gameObject, tiempoParaDesaparecer);
        }
    }


    public void CambioEstadoEnAgua(estadoPlayer estado)
    {

        if(estado == estadoPlayer.nadando)
        {
            this.estado = estado;
            velocidad /= 2;
            fuerzaSalto /= 2;
        }
        if (this.estado == estadoPlayer.nadando)
        {
            if (estado == estadoPlayer.volando)
            {
                velocidad *= 2;
                fuerzaSalto *= 2;
                this.estado = estado;
                Invoke("ActivarTrigger", tiempoActivarTrigger);
            }
        }
       

        
    }

    private void CambioEstado(estadoPlayer estado)
    {
        if (this.estado != estadoPlayer.nadando && this.estado != estadoPlayer.inmune && estado != estadoPlayer.nadando && estado != estadoPlayer.inmune && estado != estadoPlayer.sinEstado)
        { 
            this.estado = estado;
        }
        
    }

    private void Inmunizar(float tiempo)
    {
        this.estado = estadoPlayer.inmune;
        Invoke("QuitarInmunidad", tiempo);
    }

    private void QuitarInmunidad()
    {
        this.estado = estadoPlayer.parado;
    }

    public void RecibirDanyo(int danyo)
    {
        salud -= danyo;
        if (salud < 0)
        {
            salud += saludMaxima;
            ModificarVida(false);
        }
        frontalBarraVida.fillAmount = (float)salud / 100;
        MostrarVida();
    }

    public void Sanar(int sanacion)
    {
        salud += sanacion;
        if(salud > saludMaxima)
        {
            salud -= saludMaxima;
            ModificarVida(true);
        }
        frontalBarraVida.fillAmount = (float)salud / 100;
        MostrarVida();
    }

    private void MostrarVida()
    {
        int tiempoMostrandoBarraVida = 4;
        CambiarMostrarVida();
        Invoke("CambiarMostrarVida", tiempoMostrandoBarraVida);
    }

    public void ModificarVida(bool aumentar)
    {
        CameraScript cs = FindObjectOfType<CameraScript>();
        if (aumentar)
        {
            Mathf.Min(++vidas, vidasMaximas);
            cs.SumarVida();
        }
        else
        {
            Mathf.Max(--vidas, 0);
            cs.RestarVida();
        }
        

        
    }

    public void IncrementarCombustible(int cantidadCombustible)
    {
        cantidadCombustibleDeVuelo += cantidadCombustible;
    }

    public void incrementarPuntuacion()
    {
        puntuacion++;
        puntuacionTxt.text = puntuacion.ToString();
    }

    public int getPuntuacion()
    {
        return puntuacion;
    }

    public int getVidasMaximas()
    {
        return vidasMaximas;
    }

    public int getVidas()
    {
        return vidas;
    }

    private void OcultarBarraDeVida()
    {
        float velocidadTransparente = 0.01f;
        if (barraVida.alpha > 0)
        {
            barraVida.alpha -= velocidadTransparente;
        }
        
    }

    private void MostrarBarraDeVida()
    {
        barraVida.alpha = 1;
    }

    private void CambiarMostrarVida()
    {
        mostrarVida = !mostrarVida;
    }
}
