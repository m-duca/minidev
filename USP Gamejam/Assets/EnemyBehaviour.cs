using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variáveis
    public int enemySpeed;
    public float enemyStrength;
    public float enemyHealth;
    public bool enemyIsChasing = false;

    // Referências:
    private static Transform _playerTransform;
    #endregion

    #region Funções Unity
    private void Start()
    {
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
    private void ChangeHealthPoints(float points = 0)
    {
        enemyHealth = Mathf.Clamp(enemyHealth + points, 0, enemyHealth);

        if (enemyHealth == 0)
            Destroy(gameObject);
    }

    private void ChasePlayer() 
    {
        var direction = (_playerTransform.position - gameObject.transform.position).normalized;

        transform.position += direction * enemySpeed * Time.deltaTime;
    }
    #endregion
}
