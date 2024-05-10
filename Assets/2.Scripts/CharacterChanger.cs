using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = CharacterManager.Instance.animators[CharacterManager.Instance.selectIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
