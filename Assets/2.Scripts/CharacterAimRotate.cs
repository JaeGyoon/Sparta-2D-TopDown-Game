using System;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterAimRotate : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private SpriteRenderer renderer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateAim(direction);
    }

    private void RotateAim(Vector2 direction)
    {
        Debug.Log(direction);

        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                

        renderer.flipX = Mathf.Abs(rotateZ) > 90f;
        
    }
}
