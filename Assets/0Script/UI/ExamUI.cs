using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ExamQuestion{

    public Image question;
    public string answer;
    public bool isHold;
    public bool isCorrect;
    public int fullScore;

}

public class ExamUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Button previousButton;
    private Button nextButton;
    private Button submitButton;
    public InputField answerInput;
    public List<ExamQuestion> questions;
    private int currentQuestion = 0;
    void Start()
    {
        answerInput = transform.Find("Image/AnswerInput").GetComponent<InputField>();
        previousButton = transform.Find("Image/PreviousButton").GetComponent<Button>();
        nextButton = transform.Find("Image/NextButton").GetComponent<Button>();
        submitButton = transform.Find("Image/SubmitButton").GetComponent<Button>();
        previousButton.onClick.AddListener(this.PreviousQuestion);
        nextButton.onClick.AddListener(this.NextQuestion);
        submitButton.onClick.AddListener(this.Submit);
        
    }

    // Update is called once per frame
    public void ShowQuestion(){
        gameObject.SetActive(true);
        
    }
    public void Show(){}
    public void PreviousQuestion(){
        if(currentQuestion > 0){
            currentQuestion--;
        }
    }
    public void NextQuestion(){
        if(currentQuestion < questions.Count-1){
            currentQuestion++;
        }
    }
    public void Submit(){
        if(questions[currentQuestion].isHold) return;
        questions[currentQuestion].isHold = true;
        questions[currentQuestion].isCorrect = (answerInput.text == questions[currentQuestion].answer);
    }

}
