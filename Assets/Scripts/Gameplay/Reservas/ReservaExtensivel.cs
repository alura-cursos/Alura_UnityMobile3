using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaExtensivel : MonoBehaviour, IReservaDeObjetos
{

    [SerializeField]
    private GameObject prefab;

    private Stack<GameObject> reserva;

    private void Awake()
    {
        this.reserva = new Stack<GameObject>();
    }

    private void CriarNovoObjeto()
    {
        var objeto = GameObject.Instantiate(this.prefab, this.transform);
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.SetReserva(this);
        this.DevolverObjeto(objeto);
    }

    public void DevolverObjeto(GameObject objeto)
    {
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoEntrarNaReserva();
        this.reserva.Push(objeto);
    }

    public GameObject PegarObjeto()
    {
        if(this.reserva.Count <= 0)
        {
            this.CriarNovoObjeto();
        }

        var objeto = this.reserva.Pop();
        var objetoReservavel = objeto.GetComponent<IReservavel>();
        objetoReservavel.AoSairDaReserva();
        return objeto;
    }

    public bool TemObjeto()
    {
        return true;
    }
}
