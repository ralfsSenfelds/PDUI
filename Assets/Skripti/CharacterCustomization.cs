using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public Image characterImage;
    public GameObject[] bodyParts;
    public Toggle[] toggleButtons;

    private void Start()
    {
        InitializeCustomization();
    }

    private void InitializeCustomization()
    {
        foreach (GameObject bodyPart in bodyParts)
        {
            bodyPart.SetActive(false);
        }

        for (int i = 0; i < toggleButtons.Length; i++)
        {
            int index = i;
            toggleButtons[i].onValueChanged.AddListener((isOn) =>
            {
                bodyParts[index].SetActive(isOn);
            });
        }
    }
}
