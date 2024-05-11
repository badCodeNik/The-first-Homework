using DefaultNamespace;
using StateConfigs;
using UnityEngine;

namespace States
{
    public class WorkState : IState
    {
        private readonly IStateSwitcher _iStateSwitcher;
        private readonly StateMachineData _data;
        private float _workDuration;

        public WorkState(IStateSwitcher stateSwitcher, StateMachineData data)
        {
            _iStateSwitcher = stateSwitcher;
            _workDuration = data.WorkDuration;
            _data = data;
        }

        public void Enter()
        {
            _workDuration = _data.WorkDuration;
            Debug.Log("Опять работать?");
            
        }

        public void Exit()
        {
        }

        public void Update()
        {
            _workDuration -= Time.deltaTime;
            if (_workDuration <= 0)
            {
                _iStateSwitcher.SwitchState<MoveHomeState>();
            }
        }
    }
}