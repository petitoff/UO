using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ChaseAction")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        if (controller.chaseTarget)
        {
            controller.navMeshAgent.destination = controller.chaseTarget.position;
            controller.navMeshAgent.isStopped = false;
            controller.navMeshAgent.updateRotation = true;
        }
    }
}
