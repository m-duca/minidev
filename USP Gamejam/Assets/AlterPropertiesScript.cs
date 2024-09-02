using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class AlterPropertiesScript : MonoBehaviour
{
    #region Vari�veis
    private GameObject _inspectorTab;

    private List<GameObject> _properties = new List<GameObject>();

    //Player
    private GameObject _playerProperties;
    private Slider _playerSpeedSlider;
    private Slider _playerStrengthSlider;

    //Enemy
    private GameObject _enemyProperties;

    //Obstacle
    private GameObject _obstacleProperties;

    //Ground
    private GameObject _groundProperties;
    #endregion

    #region Fun��es Unity
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

        _groundProperties = GameObject.FindGameObjectWithTag("GroundProperties");
        _groundProperties.SetActive(false);
        _properties.Add(_groundProperties);

        SetAllPropertiesActive(false);

        //PLAYER
        #region Propriedades Player
        _playerSpeedSlider = _playerProperties?.transform.Find("SpeedSlider")?.GetComponent<Slider>();
        _playerSpeedSlider = _playerProperties?.transform.Find("StrengthSlider")?.GetComponent<Slider>();

        if (_playerSpeedSlider == null)
        {
            Debug.LogError("Erro: N�o foi poss�vel encontrar o Slider 'VelocidadeSlider' dentro de PlayerProperties.");
            return;
        }
        if (_playerStrengthSlider == null)
        {
            Debug.LogError("Erro: N�o foi poss�vel encontrar o Slider 'For�aSlider' dentro de PlayerProperties.");
            return;
        }

        _playerSpeedSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        _playerStrengthSlider.onValueChanged.AddListener(delegate { UpdatePlayerAttributes(); });
        #endregion

        //INIMIGO
        #region Propriedades Inimigo
        #endregion
        //OBST�CULO
        #region Propriedades Obst�culos
        #endregion
        //CH�O
        #region Propriedades Ch�o
        #endregion
    }
    #endregion

    #region Fun��es Pr�prias
    private void SetAllPropertiesActive(bool isActive)
    {
        foreach (var property in _properties)
        {
            property.SetActive(isActive);
        }
    }

    private void OpenProperty(GameObject property)
    {
        // Desativar todas as propriedades antes de ativar a desejada
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

    public void OpenGroundProperties()
    {
        OpenProperty(_groundProperties);
    }

    private void UpdatePlayerAttributes()
    {
        float newSpeed = _playerSpeedSlider.value;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.playerSpeed = newSpeed;
            }
            else
            {
                Debug.LogError("Erro: Componente PlayerMovement n�o encontrado no objeto Player.");
            }
        }
        else
        {
            Debug.LogError("Erro: Objeto Player n�o encontrado.");
        }
    }
    #endregion
}
