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
    private bool hasAcceptedChanges = false;

    private void Start()
    {
        LoadPlayerAge();
    }

    private void LoadPlayerAge()
    {
        int ageValue = PlayerPrefs.GetInt("user_age");

        if (hasAcceptedChanges)
        {
            ageInputField.placeholder.GetComponent<Text>().text = "";
            ageInputField.text = ageValue.ToString();
        }
        else
        {
            ageInputField.placeholder.GetComponent<Text>().text = "Ievadi tēla vecumu...";
        }

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
            ageInputField.text = "";
        }

        displayText.text = "Vecums: " + ageValue.ToString();

        PlayerPrefs.SetInt("user_age", ageValue);
        PlayerPrefs.Save();

        hasAcceptedChanges = true;
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