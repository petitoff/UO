using System;
using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("PatrolAction: Dotarłem do waypointu.");
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPoints.Length;
        }
        
        controller.navMeshAgent.destination = controller.wayPoints[controller.nextWayPoint].position;
        controller.navMeshAgent.isStopped = false;
        controller.navMeshAgent.updateRotation = true;

        Debug.Log($"PatrolAction: do waypointu {controller.nextWayPoint}. Cel: {controller.wayPoints[controller.nextWayPoint].position}");
    }

}