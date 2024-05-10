using UnityEditor;
using UnityEngine;

[RequireComponent (typeof(CharacterController)), RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour  // 실제로 움직이는 기능을 담당하는 서비스 부분
{    
    [Header("Move")]
    private CharacterController controller;
    private Rigidbody2D rigid;
    [SerializeField] private Vector2 movementDirection = Vector2.zero;
    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        controller = GetComponent<CharacterController> ();
        rigid = GetComponent<Rigidbody2D> ();
    }

    private void Start()
    {
        controller.OnMoveEvent += SetMovementDirection;
    }

    private void SetMovementDirection(Vector2 direction)
    {        
        movementDirection = direction;      // 물리적인 로직은 Fixed Update에서 담당하기 위해 이동 방향만 설정한다.
    }

    private void FixedUpdate()
    {
        CharacterMove(movementDirection);
    }

    private void CharacterMove(Vector2 direction)
    {        
        direction = direction * speed; // 추후 스텟에서 값을 받기 전까지 하드코딩
        rigid.velocity = direction;
    }
}