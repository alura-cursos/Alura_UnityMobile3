using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    private float tempoParaProximaGeracao = 0;
    public float tempoEntreGeracoes = 60;
    public ReservaFixa reservaDeChefes;
    private ControlaInterface scriptControlaInteface;
    public Transform[] PosicoesPossiveisDeGeracao;
    private Transform jogador;

    private void Start()
    {
        tempoParaProximaGeracao = tempoEntreGeracoes;
        scriptControlaInteface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
        jogador = GameObject.FindWithTag("Jogador").transform;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaProximaGeracao)
        {
            if (this.reservaDeChefes.TemObjeto())
            {
                Vector3 posicaoDeCriacao = CalcularPosicaoMaisDistanteDoJogador();
                var chefe = this.reservaDeChefes.PegarObjeto();
                var controleChefe = chefe.GetComponent<ControlaChefe>();
                controleChefe.SetPosicao(posicaoDeCriacao);
                scriptControlaInteface.AparecerTextoChefeCriado();
                tempoParaProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
            }
        }
    }

    Vector3 CalcularPosicaoMaisDistanteDoJogador()
    {
        Vector3 posicaoDeMaiorDistancia = Vector3.zero;
        float maiorDistancia = 0;

        foreach (Transform posicao in PosicoesPossiveisDeGeracao)
        {
            float distanciaEntreOJogador = Vector3.Distance(posicao.position, jogador.position);
            if (distanciaEntreOJogador > maiorDistancia)
            {
                maiorDistancia = distanciaEntreOJogador;
                posicaoDeMaiorDistancia = posicao.position;
            }
        }
        return posicaoDeMaiorDistancia;
    }
}
