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
             controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0); // Obrót w miejscu

        /* if (controller.rotationTimeElapsed >= 360f) // SprawdŸ, czy obrót siê zakoñczy³
         {
             Debug.Log("LookAroundAction: Obrót o 360° zakoñczony.");
             controller.rotationTimeElapsed = 0f; // Resetuj czas obrotu
             controller.navMeshAgent.isStopped = false; // Przywróæ ruch agenta
             controller.navMeshAgent.updateRotation = true;
             controller.TransitionToState(controller.currentState.transitions[0].trueState); // Powrót do PatrolAdvanced
         }
         else
         {
             Debug.Log($"LookAroundAction: Obracam siê. Czas obrotu: {controller.rotationTimeElapsed}");
             controller.navMeshAgent.isStopped = true; // Zatrzymaj agenta podczas obrotu
             controller.navMeshAgent.updateRotation = false;
         }*/
    }
}
