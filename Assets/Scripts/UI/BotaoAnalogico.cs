using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoAnalogico : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Arrastando");
    }
}
