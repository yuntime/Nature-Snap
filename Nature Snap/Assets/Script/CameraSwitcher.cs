using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject thirdPersonCamera; // 3인칭 카메라 오브젝트
    public GameObject firstPersonCamera; // 1인칭 카메라 오브젝트 (사진 촬영용)

    private bool isFirstPersonMode = false; // 현재 1인칭 모드인지 여부

    void Start()
    {
        // 시작 시에는 3인칭 카메라 활성화, 1인칭 카메라 비활성화
        SetCameraMode(false); 
    }

    void Update()
    {
        // 특정 키 (예: 'V' 키)를 눌러 카메라 모드 전환
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            SetCameraMode(!isFirstPersonMode);
        }

        // 1인칭 모드일 때 마우스 이동으로 카메라 회전 (선택 사항)
        // 1인칭 카메라의 LookAt 스크립트 또는 직접 회전 로직 추가 가능
        if (isFirstPersonMode)
        {
            // 여기에 1인칭 카메라의 시야를 마우스로 조작하는 코드를 추가할 수 있습니다.
            // 예: MouseLook 스크립트 등을 사용하여 구현
        }
    }

    void SetCameraMode(bool enableFirstPerson)
    {
        isFirstPersonMode = enableFirstPerson;

        thirdPersonCamera.SetActive(!isFirstPersonMode); // 3인칭 카메라 활성화/비활성화
        firstPersonCamera.SetActive(isFirstPersonMode);  // 1인칭 카메라 활성화/비활성화

        // 1인칭 모드일 때 플레이어 이동/회전 제한 또는 변경 (선택 사항)
        // 예를 들어, 1인칭에서는 플레이어의 몸체가 아닌 시야만 회전하도록 할 수 있습니다.
        // GetComponent<PlayerMovement>().SetMovementMode(isFirstPersonMode); // 플레이어 이동 스크립트에 따라 조절
    }

    // (선택 사항) 사진 촬영 기능 예시 - 1인칭 모드일 때 특정 키로 사진 촬영
    public void TakePhoto()
    {
        if (isFirstPersonMode)
        {
            Debug.Log("사진 촬영!");
            // 여기에 실제 스크린샷 저장 로직을 추가합니다.
            // 예: ScreenCapture.CaptureScreenshot("Photo_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        }
    }
}