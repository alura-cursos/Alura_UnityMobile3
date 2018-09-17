using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform imagemFundo;

    public void OnDrag(PointerEventData dadosDoMouse)
    {
        var posicaoMouse = CalcularPosicaoMouse(dadosDoMouse);
        Debug.Log(posicaoMouse);
    }

    private Vector2 CalcularPosicaoMouse(PointerEventData dadosDoMouse)
    {
        Vector2 posicao;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imagemFundo,
            dadosDoMouse.position,
            dadosDoMouse.enterEventCamera,
            out posicao
            );

        return posicao;
    }
}
