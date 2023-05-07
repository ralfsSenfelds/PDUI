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
        string playerName = PlayerPrefs.GetString("user_name");

        if (hasAcceptedChanges)
        {
            display.placeholder.GetComponent<Text>().text = "";
            display.text = playerName;
        }
        else
        {
            display.placeholder.GetComponent<Text>().text = defaultPlaceholderText;
        }

        displayText.text = "Vārds: " + playerName;
    }

    public void Create()
    {
        string playerName = display.text;

        if (playerName == display.placeholder.GetComponent<Text>().text)
        {
            playerName = "";
        }

        playerName = System.Text.RegularExpressions.Regex.Replace(playerName, @"[\d-]", "");

        if (playerName.Length > MaxNameLength)
        {
            playerName = playerName.Substring(0, MaxNameLength);
        }

        display.text = playerName;

        PlayerPrefs.SetString("user_name", playerName);
        PlayerPrefs.Save();

        hasAcceptedChanges = true;
        isOKButtonPressed = true;
    }

    private void Update()
    {
        if (isOKButtonPressed)
        {
            displayText.text = "Vārds: " + display.text;
            isOKButtonPressed = false;
        }
    }
}