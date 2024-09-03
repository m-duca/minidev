using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    private PlayerBehaviour _playerBehaviour;
    private EnemyBehaviour _enemyBehaviour;

    private Rigidbody2D _Prb;
    private Rigidbody2D _Erb;

    void Start()
    {
        _playerBehaviour = player.GetComponent<PlayerBehaviour>();
        _enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
        _Prb = player.GetComponent<Rigidbody2D>();
        _Erb = enemy.GetComponent<Rigidbody2D>();
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerBehaviour.enabled = true;
            _Prb.gravityScale = 20;
            //_Prb.isKinematic = false;
        }

        if (collision.CompareTag("Enemy"))
        {
            _enemyBehaviour.enabled = true;
            _Erb.gravityScale = 20;
            //_Erb.isKinematic = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerBehaviour.enabled = false;
            _Prb.gravityScale = 0;
            //_Prb.isKinematic = true;
        }
        
        if (collision.CompareTag("Enemy"))
        {
            _enemyBehaviour.enabled = false;
            _Erb.gravityScale = 0;
            //_Erb.isKinematic = true;
        }
    }
}
