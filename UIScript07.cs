using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class UIScript07 : MonoBehaviour
{

    public GameObject[] questionGroupArr;
    public int [] qaArr;
    public GameObject AnswerPanel;
    // Start is called before the first frame update
    void Start()
    {
        qaArr = new int[questionGroupArr.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswer()
    {
        for(int i = 0; i < qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAndAnswer(questionGroupArr[i]);
        }

       // DisplayResult();
    }

   

    int ReadQuestionAndAnswer ( GameObject questionGroup)
    { 
        

        GameObject q= questionGroup.transform.Find("Question").gameObject;
    
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

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
       /* else if (a.GetComponent<InputField>() != null)
        {
           // Answers.Add(a.transform.Find("Text").GetComponent<Text>().text);
        }
       

        else if (a.GetComponent<ToggleGroup>() == null && a.GetComponent<InputField>() == null)

        {
            string s  = "";
           
                
           // int counter = 0;


          /*  for (int i = 0; i < a.transform.childCount; i++)
            {
                
                

               

                Answers.Add(a.transform.GetChild(i).Find("Label").GetComponent<Text>().text);
                



                if (i == a.transform.childCount - 1)
                {
                    s = s + ", ";
                }

            }



        }
        result.Answer = Answers.ToArray();

            */
        return -1;  
    }

  /*  void DisplayResult()
    {
        AnswerPanel.SetActive(true);


        string s = "";

        for (int i = 0; i < qaArr.Length; i++)
        {
            s = s + qaArr[i].Question + "\n";
            int counter = 0;

            for (int j = 0; j < qaArr[i].Answer.Length; j++)
            { 
            if (counter != 0)
            {
                s = s + ", ";
            }
                s = s + qaArr[i].Answer [j];
            counter++;
        }
     }

        AnswerPanel.transform.Find("Answer").GetComponent<Text>().text = s;

    }


  */






   /* styles StyleChoice (QAClass07[]qAClass07s)
    {
        foreach(QAClass07 question in qAClass07s)
        {
            foreach()
            {

            }
        }

       
    }
   */
    

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

[System.Serializable]
public class QAClass07
{
    public string Question = "";
    public string []Answer;

}

