using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var cu = Input.GetAxisRaw("Horizontal");
        var boga = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.right * cu * playerSpeed * Time.deltaTime;
        transform.position += Vector3.up * boga * playerSpeed * Time.deltaTime;
    }
}
