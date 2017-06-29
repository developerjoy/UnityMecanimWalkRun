using UnityEngine;

[RequireComponent(typeof(Animator))]

//Name of class must be name of file as well
public class LocomotionPlayer : MonoBehaviour
{
    private Animator mAnimator;

    // ���ܴ���V���ɭԡA�ƭȷ|����j�A�g�L�@�q�ɶ���A�ƭȷ|�ͪ�� 0.
    // �ڨ��O����(�H���� forward �M�s�����ʤ�V����������), �ƭȽd�����ӬO -180(����) ~ 180(�k��).
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