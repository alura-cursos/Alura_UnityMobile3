using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform imagemFundo;
    [SerializeField]
    private RectTransform imagemBolinha;
   

    public void OnDrag(PointerEventData dadosDoMouse)
    {
        var posicaoMouse = CalcularPosicaoMouse(dadosDoMouse);
        var posicaoLimitada = this.LimitarPosicao(posicaoMouse);
        this.PosicionarJoystick(posicaoLimitada);
        
    }

    private Vector2 LimitarPosicao(Vector2 posicaoMouse)
    {
        var posicaoLimitada = posicaoMouse;
        posicaoLimitada = posicaoLimitada.normalized * this.imagemFundo.rect.width/2 ;
        return posicaoLimitada;
    }

    private void PosicionarJoystick(Vector2 posicaoMouse)
    {
        this.imagemBolinha.localPosition = posicaoMouse;
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
