using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void RotacaoJogador()
    {
        Vector3 posicaoMiraJogador = this.Direcao;
        posicaoMiraJogador.y = transform.position.y;
        Rotacionar(posicaoMiraJogador);
    }
}
