using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class AlterPropertiesScript : MonoBehaviour
{
    #region Variáveis
    private GameObject _inspectorTab;

    private List<GameObject> _properties = new List<GameObject>();

    //Player
    private GameObject _playerProperties;
    private Slider _playerSpeedSlider;
    private Slider _playerStrengthSlider;
    private Slider _playerHealthSlider;

    //Enemy
    private GameObject _enemyProperties;
    private Slider _enemyStrengthSlider;
    private Slider _enemyHealthSlider;
    //private Toggle _enemyIsChasingButton;

    //Obstacle
    private GameObject _obstacleProperties;
    #endregion

    #region Funções Unity
    private void Awake()
    {
        _inspectorTab = GameObject.FindGameObjectWithTag("InspectorTab");
        _inspectorTab.SetActive(false);

        _playerProperties = GameObject.FindGameObjectWithTag("PlayerProperties");
        _playerProperties.SetActive(false);
        _properties.Add(_playerProperties);

        _enemyProperties = GameObject.FindGameObjectWithTag("EnemyProperties");
        _enemyProperties.SetActive(false);
        _properties.Add(_enemyProperties);

        _obstacleProperties = GameObject.FindGameObjectWithTag("ObstacleProperties");
        _obstacleProperties.SetActive(false);
        _properties.Add(_obstacleProperties);

        SetAllPropertiesActive(false);

        //PLAYER
        #region Propriedades Player
        _playerSpeedSlider = _playerProperties?.transform.Find("SpeedSlider")?.GetComponent<Slider>();
        _playerStrengthSlider = _playerProperties?.transform.Find("StrengthSlider")?.GetComponent<Slider>();
        _playerHealthSlider = _playerProperties?.transform.Find("HealthSlider")?.GetComponent<Slider>();

        if (_playerSpeedSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'SpeedSlider' dentro de PlayerProperties.");
            return;
        }
        if (_playerStrengthSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'StrengthSlider' dentro de PlayerProperties.");
            return;
        }
        if (_playerStrengthSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'HealthSlider' dentro de PlayerProperties.");
            return;
        }

        _playerSpeedSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerStrengthSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerHealthSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        #endregion

        //INIMIGO
        #region Propriedades Inimigo
        _enemyStrengthSlider = _enemyProperties?.transform.Find("StrengthSlider")?.GetComponent<Slider>();
        _enemyHealthSlider = _enemyProperties?.transform.Find("HealthSlider")?.GetComponent<Slider>();
        //_enemyIsChasingButton = _enemyProperties?.transform.Find("IsChasingButton")?.GetComponent<Toggle>();

        if (_enemyStrengthSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'StrengthSlider' dentro de EnemyProperties.");
            return;
        }
        if (_enemyHealthSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'HealthSlider' dentro de EnemyProperties.");
            return;
        }
        /*if (_enemyIsChasingButton == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'IsChasingButton' dentro de EnemyProperties.");
            return;
        }*/

        _enemyStrengthSlider.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        _enemyHealthSlider.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        //_enemyIsChasingButton.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        #endregion
        //OBSTÁCULO
        #region Propriedades Obstáculos
        #endregion
        //CHÃO
        #region Propriedades Chão
        #endregion
    }
    #endregion

    #region Funções Próprias
    private void SetAllPropertiesActive(bool isActive)
    {
        foreach (var property in _properties)
        {
            property.SetActive(isActive);
        }
    }

    private void OpenProperty(GameObject property)
    {
        SetAllPropertiesActive(false);

        _inspectorTab.SetActive(true);
        property.SetActive(true);
    }
    public void OpenPlayerProperties()
    {
        OpenProperty(_playerProperties);
    }

    public void OpenEnemyProperties()
    {
        OpenProperty(_enemyProperties);
    }

    public void OpenObstacleProperties()
    {
        OpenProperty(_obstacleProperties);
    }

    private void UpdatePlayerAttributes()
    {
        float newSpeed = _playerSpeedSlider.value;
        float newStrength = _playerStrengthSlider.value;
        float newHealth = _playerHealthSlider.value;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.playerSpeed = newSpeed;
                playerMovement.playerStrength = newStrength;
                //playerMovement.playerHealth = newHealth;
            }
            else
            {
                Debug.LogError("Erro: Componente PlayerMovement não encontrado no objeto Player.");
            }
        }
        else
        {
            Debug.LogError("Erro: Objeto Player não encontrado.");
        }
    }

    private void UpdateEnemyAttributes()
    {
        float newStrength = _enemyStrengthSlider.value;
        float newHealth = _enemyHealthSlider.value;
        //float newIsChasing = _enemyIsChasingButton.value;

        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            if (enemyBehaviour != null)
            {
                enemyBehaviour.enemyStrength = newStrength;
                enemyBehaviour.enemyHealth = newHealth;
            }
            else
            {
                Debug.LogError("Erro: Componente EnemyBehaviour não encontrado no objeto Player.");
            }
        }
        else
        {
            Debug.LogError("Erro: Objeto Enemy não encontrado.");
        }
    }
    #endregion
}
