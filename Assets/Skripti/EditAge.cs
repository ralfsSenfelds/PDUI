using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAge : MonoBehaviour
{
    public InputField ageInputField;
    public Text displayText;
    private const int MaxAgeValue = 9999;
    private bool isOKButtonPressed = false;

    private void Start()
    {
        LoadPlayerAge();
    }

    private void LoadPlayerAge()
    {
        int ageValue = PlayerPrefs.GetInt("user_age");

        ageInputField.text = ageValue.ToString();
        displayText.text = "Vecums: " + ageValue.ToString();
    }

    public void Create()
    {
        int ageValue;
        if (int.TryParse(ageInputField.text, out ageValue))
        {
            if (ageValue > MaxAgeValue)
            {
                ageValue = MaxAgeValue;
                ageInputField.text = MaxAgeValue.ToString();
            }
        }
        else
        {
            ageValue = 0;
            ageInputField.text = "0";
        }

        displayText.text = "Vecums: " + ageValue.ToString();

        PlayerPrefs.SetInt("user_age", ageValue);
        PlayerPrefs.Save();

        isOKButtonPressed = true;
    }

    private void Update()
    {
        if (isOKButtonPressed)
        {
            displayText.text = "Vecums: " + ageInputField.text;
            isOKButtonPressed = false;
        }
    }
}