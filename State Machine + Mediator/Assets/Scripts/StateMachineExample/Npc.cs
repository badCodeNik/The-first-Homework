using StateConfigs;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Npc : MonoBehaviour
{
    [SerializeField] private StateMachineData data;
    [SerializeField] private Transform factory;
    [SerializeField] private Transform home;
    [SerializeField] private float restDuration;
    [SerializeField] private float workDuration;

    public StateMachineData Data => data;

    private NavMeshAgent _agent;
    private StateMachine _stateMachine;

    public NavMeshAgent Agent => _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine(_agent, factory, home, restDuration, workDuration);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}