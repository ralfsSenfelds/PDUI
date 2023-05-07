using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    // Metode, kas nomaina uz nākamo līmeni ar izgaismošanas efektu
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Metode, kas nomaina uz konkrētu līmeni ar izgaismošanas efektu
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    // Metode, kas tiek izsaukta, kad izgaismošanas efekts ir pabeidzies
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Metode, kas ielādē līmeni pēc nosaukuma
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // Metode, kas iziet no spēles
    public void QuitGame()
    {
        Application.Quit();
    }
}