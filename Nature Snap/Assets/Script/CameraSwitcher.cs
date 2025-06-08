using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // 유니티 에디터에서 드래그 앤 드롭으로 연결할 카메라 오브젝트들
    public GameObject thirdPersonCamera; 
    public GameObject firstPersonCamera; 

    // 현재 1인칭 모드인지 추적하는 변수
    [HideInInspector] // 인스펙터에서 숨겨 다른 팀원이 실수로 변경하는 것을 방지
    public bool isFirstPersonMode = false; 

    void Start()
    {
        // 게임 시작 시 3인칭 카메라를 활성화하고 1인칭 카메라를 비활성화합니다.
        SetCameraMode(false); 
    }

    void Update()
    {
        // 'V' 키를 누르면 카메라 모드를 전환합니다.
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            SetCameraMode(!isFirstPersonMode); // 현재 모드의 반대 모드로 전환
        }

        // 1인칭 모드일 때 마우스 왼쪽 버튼 클릭 시 사진 촬영 (이 스크립트에서 직접 처리)
        if (isFirstPersonMode && Input.GetMouseButtonDown(0))
        {
            TakePhoto();
        }
    }

    // 카메라 모드를 설정하는 함수
    public void SetCameraMode(bool enableFirstPerson)
    {
        isFirstPersonMode = enableFirstPerson;

        // 3인칭 카메라 활성화 여부
        thirdPersonCamera.SetActive(!isFirstPersonMode); 
        // 1인칭 카메라 활성화 여부
        firstPersonCamera.SetActive(isFirstPersonMode);  

        // 1인칭 모드일 때 마우스 커서 설정
        if (isFirstPersonMode)
        {
            Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 화면 중앙에 고정
            Cursor.visible = false;                   // 마우스 커서 숨기기
        }
        else // 3인칭 모드일 때 또는 일반적인 플레이 시
        {
            // 다른 팀원의 플레이어 이동 스크립트에서 커서를 관리하는 것이 더 일반적입니다.
            // 여기서는 3인칭 모드로 돌아왔을 때 커서 상태를 원래대로 돌릴지 결정해야 합니다.
            // 만약 플레이어 이동 스크립트에서 이미 커서 관리를 하고 있다면 이 부분은 제거해도 됩니다.
            // Cursor.lockState = CursorLockMode.None; 
            // Cursor.visible = true;
        }
    }

    // (선택 사항) 사진 촬영 기능 예시 - ScreenCapture를 사용
    private void TakePhoto()
    {
        // 1인칭 모드에서만 사진 촬영 가능
        if (isFirstPersonMode)
        {
            // 스크린샷 저장 경로 설정 (프로젝트 폴더 내 Screenshots 폴더)
            string folderPath = Application.dataPath + "/Screenshots/"; 
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            // 파일 이름: Photo_년월일_시분초.png
            string fileName = "Photo_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            string fullPath = System.IO.Path.Combine(folderPath, fileName);

            ScreenCapture.CaptureScreenshot(fullPath);
            Debug.Log("사진 촬영 완료: " + fullPath);

            // TODO: 여기에 사진 촬영 시 시각적/청각적 피드백 (예: 플래시 효과, 셔터 소리) 추가
        }
    }
}