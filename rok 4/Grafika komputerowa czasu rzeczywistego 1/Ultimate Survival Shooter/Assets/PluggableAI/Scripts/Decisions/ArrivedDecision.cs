using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ArrivedDecision")]
public class ArrivedDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckIfArrived(controller);
    }

    private bool CheckIfArrived(StateController controller)
    {
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance)
        {
            Debug.Log("ArrivedDecision: Agent dotar� do waypointu.");
            return true;
        }

        Debug.Log($"ArrivedDecision: Agent wci�� w drodze. Pozosta�a odleg�o�� = {controller.navMeshAgent.remainingDistance}");
        return false;
    }


}
