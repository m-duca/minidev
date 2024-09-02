using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler
{
    private static Canvas _windowCanvas;
    private RectTransform _rectTransform;

    // Limites da �rea onde o RectTransform pode se mover (em unidades de tela).
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
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calcula a nova posi��o
        Vector2 newPosition = _rectTransform.anchoredPosition + eventData.delta / _windowCanvas.scaleFactor;

        // Ajusta a posi��o para ficar dentro dos limites
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        // Aplica a posi��o ajustada
        _rectTransform.anchoredPosition = newPosition;
    }
}
