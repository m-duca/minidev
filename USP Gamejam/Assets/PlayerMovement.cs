using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float playerStrength;

    void Update()
    {
        var cu = Input.GetAxisRaw("Horizontal");
        var boga = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.right * cu * playerSpeed * Time.deltaTime;
        transform.position += Vector3.up * boga * playerSpeed * Time.deltaTime;
    }
}
