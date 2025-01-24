using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public TankShooting tankShooting;
    [HideInInspector] public Transform[] wayPoints = { };
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float currentRotation;
    [HideInInspector] private float stateTimeElapsed;
    [HideInInspector] public float PreviousHealth;
    [SerializeField] private Transform _wayPointContainer;
    [HideInInspector] public IHealth healthComponent;

    private bool aiActive;

    void Awake()
    {
        tankShooting = GetComponent<TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<IHealth>();

        if (_wayPointContainer != null)
        {
            wayPoints = new Transform[_wayPointContainer.childCount];
            for (int i = 0; i < _wayPointContainer.childCount; i++)
                wayPoints[i] = _wayPointContainer.GetChild(i);
        }

        SetupAI(true, wayPoints);
    }

    public void SetupAI(bool aiActivationFromTankManager, Transform[] wayPointsFromTankManager)
    {
        wayPoints = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        if (!aiActive)
            return;
        stateTimeElapsed += Time.deltaTime;
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        currentState = nextState;
        OnExitState();
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        return stateTimeElapsed >= duration;
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
        currentRotation = 0f;
    }
}