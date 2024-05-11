using DefaultNamespace;
using StateConfigs;
using UnityEngine;
using UnityEngine.AI;

namespace States
{
    public class MoveToWorkState : IState
    {
        private readonly IStateSwitcher iStateSwitcher;
        private NavMeshAgent _agent;
        private readonly StateMachineData Data;


        public MoveToWorkState(IStateSwitcher stateSwitcher, StateMachineData data)
        {
            _agent = data.Agent;
            iStateSwitcher = stateSwitcher;
            Data = data;
        }
        public void Enter()
        {
            //_agent.isStopped = false;
            _agent.SetDestination(Data.Factory.position);
            Debug.Log("Иду работать");
        }

        public void Exit()
        {
            //_agent.isStopped = true;
            Debug.Log("Я дошёл");
        }

        public void Update()
        {
            
            if (_agent.remainingDistance < 0.5) iStateSwitcher.SwitchState<WorkState>();
        }
    }
}