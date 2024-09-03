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
    private Slider _playerJumpForceSlider;

    //Enemy
    private GameObject _enemyProperties;
    private Slider _enemySpeedSlider;
    private Slider _enemyStrengthSlider;
    private Slider _enemyHealthSlider;
    private Toggle _enemyIsChasingToggle;

    //Obstacle
    private GameObject _obstacleProperties;
    private Slider _obstacleStrengthSlider;
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
        _playerJumpForceSlider = _playerProperties?.transform.Find("JumpForceSlider")?.GetComponent<Slider>();

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
        if (_playerJumpForceSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'JumpForceSlider' dentro de PlayerProperties.");
            return;
        }

        _playerSpeedSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerStrengthSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerHealthSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerJumpForceSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        #endregion

        //INIMIGO
        #region Propriedades Inimigo
        _enemySpeedSlider = _enemyProperties?.transform.Find("SpeedSlider")?.GetComponent<Slider>();
        _enemyStrengthSlider = _enemyProperties?.transform.Find("StrengthSlider")?.GetComponent<Slider>();
        _enemyHealthSlider = _enemyProperties?.transform.Find("HealthSlider")?.GetComponent<Slider>();
        _enemyIsChasingToggle = _enemyProperties?.transform.Find("IsChasingToggle")?.GetComponent<Toggle>();

        if (_enemySpeedSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'SpeedSlider' dentro de EnemyProperties.");
            return;
        }
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
        if (_enemyIsChasingToggle == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'IsChasingToggle' dentro de EnemyProperties.");
            return;
        }

        _enemySpeedSlider.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        _enemyStrengthSlider.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        _enemyHealthSlider.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        _enemyIsChasingToggle.onValueChanged.AddListener(delegate { UpdateEnemyAttributes(); });
        #endregion

        //OBSTÁCULO
        #region Propriedades Obstáculos
        _obstacleStrengthSlider = _obstacleProperties?.transform.Find("StrengthSlider")?.GetComponent<Slider>();

        if (_obstacleStrengthSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'StrengthSlider' dentro de ObstacleProperties.");
            return;
        }

        _obstacleStrengthSlider.onValueChanged.AddListener(delegate { UpdateObstacleAttributes(); });
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
        float newJumpForce = _playerJumpForceSlider.value;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerBehaviour playerMovement = player.GetComponent<PlayerBehaviour>();
            if (playerMovement != null)
            {
                playerMovement.playerSpeed = newSpeed;
                playerMovement.playerStrength = newStrength;
                playerMovement.playerHealth = newHealth;
                playerMovement.playerJumpForce = newJumpForce;
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
        float newSpeed = _enemySpeedSlider.value;
        float newStrength = _enemyStrengthSlider.value;
        float newHealth = _enemyHealthSlider.value;
        bool newIsChasing = _enemyIsChasingToggle.isOn;

        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            if (enemyBehaviour != null)
            {
                enemyBehaviour.enemySpeed = newSpeed;
                enemyBehaviour.enemyStrength = newStrength;
                enemyBehaviour.enemyHealth = newHealth;
                enemyBehaviour.enemyIsChasing = newIsChasing;
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

    private void UpdateObstacleAttributes()
    {
        float newStrength = _obstacleStrengthSlider.value;

        GameObject obstacle = GameObject.FindWithTag("Obstacle");
        if (obstacle != null)
        {
            ObstacleBehaviour obstacleBehaviour = obstacle.GetComponent<ObstacleBehaviour>();
            if (obstacleBehaviour != null)
            {
                obstacleBehaviour.obstacleStrength = newStrength;
            }
            else
            {
                Debug.LogError("Erro: Componente ObstacleBehaviour não encontrado no objeto Obstacle.");
            }
        }
        else
        {
            Debug.LogError("Erro: Objeto Obstacle não encontrado.");
        }
    }
    #endregion
}
