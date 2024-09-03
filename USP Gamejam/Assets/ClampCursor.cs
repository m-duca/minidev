using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    #region Vari�veis
    [SerializeField] private Vector2 minPosition; 
    [SerializeField] private Vector2 maxPosition;
    #endregion

    #region Fun��es Unity
    private void Update()
    {
        Vector2 cursorPosition = Input.mousePosition;

        Debug.Log("Cursor: " + cursorPosition);

        // Verifica se o cursor est� dentro da �rea definida
        if (IsCursorInBounds(cursorPosition))
        {
            // Se estiver dentro, mostra o cursor
            Cursor.visible = true;
        }
        else
            Cursor.visible = false;
    }
    #endregion

    #region Fun��es Pr�pria
    private bool IsCursorInBounds(Vector2 position)
    {
        return position.x >= minPosition.x && position.x <= maxPosition.x &&
               position.y >= minPosition.y && position.y <= maxPosition.y;
    }
    #endregion
}