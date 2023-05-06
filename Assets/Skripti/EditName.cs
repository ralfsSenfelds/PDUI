using UnityEngine;
using UnityEngine.UI;

public class EditName : MonoBehaviour
{
    public InputField display;
    public Text displayText;
    private const int MaxNameLength = 8;
    private bool isOKButtonPressed = false;

    private void Start()
    {
        LoadPlayerName();
    }

    private void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("user_name");
        display.text = playerName;
        displayText.text = "Vārds: " + playerName;
    }

    public void Create()
    {
        string playerName = display.text;

        if (playerName.Length > MaxNameLength)
        {
            playerName = playerName.Substring(0, MaxNameLength);
        }

        display.text = playerName;

        PlayerPrefs.SetString("user_name", playerName);
        PlayerPrefs.Save();

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