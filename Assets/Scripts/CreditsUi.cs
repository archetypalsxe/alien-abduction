using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsUi : MonoBehaviour {

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
