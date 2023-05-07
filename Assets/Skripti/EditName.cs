using UnityEngine;
using UnityEngine.UI;

public class EditName : MonoBehaviour
{
    public InputField display;
    public Text displayText;
    private const int MaxNameLength = 9;
    private bool isOKButtonPressed = false;
    private bool hasAcceptedChanges = false;
    private string defaultPlaceholderText = "Ievadi tēla vārdu...";

    private void Start()
    {
        LoadPlayerName();
    }

    private void LoadPlayerName()
    {
        // Iegūst spēlētāja vārdu no saglabātajiem datiems
        string playerName = PlayerPrefs.GetString("user_name");

        if (hasAcceptedChanges)
        {
            // Ja spēlētājs ir apstiprinājis izmaiņas, notīra ievades laukuma aizvietotājtekstu un iestata saglabāto vārdu
            display.placeholder.GetComponent<Text>().text = "";
            display.text = playerName;
        }
        else
        {
            // Ja spēlētājs nav apstiprinājis izmaiņas, iestata ievades laukuma aizvietotājtekstu uz noklusējuma vērtību
            display.placeholder.GetComponent<Text>().text = defaultPlaceholderText;
        }

        // Atjauno tekstu, kas parāda spēlētāja vārdu
        displayText.text = "Vārds: " + playerName;
    }

    public void Create()
    {
        // Iegūst spēlētāja ievadīto vārdu
        string playerName = display.text;

        // Ja spēlētājs nav ievadījis savu vārdu, iestata vārdu uz tukšu vērtību
        if (playerName == display.placeholder.GetComponent<Text>().text)
        {
            playerName = "";
        }

        // Noņem ciparus no vārda, izmantojot regulāro izteiksmi
        playerName = System.Text.RegularExpressions.Regex.Replace(playerName, @"[\d-]", "");

        // Ja vārda garums pārsniedz maksimālo garumu, saīsina vārdu līdz maksimālajam garumam
        playerName = playerName.Length > MaxNameLength ? playerName.Substring(0, MaxNameLength) : playerName;

        // Atjauno ievades laukuma vērtību ar pēdējo iestatīto vārdu
        display.text = playerName;

        // Saglabā spēlētāja vārdu un saglabā izmaiņas
        PlayerPrefs.SetString("user_name", playerName);
        PlayerPrefs.Save();

        hasAcceptedChanges = true;
        isOKButtonPressed = true;
    }

    private void Update()
    {
        if (isOKButtonPressed)
        {
            // Atjauno tekstu, kas parāda spēlētāja vārdu, ar pēdējo ievadīto vērtību
            displayText.text = "Vārds: " + display.text;
            isOKButtonPressed = false;
        }
    }
}