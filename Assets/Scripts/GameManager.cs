using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubscriber
{
    private readonly IList<string> _subscribedEvents = new List<string>
    {
        
    };

    private List<GameObject> _activeWindows;

    private enum GameState
    {
        Start,
        WorldGeneration,
        HistoryGeneration,
        PlayerTurn,
        EndTurn,
        PlayerDeath
    }

    private GameState _currentState;

    private bool _playerDead;

    //todo player object reference

    public int TurnNumber { get; set; }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        _currentState = GameState.Start;

        _activeWindows = new List<GameObject>();

        SubscribeToEvents();

        TurnNumber = 0;
    }

    private void Update()
    {
        if (_playerDead)
        {
            _playerDead = false;
            _currentState = GameState.PlayerDeath;
            RunPlayerDeathRoutine();
        }

        //Debug.Log(_currentState);
        switch (_currentState)
        {
            case GameState.Start:
                _currentState = GameState.WorldGeneration;
                break;
            case GameState.WorldGeneration:
                break;
            case GameState.HistoryGeneration:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EndTurn:
                break;
            case GameState.PlayerDeath:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void AddActiveWindow(GameObject window)
    {
        if (_activeWindows.Contains(window))
        {
            return;
        }
        _activeWindows.Add(window);
    }

    public void RemoveActiveWindow(GameObject window)
    {
        if (!_activeWindows.Contains(window))
        {
            return;
        }
        _activeWindows.Remove(window);
    }

    public List<GameObject> GetActiveWindows()
    {
        return _activeWindows;
    }

    public bool AnyActiveWindows()
    {
        return _activeWindows.Any();
    }

    public void OnNotify(string eventName, object broadcaster, object parameter = null)
    {
        throw new System.NotImplementedException();
    }

    private void RunPlayerDeathRoutine()
    {
        throw new System.NotImplementedException();
    }

    private void SubscribeToEvents()
    {
        foreach (var eventName in _subscribedEvents)
        {
            EventMediator.Instance.SubscribeToEvent(eventName, this);
        }
    }

    private void UnsubscribeFromEvents()
    {
        EventMediator.Instance.UnsubscribeFromAllEvents(this);
    }
}
