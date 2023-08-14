using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] private Button firstButton;

    private void Start()
    {
        SelectFirstButton();
    }
    private void SelectFirstButton()
    {
        firstButton.Select();
    }
}
