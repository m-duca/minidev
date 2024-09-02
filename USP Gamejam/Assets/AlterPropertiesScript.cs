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

        _playerSpeedSlider = _playerProperties?.transform.Find("SpeedSlider")?.GetComponent<Slider>();

        if (_playerSpeedSlider == null)
        {
            Debug.LogError("Erro: Não foi possível encontrar o Slider 'VelocidadeSlider' dentro de PlayerProperties.");
            return;
        }
        //_pInputFieldX = _playerProperties.transform.Find("InputField_X").GetComponent<TMP_InputField>();
        //_pInputFieldY = _playerProperties.transform.Find("InputField_Y").GetComponent<TMP_InputField>();
        //_pInputFieldZ = _playerProperties.transform.Find("InputField_Z").GetComponent<TMP_InputField>();

        // Adicionar listeners para detectar mudanças nos valores
        //_pInputFieldX.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
        //_pInputFieldY.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
        //_pInputFieldZ.onEndEdit.AddListener(delegate { UpdatePlayerPosition(); });
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
        float SafeParseInput(string input)
        {
            input = input.Trim(); // Remove espaços em branco
            if (float.TryParse(input, out float result))
            {
                return result; // Retorna o valor convertido
            }

            Debug.LogWarning($"Entrada inválida: '{input}'. Definindo como 0.");
            return 0f; // Retorna 0 para entradas inválidas ou vazias
        }

        // Usar SafeParseInput para converter os valores dos campos
        float x = SafeParseInput(_pInputFieldX.text);
        float y = SafeParseInput(_pInputFieldY.text);
        float z = SafeParseInput(_pInputFieldZ.text);

        // Atualizar a posição do jogador
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }
    #endregion
}
