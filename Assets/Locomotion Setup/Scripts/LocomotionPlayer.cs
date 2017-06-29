using UnityEngine;

/**
 * <summary> 
 * 這個範例的 Mecanim 主要是由 2 個參數來控制角色的走跑行為. 
 * 一個是 Speed, 數值範圍是 0 ~ 6. 
 * 0 ~ 0.5 是 Idle; 0.5 ~ 1.5 是 Walk; 1.54 ~ 5.5 是 Walk, Run 混撥.
 * 
 * Direction 是角色的旋轉度數, 數值範圍是 -180(左晚) ~ 180(右轉).
 * </summary>
 **/ 
[RequireComponent(typeof(Animator))]
public class LocomotionPlayer : MonoBehaviour
{
    private Animator mAnimator;

    // 這是是夾角(人物的 forward 和新的移動方向之間的夾角), 數值範圍是 -180(左轉) ~ 180(右轉).
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