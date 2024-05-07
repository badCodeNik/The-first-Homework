using DefaultNamespace;
using DefaultNamespace.States;
using StateConfigs;
using UnityEngine;
using UnityEngine.AI;

namespace States
{
    public class MoveState : IState
    {
        private readonly IStateSwitcher iStateSwitcher;
        private NavMeshAgent _agent;
        private readonly StateMachineData Data;


        public MoveState(IStateSwitcher stateSwitcher, StateMachineData data)
        {
            _agent = data.Agent;
            iStateSwitcher = stateSwitcher;
            Data = data;
        }

        private bool IsAtHome => Vector3.Distance(_agent.transform.position, Data.Home.position) < 0.1;

        private bool IsAtWork => Vector3.Distance(_agent.transform.position, Data.Factory.position) < 0.1;

        public void Enter()
        {
            if (IsAtHome)
            {
                _agent.Move(Data.Factory.position);
                Debug.Log("Иду работать");
            } 
            if (IsAtWork)
            {
                _agent.Move(Data.Home.position);
                Debug.Log("Иду спать");
            } 
        }

        public void Exit()
        {
            _agent.isStopped = true;
            Debug.Log("Я дошёл");
        }

        public void Update()
        {
           
            
            if (_agent.remainingDistance < 0.1 && IsAtHome) iStateSwitcher.SwitchState<RestState>();
            if (_agent.remainingDistance < 0.1 && IsAtWork) iStateSwitcher.SwitchState<WorkState>();
        }
    }
}