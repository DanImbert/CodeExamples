using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "scriptables/questionaire")]
public class Questionaire : ScriptableObject
{
    public Question[] Questions;
    [System.Serializable]

    public class Question
    {
        public string question;
        public Answer[] Answers;

        [System.Serializable]
        public class Answer
        {
            public string answer;
            public UIScript07.styles[] Changes;
        }
    }



}
