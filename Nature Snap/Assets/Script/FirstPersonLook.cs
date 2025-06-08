using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f; // 위/아래 시야 제한

    float rotationX = 0;

    void Update()
    {
        // 1인칭 카메라가 활성화되어 있을 때만 작동
        if (gameObject.activeSelf)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // 시야 상하 제한

            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            
            // 플레이어 자체는 좌우 회전 (Yaw)을 해야 하므로,
            // 이 스크립트가 FirstPersonCam에 있다면, Player의 좌우 회전은 PlayerMovement에서 담당해야 합니다.
            // PlayerMovement 스크립트에서 Player의 Yaw 회전을 처리하고,
            // 이 FirstPersonLook 스크립트에서 FirstPersonCam의 Pitch 회전만 처리하도록 합니다.
            transform.parent.Rotate(Vector3.up * Input.GetAxis("Mouse X") * lookSpeed);
        }
    }
}