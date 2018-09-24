using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    [SerializeField]
    private CaixaDeSom audio;

    public void AudioPasso()
    {
        audio.Tocar();
    }

    public void RotacaoJogador()
    {
        if (this.Direcao != Vector3.zero)
        {
            Vector3 posicaoMiraJogador = this.Direcao;
            posicaoMiraJogador.y = transform.position.y;
            Rotacionar(posicaoMiraJogador);
        }
    }
}
