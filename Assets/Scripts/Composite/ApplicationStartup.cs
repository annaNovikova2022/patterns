using System;
using UnityEngine;
using UnityEngine.Serialization;

public static class GameEventSetting
{
    public static GameObject player;
        public static float moveDistance;
    
        public static GameObject mobParent;
        public static int numberOfMobs;
        
}

public class ApplicationStartup : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private Light _light;
    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _gameEvent;
    [SerializeField] public InputHandlerSetting inputHandlerSetting;
    [SerializeField] public MobEventSetting mobEventSetting;
    [Serializable] public struct InputHandlerSetting
    {
        public GameObject _player;
        public float _moveDistance;
    }
    [Serializable] public struct MobEventSetting
    {
        public GameObject _mobParent;
        public int _numberOfMobs;
    }
    

    public void InitGameEventSetting()
    {
        GameEventSetting.mobParent = Instantiate(mobEventSetting._mobParent);
        GameEventSetting.numberOfMobs = mobEventSetting._numberOfMobs;
        
        GameEventSetting.player = Instantiate(inputHandlerSetting._player);
        GameEventSetting.moveDistance = inputHandlerSetting._moveDistance;
    }

    public void Init()
    {
        InitGameEventSetting();
        
        Instantiate(_floor);
        Instantiate(_light);
        Instantiate(_eventSystem);
        Instantiate(_gameEvent);
    }

    private void Awake()
    {
        Init();
    }
}
