using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;

    public float obstacleStrength;

    private float _initialStrength;


    private void Start()
    {
        if (!gameObject.name.Contains("Clone")) 
        {
            _initialStrength = obstacleStrength;
        }        
    }

    public void Reset()
    {
        if (!gameObject.name.Contains("Clone")) 
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;
            obstacleStrength = _initialStrength;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
