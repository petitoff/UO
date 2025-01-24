using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/RotDecision")]
public class RotDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return CheckRotationComplete(controller);
    }

    private bool CheckRotationComplete(StateController controller)
    {
        controller.navMeshAgent.isStopped = true; // Zatrzymaj agenta podczas obrotu
        controller.navMeshAgent.updateRotation = false;

        Debug.Log($"RotDecision: Kąt obrotu = {controller.rotationTimeElapsed}");

        if (controller.rotationTimeElapsed >= 360f)
        {
            Debug.Log("RotDecision: Obrót zakończony.");
            return true;
        }

        return false; // Obrót trwa dalej
    }
}
