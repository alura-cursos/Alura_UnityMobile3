using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaFixa : MonoBehaviour {
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int quantidade;

    private Stack<GameObject> reserva;
	
	private void Awake () {
        this.reserva = new Stack<GameObject>();
        this.CriarTodosOsObjetos();
	}

    private void CriarTodosOsObjetos()
    {
       for(var i=0; i<this.quantidade; i++)
        {
            this.CriarNovoObjeto();
        }
    }

    private void CriarNovoObjeto()
    {
        var objeto = GameObject.Instantiate(this.prefab, this.transform);
        this.DevolverObjeto(objeto);
    }

    private void DevolverObjeto(GameObject objeto)
    {
        objeto.SetActive(false);
        this.reserva.Push(objeto);
    }
}
