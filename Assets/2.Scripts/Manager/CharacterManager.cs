using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;
using Unity.VisualScripting;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    public InputField InputName;
    public Button JoinButton;

    [Header("Select Character")]
    public RuntimeAnimatorController[] animators;
    [SerializeField] GameObject[] renderers;
    [SerializeField] GameObject characterSelectImage;

    public int selectIndex = 0;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        NameCheck();
    }

    private void NameCheck()
    {
        if (InputName.text.Length >= 2)
        {
            JoinButton.interactable = true;
        }
        else
        {
            JoinButton.interactable = false;
        }
    }

    public void OnClickJoinButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickChangeCharacter()
    {
        characterSelectImage.SetActive(true);
    }

    public void OnClickCharacter(int index)
    {
        foreach (GameObject item in renderers)
        {
            item.SetActive(false);
        }
        selectIndex = index;
        renderers[index].SetActive(true);

        characterSelectImage.SetActive(false);
    }
}
