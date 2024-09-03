using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public float obstacleStrength;

    private Vector3 _initialPos;

    private bool _isFirst = false;
    private float _initialStrength;


    private void Awake()
    {
        _isFirst = true;
    }

    private void Start()
    {
        if (_isFirst) 
        {
            _initialPos = gameObject.transform.position;
            _initialStrength = obstacleStrength;
        }        
    }

    public void Reset()
    {
        if (_isFirst) 
        {
            gameObject.transform.position = _initialPos;
            obstacleStrength = _initialStrength;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
