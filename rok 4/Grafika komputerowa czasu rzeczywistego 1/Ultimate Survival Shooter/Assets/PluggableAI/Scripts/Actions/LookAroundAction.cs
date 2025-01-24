using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LookAroundAction")]
public class LookAroundAction : Action
{
    public override void Act(StateController controller)
    {
        LookAround(controller);
    }

    private void LookAround(StateController controller)
    {
        controller.rotationTimeElapsed += Time.deltaTime * controller.enemyStats.searchingTurnSpeed;
             controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0); // Obr�t w miejscu

        /* if (controller.rotationTimeElapsed >= 360f) // Sprawd�, czy obr�t si� zako�czy�
         {
             Debug.Log("LookAroundAction: Obr�t o 360� zako�czony.");
             controller.rotationTimeElapsed = 0f; // Resetuj czas obrotu
             controller.navMeshAgent.isStopped = false; // Przywr�� ruch agenta
             controller.navMeshAgent.updateRotation = true;
             controller.TransitionToState(controller.currentState.transitions[0].trueState); // Powr�t do PatrolAdvanced
         }
         else
         {
             Debug.Log($"LookAroundAction: Obracam si�. Czas obrotu: {controller.rotationTimeElapsed}");
             controller.navMeshAgent.isStopped = true; // Zatrzymaj agenta podczas obrotu
             controller.navMeshAgent.updateRotation = false;
         }*/
    }
}
