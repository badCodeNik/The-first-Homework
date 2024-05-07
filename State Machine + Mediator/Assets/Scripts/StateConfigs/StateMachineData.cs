using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Data/StateMachineData", fileName = "StateMachineData")]
public class StateMachineData : ScriptableObject
{
    public NavMeshAgent Agent;
    public Transform Factory;
    public Transform Home;
    public float WorkDuration;
    public float RestDuration;
}