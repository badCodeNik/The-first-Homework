using StateConfigs;
using States;
using UnityEngine;

namespace DefaultNamespace.States
{
    public class RestState : IState
    {
        private readonly IStateSwitcher _iStateSwitcher;
        private readonly StateMachineData _data;
        private float _restDuration;

        public RestState(IStateSwitcher stateSwitcher, StateMachineData data)
        {
            _restDuration = data.RestDuration;
            _iStateSwitcher = stateSwitcher;
            _data = data;
        }

        private bool _alarmRang;

        public void Enter()
        {
            _restDuration = _data.RestDuration;
            Debug.Log("Вошёл в " + GetType());
            Debug.Log("Ложусь спать");
        }

        public void Exit()
        {
            Debug.Log("Поспал, можно и поработать");
        }

        public void Update()
        {
            _restDuration -= Time.deltaTime;
            if (_restDuration <= 0) _iStateSwitcher.SwitchState<MoveToWorkState>();
        }
    }
}