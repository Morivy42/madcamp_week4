using UnityEngine;

public class MatchCameraPosition : MonoBehaviour
{
    public Transform cameraToMatch; // 카메라의 Transform 컴포넌트를 할당할 변수
    [SerializeField] private float speed = 5f; // 카메라를 따라가는 속도

    private void Update()
    {
        if (cameraToMatch != null)
        {
            // 카메라 위치를 오브젝트 위치로 설정
            // Vector3 dir = new Vector3(cameraToMatch.position.x-this.transform.position.x, cameraToMatch.position.y-this.transform.position.y, 0f) + Vector3.up * 4f;
            // transform.Translate(dir);
            // // transform.position = cameraToMatch.position + Vector3.up * 5f;

            //Lerp 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, cameraToMatch.position + Vector3.up * 3f, Time.deltaTime * speed);
        }
    }
}
