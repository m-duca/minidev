using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    #region Variáveis
    [SerializeField] private Vector2 minPosition; 
    [SerializeField] private Vector2 maxPosition;
    #endregion

    #region Funções Unity
    private void Update()
    {
        Vector2 cursorPosition = Input.mousePosition;

        Debug.Log("Cursor: " + cursorPosition);

        // Verifica se o cursor está dentro da área definida
        if (IsCursorInBounds(cursorPosition))
        {
            // Se estiver dentro, mostra o cursor
            Cursor.visible = true;
        }
        else
            Cursor.visible = false;
    }
    #endregion

    #region Funções Própria
    private bool IsCursorInBounds(Vector2 position)
    {
        return position.x >= minPosition.x && position.x <= maxPosition.x &&
               position.y >= minPosition.y && position.y <= maxPosition.y;
    }
    #endregion
}