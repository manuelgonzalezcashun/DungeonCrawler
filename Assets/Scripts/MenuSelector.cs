using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] menuButtons;
    [SerializeField] private int defaultButtonIndex = 0;

    private int currentButtonIndex;

    void Start()
    {
        StartCoroutine(SelectFirstChoice());
        currentButtonIndex = defaultButtonIndex;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            currentButtonIndex++;
            if (currentButtonIndex >= menuButtons.Length)
            {
                currentButtonIndex = 0;
                StartCoroutine(SelectChoice());
            }
        }
        else if (horizontalInput < 0)
        {
            currentButtonIndex--;
            if (currentButtonIndex < 0)
            {
                currentButtonIndex = menuButtons.Length - 1;
                StartCoroutine(SelectChoice());
            }
        }
    }

    public IEnumerator SelectChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(menuButtons[currentButtonIndex].gameObject);
    }
    public IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(menuButtons[defaultButtonIndex].gameObject);
    }
}
