using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUI : MonoBehaviour
{
    private RectTransform rect;
    private GameObject Player;

    public Text nameText;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        nameText.text = CharacterManager.Instance.InputName.text;
    }

    private void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(Player.transform.position);
    }
}
