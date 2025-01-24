using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunAwayAction")]
public class RunAwayAction : Action
{
    [SerializeField] public float runAwayDistance = 10f;

    public override void Act(StateController controller)
    {
        RunAway(controller);
    }

    private void RunAway(StateController controller)
    {
        if (!controller.chaseTarget)
        {
            controller.chaseTarget = GameObject.FindWithTag("Player").transform;
        }

        Vector3 directionAway = (controller.transform.position - controller.chaseTarget.position).normalized;
        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        Vector3 newDestination =
            controller.transform.position + (directionAway + randomOffset).normalized * runAwayDistance;

        controller.navMeshAgent.destination = newDestination;
        controller.navMeshAgent.isStopped = false;
        controller.navMeshAgent.updateRotation = true;
    }
}