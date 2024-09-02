using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlterPropertiesScript : MonoBehaviour
{
    #region Variáveis
    private GameObject _inspectorTab;

    //Player
    private GameObject _playerProperties;

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

        _enemyProperties = GameObject.FindGameObjectWithTag("EnemyProperties");
        _enemyProperties.SetActive(false);

        _obstacleProperties = GameObject.FindGameObjectWithTag("ObstacleProperties");
        _obstacleProperties.SetActive(false);

        _groundProperties = GameObject.FindGameObjectWithTag("GroundProperties");
        _groundProperties.SetActive(false);
    }
    #endregion

    #region Funções Próprias
    public void OpenPlayerProperties()
    {
        _inspectorTab.SetActive(true);
        _playerProperties.SetActive(true);
    }

    public void OpenEnemyProperties()
    {
        _inspectorTab.SetActive(true);
        _enemyProperties.SetActive(true);
    }

    public void OpenObstacleProperties()
    {
        _inspectorTab.SetActive(true);
        _obstacleProperties.SetActive(true);
    }

    public void OpenGroundProperties()
    {
        _inspectorTab.SetActive(true);
        _groundProperties.SetActive(true);
    }
    #endregion
}
