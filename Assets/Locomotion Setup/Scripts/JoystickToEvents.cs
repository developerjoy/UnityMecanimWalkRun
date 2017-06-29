using UnityEngine;

public class JoystickToEvents : MonoBehaviour
{
    public static void Do(Transform root, Transform camera, out float speed, out float direction)
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var stickDirection = new Vector3(horizontal, 0, vertical); // 搖桿方向

        // Get camera rotation.    
        var cameraDir = camera.forward;
        cameraDir.y = 0.0f; // kill Y
        var referentialShift = Quaternion.FromToRotation(Vector3.forward, cameraDir);

        // Convert joystick input in Worldspace coordinates
        // 按下右方向鍵時, 人是往 Camera 的右方向跑. 所以需要 Camera 的旋轉量找出 Player 的新移動方向.
        var moveDirection = referentialShift * stickDirection;

        var speedVec = new Vector2(horizontal, vertical);
        speed = Mathf.Clamp(speedVec.magnitude, 0, 1);

        if(speed > 0.01f) // dead zone
        {
            var rootDirection = root.forward;
            var axis = Vector3.Cross(rootDirection, moveDirection);
//            direction = Vector3.Angle(rootDirection, moveDirection) / 180.0f * (axis.y < 0 ? -1 : 1);
            direction = Vector3.Angle(rootDirection, moveDirection) * (axis.y < 0 ? -1 : 1);
        }
        else
        {
            direction = 0.0f;
        }
    }
}