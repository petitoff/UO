using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LookAroundAction")]
public class LookAroundAction : Action
{
    public override void Act(StateController controller)
    {
        LookAround(controller);
    }

    private void LookAround(StateController controller)
    {
        controller.currentRotation += Time.deltaTime * controller.enemyStats.searchingTurnSpeed;
        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime, 0);
    }
}