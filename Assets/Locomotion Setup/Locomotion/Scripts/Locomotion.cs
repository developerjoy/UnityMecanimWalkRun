using UnityEngine;

public class Locomotion
{
    private readonly int mAgularSpeedID;
    public float AnguarSpeedDampTime = 0.25f;
//    public float AnguarSpeedDampTime = 2f;

    private readonly Animator mAnimator;
    private readonly int mDirectionID;

    public float DirectionResponseTime = 0.2f;
//    public float DirectionResponseTime = 0.5f;

    // �Ʀr�V�j, �Ʀr�ܰʪ��V�C.
    public float SpeedDampTime = 0.1f;
//    public float SpeedDampTime = 3f;

    private readonly int mSpeedID;

    public Locomotion(Animator animator)
    {
        mAnimator = animator;

        mSpeedID = Animator.StringToHash("Speed");
        mAgularSpeedID = Animator.StringToHash("AngularSpeed");
        mDirectionID = Animator.StringToHash("Direction");
    }

    public void Do(float speed, float direction)
    {
        var state = mAnimator.GetCurrentAnimatorStateInfo(0);

        var inTransition = mAnimator.IsInTransition(0);
        var inIdle = state.IsName("Locomotion.Idle");
        var inTurn = state.IsName("Locomotion.TurnOnSpot") || state.IsName("Locomotion.PlantNTurnLeft") ||
                     state.IsName("Locomotion.PlantNTurnRight");
        var inWalkRun = state.IsName("Locomotion.WalkRun");

        var speedDampTime = inIdle ? 0 : SpeedDampTime;
        var angularSpeedDampTime = inWalkRun || inTransition ? AnguarSpeedDampTime : 0;
        float directionDampTime = inTurn || inTransition ? 1000000 : 0;

        // �o�ӰѼƥu���Φb WalkRun State, �Ψӱ������ਭ.
        var angularSpeed = direction / DirectionResponseTime;

        mAnimator.SetFloat(mSpeedID, speed, speedDampTime, Time.deltaTime);
//        mAnimator.SetFloat(mSpeedID, speed);
        mAnimator.SetFloat(mAgularSpeedID, angularSpeed, angularSpeedDampTime, Time.deltaTime);
//        mAnimator.SetFloat(mAgularSpeedID, angularSpeed);
        mAnimator.SetFloat(mDirectionID, direction, directionDampTime, Time.deltaTime);
//        mAnimator.SetFloat(mDirectionID, direction);
    }
}