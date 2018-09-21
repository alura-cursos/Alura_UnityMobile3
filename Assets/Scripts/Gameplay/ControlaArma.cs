using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{

    public ReservaFixa reservaDeBalas;
    public GameObject CanoDaArma;
    public AudioClip SomDoTiro;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.Atirar();
            ControlaAudio.instancia.PlayOneShot(SomDoTiro);
        }
    }

    private void Atirar()
    {
        if (this.reservaDeBalas.TemObjeto())
        {
            var bala = this.reservaDeBalas.PegarObjeto();
            bala.transform.position = CanoDaArma.transform.position;
            bala.transform.rotation = CanoDaArma.transform.rotation;
        }
    }
}
