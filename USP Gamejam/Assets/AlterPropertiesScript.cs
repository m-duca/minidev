using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlterPropertiesScript : MonoBehaviour
{
    #region Variáveis
    private GameObject _inspectorTab;

    private List<GameObject> _properties = new List<GameObject>();

    //Player
    private GameObject _playerProperties;
    private InputField _pInputFieldX;
    private InputField _pInputFieldY;
    private InputField _pInputFieldZ;

    //Enemy
    private GameObject _enemyProperties;

    //Obstacle
    private GameObject _obstacleProperties;

    //Ground
    private GameObject _groundProperties;
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

        _groundProperties = GameObject.FindGameObjectWithTag("GroundProperties");
        _groundProperties.SetActive(false);
        _properties.Add(_groundProperties);

        SetAllPropertiesActive(false);

        // Referenciar os InputFields para editar a posição do player
        _pInputFieldX = _playerProperties.transform.Find("InputField_X").GetComponent<InputField>();
        _pInputFieldY = _playerProperties.transform.Find("InputField_Y").GetComponent<InputField>();
        _pInputFieldZ = _playerProperties.transform.Find("InputField_Z").GetComponent<InputField>();

        // Adicionar listeners para detectar mudanças nos valores
        _pInputFieldX.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
        _pInputFieldY.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
        _pInputFieldZ.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
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

    private void UpdatePlayerPosition()
    {
        float x = float.Parse(_pInputFieldX.text);
        float y = float.Parse(_pInputFieldY.text);
        float z = float.Parse(_pInputFieldZ.text);

        // Atualizar a posição do jogador
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }
    #endregion
}
