using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variáveis
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Rigidbody2D rb;

    public float enemySpeed;
    public float enemyStrength;
    public float enemyHealth;
    public bool enemyIsChasing = false;

    // Referências:
    private static Transform _playerTransform;

    private float _initialSpeed;
    private float _initialStrength;
    private float _initialHealth;
    private bool _initialIsChasing;
    #endregion

    #region Funções Unity
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!gameObject.name.Contains("Clone")) 
        {
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

        if (direction.x < 0f)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        
        transform.position += Vector3.right * direction.x * enemySpeed * Time.deltaTime;
    }

    public void Reset()
    {
        if (!gameObject.name.Contains("Clone")) 
        {
            enabled = false;
            rb.isKinematic = true;
            rb.gravityScale = 0f;

            gameObject.GetComponent<RectTransform>().anchoredPosition = initialPos;
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
