using DefaultNamespace;
using DefaultNamespace.States;
using StateConfigs;
using UnityEngine;
using UnityEngine.AI;

namespace States
{
    public class MoveHomeState : IState
    {
        private readonly IStateSwitcher iStateSwitcher;
        private NavMeshAgent _agent;
        private readonly StateMachineData Data;


        public MoveHomeState(IStateSwitcher stateSwitcher, StateMachineData data)
        {
            _agent = data.Agent;
            iStateSwitcher = stateSwitcher;
            Data = data;
        }


        public void Enter()
        {
            //_agent.isStopped = false;
            _agent.SetDestination(Data.Home.position);
            Debug.Log("Иду спать");
        }

        public void Exit()
        {
            //_agent.isStopped = true;
            Debug.Log("Я дошёл");
        }

        public void Update()
        {
            if (_agent.remainingDistance < 0.5) iStateSwitcher.SwitchState<RestState>();
        }
    }
}