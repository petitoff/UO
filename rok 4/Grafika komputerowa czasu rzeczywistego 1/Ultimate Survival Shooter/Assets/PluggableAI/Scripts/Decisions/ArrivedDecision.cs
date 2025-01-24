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
            Debug.Log("ArrivedDecision: Agent dotar³ do waypointu.");
            return true;
        }

        Debug.Log($"ArrivedDecision: Agent wci¹¿ w drodze. Pozosta³a odleg³oœæ = {controller.navMeshAgent.remainingDistance}");
        return false;
    }


}
