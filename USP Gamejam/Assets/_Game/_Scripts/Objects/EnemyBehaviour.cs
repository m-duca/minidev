using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variáveis
    public float enemySpeed;
    public float enemyStrength;
    public float enemyHealth;
    public bool enemyIsChasing = false;

    private bool _isFirst = false;

    private Rigidbody2D _rb;

    // Referências:
    private static Transform _playerTransform;

    private Vector3 _initialPos;
    private float _initialSpeed;
    private float _initialStrength;
    private float _initialHealth;
    private bool _initialIsChasing;
    #endregion

    #region Funções Unity
    private void Awake()
    {
        _isFirst = true;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_isFirst) 
        {
            _initialPos = gameObject.transform.position;
            _initialSpeed = enemySpeed;
            _initialStrength = enemyStrength;
            _initialHealth = enemyHealth;
            _initialIsChasing = enemyIsChasing;
        }

        if (_playerTransform == null)
            _playerTransform = FindObjectOfType<PlayerBehaviour>().transform;
    }

    private void Update()
    {
        if (enemyIsChasing) 
            ChasePlayer();
    }

    /* Exemplo Usando o ChangeHealthPoints
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour playerScript))
            ChangeHealthPoints(-(int)playerScript.playerStrength);
    }
    */
    #endregion

    #region Funções Próprias
    public void ChangeHealthPoints(float points = 0)
    {
        enemyHealth = Mathf.Clamp(enemyHealth + points, 0, enemyHealth);

        if (enemyHealth == 0)
            Reset();
    }

    private void ChasePlayer() 
    {
        var direction = (_playerTransform.position - gameObject.transform.position).normalized;

        transform.position += Vector3.right * direction.x * enemySpeed * Time.deltaTime;
    }

    public void Reset()
    {
        if (_isFirst) 
        {
            enabled = false;
            _rb.gravityScale = 0;

            gameObject.transform.position = _initialPos;
            enemySpeed = _initialSpeed;
            enemyStrength = _initialStrength;
            enemyHealth = _initialHealth;
            enemyIsChasing = _initialIsChasing;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
