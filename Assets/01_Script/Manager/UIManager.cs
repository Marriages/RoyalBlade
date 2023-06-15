using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Canvas canvas;       //Canvas를 직접 넣어줄예정


    Button Pause;
    TextMeshProUGUI heartText;
    string[] heartTexts= { "","♥", "♥♥", "♥♥♥" };
    TextMeshProUGUI coinText;
    int currentCoin=0;
    TextMeshProUGUI scoreText;
    float currentScore=0;
    float targetScore = 0;
    float minScoreUpSpeed = 3;
    TextMeshProUGUI jewelText;
    AttackButton attackButton;

    GuardButton guardButton;
    Image guardButtonImage;
    float guardCooltimeCurrent;

    JumpButton jumpButton;
    Slider prograssBar;
    float currentPrograssValue=0;
    float targetPrograssValue=0;

    TextMeshProUGUI stage;

    Button nextStageButton;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        FindComponent();
    }
    void FindComponent()
    {
        jumpButton = canvas.transform.GetChild(0).GetChild(0).GetComponent<JumpButton>();
        guardButton = canvas.transform.GetChild(0).GetChild(1).GetComponent<GuardButton>();
        guardButtonImage = canvas.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        attackButton = canvas.transform.GetChild(0).GetChild(2).GetComponent<AttackButton>();

        Pause = canvas.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        heartText = canvas.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        scoreText = canvas.transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();
        coinText = canvas.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        jewelText = canvas.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();

        prograssBar = canvas.transform.GetChild(2).GetComponent<Slider>();

        stage = canvas.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        nextStageButton = canvas.transform.GetChild(4).GetComponent<Button>();
    }
    private void Start()
    {
        UiInitialize();
    }
    void UiInitialize()
    {
        heartText.text = heartTexts[3];

        scoreText.text = "0";
        currentScore = 0;
        coinText.text = "0";
        currentCoin = 0;
        jewelText.text = "0";
    }
    private void Update()
    {

        //Score 점진적 Update
        if (currentScore < targetScore)
        {
            float speed = Mathf.Max( (float)(targetScore - currentScore) * 5.0f, minScoreUpSpeed);
            currentScore += Time.deltaTime * speed;

            currentScore = Mathf.Min(currentScore, targetScore); 
            scoreText.text = $"{currentScore:f0}"; 
        }
        if (currentPrograssValue < targetPrograssValue)
        {
            prograssBar.value = Mathf.Lerp(currentPrograssValue, targetPrograssValue, Time.deltaTime * 2);
            currentPrograssValue = prograssBar.value;
        }

    }

    public void UiHeartUpdate(int value)
    {
        if (value < 0)
            Debug.LogWarning("Heart는 0보다 작아질 수 없습니다");
        else if(value>3)
            Debug.LogWarning("Heart는 3보다 커질 수 없습니다");
        else
            heartText.text = heartTexts[value];
    }
    public void UiScoreUpdate(int value)
    {
        targetScore += value;
        scoreText.text = targetScore.ToString();
    }
    public void UiCoinUpdate(int value)
    {
        currentCoin += value;
        coinText.text = currentCoin.ToString();
    }
    public void UiStageUpdate(int value)
    {
        stage.text = $"Stage : {value}";
    }
    public void UiPrograssUpdate(float value)
    {
        targetPrograssValue = value;
        if(value==0)
        {
            prograssBar.value = 0;
            currentPrograssValue = 0;
            
        }
    }

    public void UiGuardCoolTimeEffect(float cooltime)
    {
        StartCoroutine(UiGuardCoolTime(cooltime));
    }
    IEnumerator UiGuardCoolTime(float cooltime)
    {
        //참고사이트 : https://wergia.tistory.com/223
        Debug.Log($"Guard Colltime Effect! / cooltime : {cooltime}");
        //raycast Target을 끔으로써 버튼의 클릭유무를 조정할 것.
        guardButtonImage.raycastTarget = false;

        guardCooltimeCurrent = cooltime;
        //float fillAmount = cooltime /

        guardButtonImage.fillAmount = 0;

        while (guardCooltimeCurrent > 0f)
        {
            guardCooltimeCurrent -= Time.deltaTime;

            float fillAmount = 1f - (guardCooltimeCurrent / cooltime);
            guardButtonImage.fillAmount = fillAmount;

            /*
            float fillAmount = guardCooltimeCurrent / cooltime;
            float angle = 360f * (1f - fillAmount);
            guardButtonImage.fillAmount = fillAmount;
            guardButtonImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);*/

            yield return null;
        }

        guardButtonImage.raycastTarget = true;
        Debug.Log("Guard Colltime Effect End!");
    }

    public void NextStageReady()
    {
        nextStageButton.gameObject.SetActive(true);
    }

    
}
