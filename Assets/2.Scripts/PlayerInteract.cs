using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] GameObject InteractPanel;

    [SerializeField] GameObject TopInteractPanel;
    [SerializeField] GameObject BottomInteractPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPCInteract interactable = collision.gameObject.GetComponent<NPCInteract>();

        if (interactable != null)
        {
            InteractPanel.SetActive(true);
            TopInteractPanel.SetActive(true);
            BottomInteractPanel.SetActive(false);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NPCInteract interactable = collision.gameObject.GetComponent<NPCInteract>();

        if (interactable != null)
        {
            InteractPanel.SetActive(false);
            TopInteractPanel.SetActive(false);
            BottomInteractPanel.SetActive(false);
        }
    }

    public void OnClickInteract()
    {
        InteractPanel.SetActive(true);
        TopInteractPanel.SetActive(false);
        BottomInteractPanel.SetActive(true);
    }

    public void OnClickEndInteract()
    {
        InteractPanel.SetActive(false);
        TopInteractPanel.SetActive(false);
        BottomInteractPanel.SetActive(false);
    }
}
