using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.States;
using StateConfigs;
using States;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public StateMachine(NavMeshAgent agent, Transform factory, Transform home, float restDuration, float workDuration)
    {
        StateMachineData data = new StateMachineData(agent, factory, home, restDuration, workDuration);
        _states = new List<IState>()
        {
            new MoveToWorkState(this, data),
            new RestState(this, data),
            new MoveHomeState(this, data),
            new WorkState(this, data)
            
        };
        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}