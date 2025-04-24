using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject nameScreen;
    public GameObject menuScreen;
    public GameObject languageSelectionScreen;
    public TMP_Dropdown languageDropDown;
    public TMP_InputField userNameInput;
    public GameObject messageScreen;
    public TextMeshProUGUI messageText;

    public GameObject[] screens;
    public string userName
    {
        get
        {
            return PlayerPrefs.GetString("UserName", "");
        }
        set
        {
            PlayerPrefs.SetString("UserName", value);
        }
    }

    public string language
    {
        get
        {
            return PlayerPrefs.GetString("Language", "");
        }
        set
        {
            PlayerPrefs.SetString("Language", value);
        }
    }


    public void ScreenHandler(GameObject sc)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }
        if (sc != null)
        {
            sc.SetActive(true);
        }
    }

       
    void Start()
    {
        
    }
    public void ShowMessage(string message)
    {
        CancelInvoke("HideMessage");
        messageScreen.SetActive(true);
        messageText.text = message;
        Invoke("HideMessage", 2f);
    }
    public void HideMessage()
    {
        messageScreen.SetActive(false);
    }

    public void SetName()
    {
        if (string.IsNullOrEmpty(userNameInput.text))
        {
            ShowMessage("Please Enter Your name...");
        }
        else
        {
            userName = userNameInput.text;
            ScreenHandler(languageSelectionScreen);
        }
    }

    public void SetLanguage()
    {
        language=languageDropDown.options[languageDropDown.value].text;
            ScreenHandler(menuScreen);
    }

    public void Open360Video()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenFanAI()
    {
        SceneManager.LoadScene(2);
    }
}
