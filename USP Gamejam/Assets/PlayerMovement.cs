using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cu = Input.GetAxisRaw("Horizontal");

        transform.position += Vector3.right * cu * speed * Time.deltaTime;
    }
}
