using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler
{
    private static Canvas _windowCanvas;

    private RectTransform _rectTransform;

    private void Awake()
    {
        if (_windowCanvas == null)
            _windowCanvas = GameObject.FindGameObjectWithTag("Window Canvas").GetComponent<Canvas>();
    }

    private void Start() => _rectTransform = GetComponent<RectTransform>();
        
    void IDragHandler.OnDrag(PointerEventData eventData)  => _rectTransform.anchoredPosition += eventData.delta / _windowCanvas.scaleFactor;
}
