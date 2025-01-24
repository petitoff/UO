using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance &&
            !controller.navMeshAgent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPoints.Length;
        }

        controller.navMeshAgent.destination = controller.wayPoints[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;
        controller.navMeshAgent.updateRotation = true;
    }
}