using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAge : MonoBehaviour
{
    public InputField ageInputField;
    public Text displayText;

    private const int MaxAgeValue = 122;
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
            // Ja ir pieņemtas izmaiņas, tad notīram aizvietējošo tekstu un iestatām ievadīto vecumu
            ageInputField.placeholder.GetComponent<Text>().text = "";
            ageInputField.text = ageValue.ToString();
        }
        else
        {
            // Ja izmaiņas vēl nav pieņemtas, tad iestatām aizvietējošo tekstu
            ageInputField.placeholder.GetComponent<Text>().text = "Ievadi tēla vecumu...";
        }

        // Parādām vecuma tekstu
        displayText.text = "Vecums: " + ageValue.ToString();
    }

    public void Create()
    {
        int ageValue;

        // Mēģinām iegūt ievadīto vecuma vērtību
        if (int.TryParse(ageInputField.text, out ageValue))
        {
            // Ja iegūšana bija veiksmīga, ierobežojam vecuma vērtību no 0 līdz maksimālās vecuma vērtībai
            ageValue = Mathf.Clamp(ageValue, 0, MaxAgeValue);
            ageInputField.text = ageValue.ToString();
        }
        else
        {
            // Ja iegūšana nebija veiksmīga, iestatām vecuma vērtību uz 0 un notīram ievades lauku
            ageValue = 0;
            ageInputField.text = "";
        }

        // Atjaunojam vecuma tekstu
        displayText.text = "Vecums: " + ageValue.ToString();

        // Saglabājam vecuma vērtību
        PlayerPrefs.SetInt("user_age", ageValue);
        PlayerPrefs.Save();

        // Atzīmējam, ka ir pieņemtas izmaiņas
        hasAcceptedChanges = true;
    }

    public void UpdateDisplayText()
    {
        // Atjaunojam vecuma tekstu ar ievadīto vērtību
        displayText.text = "Vecums: " + ageInputField.text;
    }
}