using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {
    [SerializeField]
    private ReservaFixa reserva;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi;
    private float distanciaDeGeracao = 3;
    private float DistanciaDoJogadorParaGeracao = 20;
    private GameObject jogador;

    private float tempoProximoAumentoDeDificuldade = 30;
    private float contadorDeAumentarDificuldade;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Jogador");
        contadorDeAumentarDificuldade = tempoProximoAumentoDeDificuldade;
    }

    // Update is called once per frame
    void Update () {

        bool possoGerarZumbisPelaDistancia = Vector3.Distance(transform.position,
            jogador.transform.position) >
            DistanciaDoJogadorParaGeracao;

        if(possoGerarZumbisPelaDistancia )
        {
            contadorTempo += Time.deltaTime;

            if (contadorTempo >= TempoGerarZumbi)
            {
                StartCoroutine(GerarNovoZumbi());
                contadorTempo = 0;
            }
        }   
        
        if(Time.timeSinceLevelLoad > contadorDeAumentarDificuldade)
        {
            
            contadorDeAumentarDificuldade = Time.timeSinceLevelLoad + 
                tempoProximoAumentoDeDificuldade;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeGeracao);
    }

    IEnumerator GerarNovoZumbi ()
    {
        Vector3 posicaoDeCriacao = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);

        while(colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);
            yield return null;
        }
        if (this.reserva.TemObjeto())
        {
            GameObject zumbi = this.reserva.PegarObjeto();
            zumbi.transform.position = posicaoDeCriacao;
            var controleZumbi = zumbi.GetComponent<ControlaInimigo>();
            controleZumbi.meuGerador = this;
            
        }
       
    }

    Vector3 AleatorizarPosicao ()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaDeGeracao;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
    
}
