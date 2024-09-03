using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler
{
    // Referências:
    private static Canvas _windowCanvas;

    // Componentes: 
    private RectTransform _rectTransform;
    private Rigidbody2D _rb;

    // Limites da área onde o RectTransform pode se mover (em unidades de tela).
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Awake()
    {
        if (_windowCanvas == null)
            _windowCanvas = GameObject.FindGameObjectWithTag("Window Canvas").GetComponent<Canvas>();
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (gameObject.GetComponent<Rigidbody2D>() != null)
            _rb = GetComponent<Rigidbody2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        TabManager.Instance.IsDragging = true;

        if (_rb != null)
            _rb.isKinematic = false;

        // Calcula a nova posição
        Vector2 newPosition = _rectTransform.anchoredPosition + eventData.delta / _windowCanvas.scaleFactor;

        // Ajusta a posição para ficar dentro dos limites
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        // Aplica a posição ajustada
        _rectTransform.anchoredPosition = newPosition;

        TabManager.Instance.IsDragging = false;
    }
}
