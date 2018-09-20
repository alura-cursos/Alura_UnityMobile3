using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    [SerializeField]
    private AudioSource audio;

    public void AudioPasso()
    {
        audio.Play();
    }

    public void RotacaoJogador()
    {
        Vector3 posicaoMiraJogador = this.Direcao;
        posicaoMiraJogador.y = transform.position.y;
        Rotacionar(posicaoMiraJogador);
    }
}
