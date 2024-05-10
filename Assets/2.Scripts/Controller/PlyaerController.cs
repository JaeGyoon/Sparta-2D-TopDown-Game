using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlyaerController : CharacterController                                 // 플레이어는 입력값을 통해 얻은 값으로 이벤트들을 실행
{
    private Camera camara;

    private void Awake()
    {
        camara = Camera.main;
    }

    /* PlayerInput 컴포넌트의 Actions에서 정의된 Move의 값(Vecotor2)을 InputValue 타입으로 받는다.
     * Send Message로 받기 때문에 ( Player Input - Behavior - SendMessages) 해당 Action 이름 앞에 On을 붙인다. */
    public void OnMove(InputValue value)
    {
        Vector2 moveDirection = value.Get<Vector2>().normalized;

        CallMoveEvent(moveDirection);                                                
    }

    public void OnLook(InputValue value)
    {        
        Vector2 lookDirection = value.Get<Vector2>();                    // UI 에서 마우스 커서 위치

        Vector2 worldPoint = camara.ScreenToWorldPoint(lookDirection);              // 마우스 위치를 메인 카메라에서 바라봤을때의 월드 좌표로 변환한 값.

        lookDirection = (worldPoint - (Vector2)this.transform.position).normalized; // 현재 내 위치에서 worldPoint를 바라보는 방향을 정규화 한 값

        CallLookEvent(lookDirection);
    }

}
