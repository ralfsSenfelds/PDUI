using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public Image maleCharacterImage; // Attēls vīrieša rakstura attēlošanai
    public Image femaleCharacterImage; // Attēls sievietes rakstura attēlošanai
    public GameObject[] maleBodyParts; // Masīvs, kas satur vīrieša rakstura daļas
    public GameObject[] femaleBodyParts; // Masīvs, kas satur sievietes rakstura daļas
    public Toggle[] maleToggleButtons; // Masīvs, kas satur vīrieša izvēles pogas
    public Toggle[] femaleToggleButtons; // Masīvs, kas satur sievietes izvēles pogas
    public Dropdown genderDropdown; // Nolaižamais saraksts ar dzimumiem

    private GameObject[] activeBodyParts; // Masīvs, kas satur pašlaik aktīvās ķermeņa daļas

    private void Start()
    {
        InitializeCustomization(); // Inicializē rakstura pielāgošanu
    }

    private void InitializeCustomization()
    {
        SetBodyPartsActive(false, maleBodyParts); // Paslēpj vīrieša ķermeņa daļas
        SetBodyPartsActive(false, femaleBodyParts); // Paslēpj sievietes ķermeņa daļas

        SetGender(0); // Iestata noklusēto dzimumu uz vīrieti

        genderDropdown.onValueChanged.AddListener(SetGender); // Pievieno notikumu, kas izsaucas, kad tiek mainīts dzimuma izvēles saraksts

        for (int i = 0; i < maleToggleButtons.Length; i++)
        {
            int index = i;
            maleToggleButtons[i].onValueChanged.AddListener(delegate { SetBodyPartActive(maleBodyParts[index], maleToggleButtons[index].isOn); });
        }

        for (int i = 0; i < femaleToggleButtons.Length; i++)
        {
            int index = i;
            femaleToggleButtons[i].gameObject.SetActive(false);
            femaleToggleButtons[i].onValueChanged.AddListener(delegate { SetBodyPartActive(femaleBodyParts[index], femaleToggleButtons[index].isOn); });
        }
    }

    private void SetGender(int genderIndex)
    {
        if (activeBodyParts != null)
        {
            SetBodyPartsActive(false, activeBodyParts);
        }

        if (genderIndex == 0) // Izvēlēts vīrietis
        {
            maleCharacterImage.gameObject.SetActive(true); // Parāda vīrieša attēlu
            femaleCharacterImage.gameObject.SetActive(false); // Paslēpj sievietes attēlu

            activeBodyParts = maleBodyParts; // Iestata aktīvās ķermeņa daļas uz vīrieša daļām

            SetToggleButtonsActive(true, maleToggleButtons); // Parāda vīrieša izvēles pogas
            SetToggleButtonsActive(false, femaleToggleButtons); // Paslēpj sievietes izvēles pogas

            ResetToggleButtons(maleToggleButtons, new int[] { 0, 4, 8 }); // Atiestata vīrieša izvēles pogas
        }
        else if (genderIndex == 1) // Izvēlēta sieviete
        {
            maleCharacterImage.gameObject.SetActive(false); // Paslēpj vīrieša attēlu
            femaleCharacterImage.gameObject.SetActive(true); // Parāda sievietes attēlu

            activeBodyParts = femaleBodyParts; // Iestata aktīvās ķermeņa daļas uz sievietes daļām

            SetToggleButtonsActive(true, femaleToggleButtons); // Parāda sievietes izvēles pogas
            SetToggleButtonsActive(false, maleToggleButtons); // Paslēpj vīrieša izvēles pogas

            ResetToggleButtons(femaleToggleButtons, new int[] { 2, 4, 8 }); // Atiestata sievietes izvēles pogas
        }

        SetBodyPartsActive(true, activeBodyParts); // Aktivizē izvēlētās ķermeņa daļas
    }

    private void SetBodyPartsActive(bool isActive, GameObject[] bodyParts)
    {
        foreach (GameObject bodyPart in bodyParts)
        {
            bodyPart.SetActive(isActive);
        }
    }

    private void SetToggleButtonsActive(bool isActive, Toggle[] toggleButtons)
    {
        foreach (Toggle toggleButton in toggleButtons)
        {
            toggleButton.gameObject.SetActive(isActive);
        }
    }

    private void ResetToggleButtons(Toggle[] toggleButtons, int[] indices)
    {
        foreach (int index in indices)
        {
            toggleButtons[index].isOn = true;
        }
    }

    private void SetBodyPartActive(GameObject bodyPart, bool isActive)
    {
        bodyPart.SetActive(isActive);
    }
}