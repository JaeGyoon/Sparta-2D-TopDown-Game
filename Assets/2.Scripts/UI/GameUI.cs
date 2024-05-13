using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("접속 유저")]
    [SerializeField] GameObject userNameText;
    [SerializeField] Transform LayoutGroup;
    CharacterInfomation characterInfomation;        
    [SerializeField] GameObject UserListPanel;
    [SerializeField] List<CharacterInfomation> Users = new List<CharacterInfomation>();
    List<GameObject> instantiatedGameObject = new List<GameObject>();

    [Header("캐릭터 변경")]
    [SerializeField] GameObject characterSelectImage;
    CharacterChanger characterChanger;



    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = CharacterManager.Instance.Player;
        characterInfomation = Player.GetComponent<CharacterInfomation>();
        characterChanger = Player.GetComponent<CharacterChanger>();
        //DataUpdate();

        /*nameText.text = CharacterManager.Instance.InputName.text;
        characterInfomation.name = nameText.text;*/
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
        characterInfomation.name = nameText.text;
                
        ClearGameObjcet();

        foreach (CharacterInfomation user in Users)
        {
            GameObject obj = Instantiate(userNameText, LayoutGroup);
            obj.GetComponent<Text>().text = user.name;

            instantiatedGameObject.Add(obj);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        CharacterInfomation info = collision.gameObject.GetComponent<CharacterInfomation>();

        if (info != null)
        {            
            Users.Add(info);
            
        }

        DataUpdate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CharacterInfomation info = collision.gameObject.GetComponent<CharacterInfomation>();

        if (info != null)
        {
            Users.Remove(info);           
        }
    }

    private void ClearGameObjcet()
    {
        

        if (instantiatedGameObject.Count == 0)
        {
            return;
        }

        foreach (GameObject item in instantiatedGameObject)
        {
            Destroy(item);
        }

        instantiatedGameObject.Clear();
    }

    public void OpenUserList()
    {
        DataUpdate();
        UserListPanel.SetActive(!UserListPanel.activeSelf);
    }

    public void OnClickChangeCharacter()
    {
        characterSelectImage.SetActive(!characterSelectImage.activeSelf);
    }

    public void OnClickCharacter(int index)
    {
        
        CharacterManager.Instance.selectIndex = index;

        characterChanger.CharacterChange();

        characterSelectImage.SetActive(false);


    }

}
