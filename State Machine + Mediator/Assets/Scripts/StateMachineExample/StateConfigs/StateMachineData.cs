using System;
using UnityEngine;
using UnityEngine.AI;

namespace StateConfigs
{
    [Serializable]
    public class StateMachineData
    {
        private NavMeshAgent _agent;
        private Transform _factory;
        private Transform _home;
        private float _restDuration;
        private float _workDuration;

        public NavMeshAgent Agent => _agent;

        public Transform Factory => _factory;

        public Transform Home => _home;

        public float RestDuration => _restDuration;

        public float WorkDuration => _workDuration;


        public StateMachineData(NavMeshAgent agent, Transform factory, Transform home, float restDuration,
            float workDuration)
        {
            _agent = agent;
            _factory = factory;
            _home = home;
            _restDuration = restDuration;
            _workDuration = workDuration;
        }
    }
}