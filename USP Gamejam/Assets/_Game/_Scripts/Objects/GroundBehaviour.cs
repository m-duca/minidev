using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    private Vector3 _initialPos;

    private bool _isFirst = false;

    private void Awake()
    {
        _isFirst = true;
    }

    private void Start()
    {
        if (_isFirst)
        {
            _initialPos = gameObject.transform.position;
        }
    }

    public void Reset()
    {
        if (_isFirst)
        {
            gameObject.transform.position = _initialPos;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
