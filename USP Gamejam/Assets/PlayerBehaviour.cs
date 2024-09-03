using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Variáveis Player")]
    public float playerStrength;
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpForce;
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

    private Vector3 _initialPos;

    private float _initialStrength;
    private float _initialHealth;
    private float _initialSpeed;
    private float _initialJumpForce;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialPos = gameObject.transform.position;
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
            _rb.AddForce(Vector3.up * playerJumpForce, ForceMode2D.Impulse);
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
        else if (collision.gameObject.CompareTag("Enemy")) 
        {
            ChangeHealthPoints(-collision.gameObject.GetComponent<EnemyBehaviour>().enemyStrength);
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            ChangeHealthPoints(-collision.gameObject.GetComponent<ObstacleBehaviour>().obstacleStrength);
        }
    }

    private void ChangeHealthPoints(float points = 0)
    {
        playerHealth = Mathf.Clamp(playerHealth + points, 0, playerHealth);

        if (playerHealth == 0)
            Destroy(gameObject);
    }

    public void Reset()
    {
        enabled = false;
        _rb.gravityScale = 0;

        gameObject.transform.position = _initialPos;
        playerStrength = _initialStrength;
        playerHealth = _initialHealth;
        playerSpeed = _initialSpeed;
        playerJumpForce = _initialJumpForce;

        isGrounded = false;
    }
}

