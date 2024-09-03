using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;

    public void Reset()
    {
        if (!gameObject.name.Contains("Clone"))
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
