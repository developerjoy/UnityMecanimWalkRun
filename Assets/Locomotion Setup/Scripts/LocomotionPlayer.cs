using UnityEngine;

[RequireComponent(typeof(Animator))]

//Name of class must be name of file as well
public class LocomotionPlayer : MonoBehaviour
{
    private Animator mAnimator;

    // 當變換方向的時候，數值會比較大，經過一段時間後，數值會趨近於 0.
    // 我其實是角度(人物的 forward 和新的移動方向之間的夾角), 數值範圍應該是 -180(左轉) ~ 180(右轉).
    // 新的移動方向一定是相對於 Camera 的方向, 所以按下方向鍵的右鍵, 就表示新方向是 Camera 的右邊.
    private float mDirection;

    private Locomotion mLocomotion;

    private float mSpeed;

    // Use this for initialization
    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        mLocomotion = new Locomotion(mAnimator);
    }

    private void Update()
    {
        if(mAnimator && Camera.main)
        {
            JoystickToEvents.Do(transform, Camera.main.transform, out mSpeed, out mDirection);
//            mLocomotion.Do(mSpeed * 6, mDirection * 180);
            mLocomotion.Do(mSpeed * 6, mDirection);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), string.Format("Speed:{0}, Direction:{1}", mSpeed, mDirection));
    }
}