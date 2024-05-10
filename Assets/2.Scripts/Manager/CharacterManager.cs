using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    public InputField InputName;
    public Button JoinButton;


    
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
}
