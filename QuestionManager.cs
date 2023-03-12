using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{

    public Questionaire questionaire;
    public GameObject q;
    public GameObject a;
    public int[] qaArr;
    public int currentQuestion = 0;
    public GameObject AnswerPanel;
    // Start is called before the first frame update
    void Awake()
    {
         q = transform.Find("Question").gameObject;

         a = transform.Find("Answer").gameObject;

        qaArr = new int[questionaire.Questions.Length];
    }

    public void OnEnable()
    {
        currentQuestion = 0;
        AssignQuestion(questionaire.Questions[currentQuestion]);
        AnswerPanel.SetActive(false);
    }

    public void AssignQuestion(Questionaire.Question quest)
    {
        GetComponentInChildren<ToggleGroup>().SetAllTogglesOff();
        //q.GetComponent<Text>().text = quest.question;
        q.GetComponent<LocalizeStringEvent>().StringReference.SetReference("en fi", quest.question);



        for (int i = 0; i < a.transform.childCount; i++)
        {
            if (i >= quest.Answers.Length)
            {
                a.transform.GetChild(i).gameObject.SetActive(false);

            }

            else 
            {
                a.transform.GetChild(i).gameObject.SetActive(true);
                //a.transform.GetChild(i).GetComponentInChildren<Text>().text = quest.Answers[i].answer;
                a.transform.GetChild(i).GetComponentInChildren<LocalizeStringEvent>().StringReference.SetReference("en fi", quest.Answers[i].answer);

            }
        }

    }

    public void Submit()
    {
        if (!GetComponentInChildren<ToggleGroup>().AnyTogglesOn())
            return;     
            qaArr[currentQuestion] = ReadQuestionAndAnswer();
        currentQuestion++;
           
        if(currentQuestion < questionaire.Questions.Length)
        {
            AssignQuestion(questionaire.Questions[currentQuestion]);
        }
        else
        {
            DisplayResult();
        }
        
    }

    int ReadQuestionAndAnswer()
    {


     

        //result. Question = q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>() != null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    return i;
                }
            }
        }
        
        return -1;
    }

    void DisplayResult()
    {


        string s = "Congratulations your style is ";

        /* for (int i = 0; i < qaArr.Length; i++)
         {
             s = s + qaArr[i].Question + "\n";
             int counter = 0;

             for (int j = 0; j < qaArr[i].Answer.Length; j++)
             {
                 if (counter != 0)
                 {
                     s = s + ", ";
                 }
                 s = s + qaArr[i].Answer[j];
                 counter++;
             }
         }
        */
        int[] results = new int[6];
        for (int i = 0; i < questionaire.Questions.Length; i++)
                for (int k = 0; k < questionaire.Questions[i].Answers[qaArr[i]].Changes.Length; k++)
                    results[(int)questionaire.Questions[i].Answers[qaArr[i]].Changes[k]]++;

        int answer = 0;
        int value = 0;
        for (int k = 0; k < results.Length; k++)
        {
            if (results[k] > value)
            {
                value = results[k];
                answer = k;
            }
        }
        AnswerPanel.SetActive(true);
        AnswerPanel.transform.Find("Answer").GetComponent<Text>().text = s + (UIScript07.styles)answer;
         LoadingScene.main.LoadUnloadScene(LoadingScene.main.CCScene);
    }

    public enum styles
    {
        anime = 0,
        pixel = 1,
        vector = 2,
        indie = 3,
        lowblock = 4,
        realism = 5,

    }

    
}
