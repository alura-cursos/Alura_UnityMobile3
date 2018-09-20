using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    private RectTransform imagemFundo;
    [SerializeField]
    private RectTransform imagemBolinha;

    [SerializeField]
    private MeuEventoDinamicoVector2 QuandoMudarOValor;

    public void OnDrag(PointerEventData dadosDoMouse)
    {
        var posicaoMouse = CalcularPosicaoMouse(dadosDoMouse);
        var posicaoLimitada = this.LimitarPosicao(posicaoMouse);
        this.PosicionarJoystick(posicaoLimitada);

        this.QuandoMudarOValor.Invoke(posicaoLimitada);
    }

    private Vector2 LimitarPosicao(Vector2 posicaoMouse)
    {
        var posicaoLimitada = posicaoMouse/this.TamanhoDaImagem();
        if(posicaoLimitada.magnitude > 1)
        {
            posicaoLimitada = posicaoLimitada.normalized;
        }
        return posicaoLimitada;
    }

    private float TamanhoDaImagem()
    {
        return this.imagemFundo.rect.width / 2;
    }

    private void PosicionarJoystick(Vector2 posicaoMouse)
    {
        this.imagemBolinha.localPosition = posicaoMouse * TamanhoDaImagem() ;
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

    public void OnPointerUp(PointerEventData eventData)
    {
        this.PosicionarJoystick(Vector2.zero);
        this.QuandoMudarOValor.Invoke(Vector2.zero);
    }

    public void OnPointerDown(PointerEventData dadosDoMouse)
    {
        this.OnDrag(dadosDoMouse);
    }
}
[Serializable]
public class MeuEventoDinamicoVector2 : UnityEvent<Vector2> { }