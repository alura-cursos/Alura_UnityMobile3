using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CaixaDeSom : MonoBehaviour {
    [SerializeField]
    private AudioClip[] listaDeAudio;
    private AudioSource saidaDeAudio;

    private void Awake()
    {
        this.saidaDeAudio = this.GetComponent<AudioSource>();
    }

    public void Tocar()
    {
        var sorteado = Random.Range(0, this.listaDeAudio.Length);
        this.saidaDeAudio.PlayOneShot(this.listaDeAudio[sorteado]);
    }
}
