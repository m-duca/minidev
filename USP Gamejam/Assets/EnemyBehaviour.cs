using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Variáveis
    public int EnemySpeed;
    public int EnemyStrength;
    public int EnemyHealth;
    public bool EnemyIsChasing = false;

    // Referências:
    private static Transform _playerTransform;
    #endregion

    #region Funções Unity
    private void Start()
    {
        if (_playerTransform == null)
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (EnemyIsChasing) 
            ChasePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerScript))
            ChangeHealthPoints(-(int)playerScript.playerStrength);
    }
    #endregion

    #region Funções Próprias
    private void ChangeHealthPoints(int points = 0)
    {
        EnemyHealth = Mathf.Clamp(EnemyHealth + points, 0, EnemyHealth);

        if (EnemyHealth == 0)
            Destroy(gameObject);
    }

    private void ChasePlayer() 
    {
        var direction = (_playerTransform.position - gameObject.transform.position).normalized;

        transform.position += direction * EnemySpeed * Time.deltaTime;
    }
    #endregion
}
