using UnityEngine;

/**
 * <summary> 
 * �o�ӽd�Ҫ� Mecanim �D�n�O�� 2 �ӰѼƨӱ���⪺���]�欰. 
 * �@�ӬO Speed, �ƭȽd��O 0 ~ 6. 
 * 0 ~ 0.5 �O Idle; 0.5 ~ 1.5 �O Walk; 1.54 ~ 5.5 �O Walk, Run �V��.
 * 
 * Direction �O���⪺����׼�, �ƭȽd��O -180(����) ~ 180(�k��).
 * </summary>
 **/ 
[RequireComponent(typeof(Animator))]
public class LocomotionPlayer : MonoBehaviour
{
    private Animator mAnimator;

    // �o�O�O����(�H���� forward �M�s�����ʤ�V����������), �ƭȽd��O -180(����) ~ 180(�k��).
    // �s�����ʤ�V�@�w�O�۹�� Camera ����V, �ҥH���U��V�䪺�k��, �N��ܷs��V�O Camera ���k��.
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