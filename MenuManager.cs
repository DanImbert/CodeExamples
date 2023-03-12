using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class MenuManager : MonoBehaviour
{
   
    
    



     

    public void Skip()
    {
        LoadingScene.main.LoadUnloadScene(LoadingScene.main.CCScene);
    }

    public void Home()
    {
        LoadingScene.main.LoadUnloadScene(LoadingScene.main.QuestionScene);
    }

    public void ResetQuestionaire()
    {
        GameObject.FindObjectOfType<QuestionManager>().OnEnable();
    }

    public void SendtoServer()
    {
        LoadingScene.main.LoadUnloadScene(LoadingScene.main.ServerScene);
    }

}