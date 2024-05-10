using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // OnMoveEvent에 구독한 함수가 있다면 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); // OnMoveEvent에 구독한 함수가 있다면 실행
    }
}
