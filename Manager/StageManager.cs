using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCreator{
    private int randomMin = GameManager.instance.DecimalMin;
    private int randomMax = GameManager.instance.DeciamlMax;

    private int questionValue;
    
    // 정답
    private int correctAnswerValue;

    public int QuestionValue {get => questionValue;}
    public int CorrectAnswerValue {get => correctAnswerValue;}
    
    // 문제가 Binary 정답이 Decimal
    public void QuestionBinaryToDecimal(){
        int randomValue = Random.Range(randomMin, randomMax);

        questionValue = Conversioner.DecimalToBinary(randomValue);
        correctAnswerValue = randomValue;   
    }


    // 문제가 Deciaml 정답이 Binary
    public void QuestionDecimalToBinary(){
        int randomValue = Random.Range(randomMin, randomMax);

        questionValue = randomValue;
        correctAnswerValue = Conversioner.DecimalToBinary(randomValue);
    }
}

public class StageManager : MonoBehaviour
{

    public static StageManager instance = null;
    
    [SerializeField]
    private Text questionText;
    
    [SerializeField]
    private InputField answerField;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Image timerImage;

    [SerializeField]
    private int timerSpeed;

    private QuestionCreator questionCreator;

    private delegate void QuestionDelegate();
    private QuestionDelegate questionDelegate;

    private int score;

    public int Score {
        get => score;
        set {
            score = value;
            ScoreText.text = score.ToString();
        }    
        
    }

    // 플레이어가 제출한 정답
    private int answerValue;
    
    private void Start(){
        
        questionCreator = new QuestionCreator();

        if(GameManager.instance.GameCode.Equals(0))
            questionDelegate = questionCreator.QuestionDecimalToBinary;
        else
            questionDelegate = questionCreator.QuestionBinaryToDecimal;

        QuestionSetting();
    }

    private void Update(){
        if(timerImage.fillAmount + (Time.deltaTime / timerSpeed) >= 1.0f){
            AnswerCheck();
        }else{
            timerImage.fillAmount += (Time.deltaTime / timerSpeed);
        }

        if(Input.GetKeyDown(KeyCode.LeftCommand))
            AnswerCheck();
    }

    private void QuestionSetting(){
        timerImage.fillAmount = 0f;
        questionDelegate();
        questionText.text = questionCreator.QuestionValue.ToString();
    }


    private void AnswerCheck(){

        answerValue = int.Parse(answerField.text != "" ? answerField.text : 0.ToString()); 
        
        
        if(answerValue.Equals(questionCreator.CorrectAnswerValue))
            Score++;

        QuestionSetting();
    }
}
