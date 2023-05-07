using UnityEngine;
using UnityEngine.UI;

public class BackstoryManager : MonoBehaviour
{
    [SerializeField] private string maleBackstory = "Vīrietis ar cirvi ir spēkavīrs." +
        " Viņa dzīve ir veltīta piedzīvojumiem meža dziļumos, kur viņš rūpīgi sargā dabu. " +
        "Viņš ir gudrs, izturīgs un drosmīgs, vienmēr gatavs aizstāvēt to, kas ir svarīgs. " +
        "Viņa cirvis ir viņa uzticamais draugs, kas palīdz veidot pasaules labāko nākotni";
    [SerializeField] private string femaleBackstory = "Sieviete ar mačeti ir neaizmirstama ceļotāja, kurai nav robežu." +
        " Viņas dzīve ir piedzīvojumi, pārbaudījumi un noslēpumi, ko atrisina ar drosmi un intelektu." +
        " Ar savu izturību un atvērtu prātu viņa atklāj pasauli un atklāj sevi." +
        " Viņas piedzīvojumu gars nekad neizsīks.";

    [SerializeField] private Text backstoryText;

    // Call this method to update the backstory text based on the gender
    public void UpdateBackstory(bool isMale)
    {
        if (isMale)
        {
            backstoryText.text = maleBackstory;
        }
        else
        {
            backstoryText.text = femaleBackstory;
        }
    }
}