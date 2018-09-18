using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidbody;
    private Vector3 direcao;
    void Awake ()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirecao(Vector2 direcao)
    {
        this.direcao = new Vector3(direcao.x, 0, direcao.y);
    }

    public void SetDirecao(Vector3 direcao)
    {
        this.direcao = direcao;
    }
    public void Movimentar (float velocidade)
    {
        meuRigidbody.MovePosition(
                meuRigidbody.position +
                direcao.normalized * velocidade * Time.deltaTime);
    }

    public void Rotacionar (Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        meuRigidbody.MoveRotation(novaRotacao);
    }

    public void Morrer ()
    {
        meuRigidbody.constraints = RigidbodyConstraints.None;
        meuRigidbody.velocity = Vector3.zero;
        meuRigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = false;
    }
}
