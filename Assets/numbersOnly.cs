using UnityEngine;
using UnityEngine.UI;

public class OnlyNumbersInput : MonoBehaviour
{
    private InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<InputField>();
        _inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string value)
    {
        int number;
        bool isNumber = int.TryParse(value, out number);

        if (!isNumber)
        {
            _inputField.text = "";
        }

        Debug.Log("Input field value: " + _inputField.text);
    }
}