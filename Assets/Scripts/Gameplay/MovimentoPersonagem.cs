using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidbody;
    public Vector3 Direcao { get; protected set; }
    void Awake ()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirecao(Vector2 direcao)
    {
        this.Direcao = new Vector3(direcao.x, 0, direcao.y);
    }

    public void SetDirecao(Vector3 direcao)
    {
        this.Direcao = direcao;
    }
    public void Movimentar (float velocidade)
    {
        meuRigidbody.MovePosition(
                meuRigidbody.position +
                Direcao * velocidade * Time.deltaTime);
    }

    public void Rotacionar (Vector3 direcao)
    {
        if(direcao != Vector3.zero)
        {
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            meuRigidbody.MoveRotation(novaRotacao);
        }
    }

    public void Morrer ()
    {
        meuRigidbody.constraints = RigidbodyConstraints.None;
        meuRigidbody.velocity = Vector3.zero;
        meuRigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;
    }
}
