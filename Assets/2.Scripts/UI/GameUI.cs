using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    
    [Header("이름 표시")]
    [SerializeField] private GameObject Player;
    [SerializeField] private RectTransform nameRect;
    public Text nameText;

    [Header("시간 표시")]
    [SerializeField] Text TimeText;

    [Header("이름 변경")]
    [SerializeField] private InputField InputName;
    public Button ChangeButton;
    [SerializeField] GameObject NameChangePanel;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = CharacterManager.Instance.Player;

        DataUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCheck();

        NameCheck();
    }

    private void TimeCheck()
    {
        TimeText.text = DateTime.Now.ToString("HH:mm");
    }

    private void FixedUpdate()
    {
        nameRect.position = Camera.main.WorldToScreenPoint(Player.transform.position);
    }

    void DataUpdate()
    {
        nameText.text = CharacterManager.Instance.InputName.text;
    }

    public void OpenNameChange()
    {
        InputName.text = "";
        NameChangePanel.SetActive(!NameChangePanel.activeSelf);
    }

    private void NameCheck()
    {
        if (InputName.text.Length >= 2)
        {
            ChangeButton.interactable = true;
        }
        else
        {
            ChangeButton.interactable = false;
        }
    }

    public void NameChange()
    {       
        CharacterManager.Instance.InputName.text = InputName.text;
        DataUpdate();
        OpenNameChange();
    }
}
