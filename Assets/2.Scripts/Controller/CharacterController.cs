using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // OnMoveEvent�� ������ �Լ��� �ִٸ� ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); // OnMoveEvent�� ������ �Լ��� �ִٸ� ����
    }
}
