using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Rigidbody2D rb;

    [Header("Variáveis Player")]
    public float playerStrength;
    public float playerHealth;
    public float playerSpeed;
    public float playerJumpForce;
    public bool isGrounded;

    //Componente
    private bool _isJumping;

    /*
    Player
    Velocidade
    Altura Pulo
    Vida
    Dano
    Escala (a se pensar)*/

    private float _initialStrength;
    private float _initialHealth;
    private float _initialSpeed;
    private float _initialJumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var X = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * X * playerSpeed;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            //_rb.velocity = new Vector2(_rb.velocity.x, 0f);
            //Faz o pulo
            _isJumping = true;
            rb.AddForce(Vector3.up * playerJumpForce, ForceMode2D.Impulse);
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

            if (_isJumping)
                _isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Enemy")) 
        {
            // Pulando no Inimigo
            if (_isJumping && gameObject.transform.position.y > collision.gameObject.transform.position.y) 
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().ChangeHealthPoints(-playerStrength);
            }
            else // Recebendo Dano do Inimigo
            {
                ChangeHealthPoints(-collision.gameObject.GetComponent<EnemyBehaviour>().enemyStrength);
            }
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
            Reset();
    }

    public void Reset()
    {
        enabled = false;
        rb.isKinematic = true;

        gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;
        playerStrength = _initialStrength;
        playerHealth = _initialHealth;
        playerSpeed = _initialSpeed;
        playerJumpForce = _initialJumpForce;

        isGrounded = false;
    }
}

