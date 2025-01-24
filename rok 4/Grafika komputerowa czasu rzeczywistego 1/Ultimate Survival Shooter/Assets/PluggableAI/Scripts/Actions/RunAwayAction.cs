using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RunAwayAction")]
public class RunAwayAction : Action
{
    public override void Act(StateController controller)
    {
        RunAway(controller);
    }

    private void RunAway(StateController controller)
    {
        if (controller.chaseTarget != null)
        {
            Vector3 directionAway = controller.transform.position - controller.chaseTarget.position;
            Vector3 newDestination = controller.transform.position + directionAway.normalized * 10f;

            controller.navMeshAgent.destination = newDestination;
            controller.navMeshAgent.isStopped = false;
            controller.navMeshAgent.updateRotation = true;
        }
    }
}
