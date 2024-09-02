using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variáveis Player")]
    public int playerStrength;
    public int playerHealth;
    public float playerSpeed;
    public float jumpForce;
    public bool isGrounded;

    //Componente
    private Rigidbody2D _rb;

    /*
    Player
    Velocidade
    Altura Pulo
    Vida
    Dano
    Escala (a se pensar)*/

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var X = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * X * playerSpeed;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            //_rb.velocity = new Vector2(_rb.velocity.x, 0f);
            //Faz o pulo
            _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            //_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

            //Desativa o pulo depois que sai do chão
            isGrounded = false;
            

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
}

