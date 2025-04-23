using Convai.Scripts.Runtime.Core;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FanAIManager : MonoBehaviour
{
    public bool init;
    public ConvaiNPC NPC;
    public bool start;
    public bool stop;
    public GameObject firstScreen;
    public GameObject secondScreen;
    public GameObject thirdScreen;
    public GameObject initButton;
    public GameObject aiParent;
    public TextMeshProUGUI responseText;
    public GameObject responseUI;
    public GameObject speakingObject;
    public GameObject startRecordBtn;
    public GameObject stopRecordBtn;
    public bool isRecording;
    public bool recordingStop;
    public bool isSpeaking;
    public int currentDot;
    public Image[] animImgDots;
    public SpriteRenderer[] animDots;
    public ConvaiNPC arabicCharacter;
    public ConvaiNPC englishCharacter;
    public ConvaiNPC currentNPC;

    public static FanAIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(IEOnBoardingUI());
        AnimateSpeakingObject();
    }

    public void EnableArabic()
    {
        arabicCharacter.gameObject.SetActive(true);
        englishCharacter.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        arabicCharacter.gameObject.SetActive(false);
        englishCharacter.gameObject.SetActive(true);
    }
    public IEnumerator IEOnBoardingUI()
    {
        yield return new WaitForSeconds(2f);
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        initButton.SetActive(true);
        yield return new WaitForSeconds(2f);
        secondScreen.SetActive(false);
        thirdScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        thirdScreen.SetActive(false);
    }

    public void ButtonHandler(GameObject Obj)
    {
        startRecordBtn.SetActive(startRecordBtn.name == Obj.name);
        stopRecordBtn.SetActive(stopRecordBtn.name == Obj.name);
    }

    public void SetResponseText(string response)
    {
        responseText.text = response;
        responseUI.SetActive(true);
        speakingObject.SetActive(false);
    }


    public void StartRecording()
    {
        recordingStop = false;
        isRecording = true;
        ButtonHandler(stopRecordBtn);
        NPC.StartListening();
    }

    public void StopRecording()
    {
        recordingStop = true;
        isRecording = false;
        ButtonHandler(startRecordBtn);
        NPC.StopListening();
        responseUI.SetActive(false);
        speakingObject.SetActive(true);
    }

    void Update()
    {
        if (init)
        {
            InitAvatar();
            init = false;
        }
        if (start)
        {
            StartRecording();
            start = false;
        }
        if (stop)
        {
            StopRecording();
            stop = false;
        }
    }
    public void InitAvatar()
    {
        initButton.SetActive(false);
        aiParent.SetActive(true);
        NPC.gameObject.SetActive(true);
    }

    public void Quit()
    {
        StartCoroutine(IEQuit());
        Debug.LogError("Quit");
    }

    public IEnumerator IEQuit()
    {
        while (NPC.IsCharacterTalking)
        {
            yield return new WaitForSeconds(1);
        }
        Application.Quit();
    }
    public void AnimateSpeakingObject()
    {
        /*for (int i = 0; i < animDots.Length; i++)
        {
            animDots[i].color = Color.white;
        }
        if (currentDot >= animDots.Length)
        {
            currentDot = 0;
        }
        animDots[currentDot].DOColor(Color.black, .5f).OnComplete(() => { currentDot++; AnimateSpeakingObject(); });*/

        for (int i = 0; i < animImgDots.Length; i++)
        {
            animImgDots[i].color = Color.white;
        }
        if (currentDot >= animImgDots.Length)
        {
            currentDot = 0;
        }
        animImgDots[currentDot].DOColor(Color.black, .5f).OnComplete(() => { currentDot++; AnimateSpeakingObject(); });
    }
}
