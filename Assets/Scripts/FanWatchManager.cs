using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FanWatchManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI secondsText;
    public AudioSource whistle;
    public AudioClip[] clips;
    public GameObject TabScreen;
    void Start()
    {

    }

    void Update()
    {
        ShowTime();
    }

    public void PlayWhistle()
    {
        whistle.clip= clips[Random.Range(0,clips.Length)];
        whistle.Play();
    }
    public void ShowTime()
    {
        System.DateTime now = System.DateTime.Now;

        // Format hours and minutes
        string hoursAndMinutes = now.ToString("HH:mm");
        timeText.text = hoursAndMinutes;
        // Get the seconds
        string seconds = now.Second.ToString("D2"); // D2 ensures two digits, e.g., 01, 02
        secondsText.text = seconds;
        // Print to the console
    }
    public void Open360Video()
    {
        SceneManager.LoadScene(1);
    }

    public void ManageTabScreen()
    {
        if (TabScreen.activeInHierarchy)
        {
            TabScreen.SetActive(false);
        }
        else
        {
            TabScreen.SetActive(true);
        }
    }
    public void OpenFanAI()
    {
        SceneManager.LoadScene(2);
    }
}
