using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BodyPartSwitch : MonoBehaviour
{
    [SerializeField] BodyParts[] bodyParts; // an array for groups body parts
    [SerializeField] string[] labels; // an array for different characters
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].Init(labels);
        }
    }

    [System.Serializable]
    public class BodyParts
    {
        [SerializeField] Button buttonRight;
        [SerializeField] Button buttonLeft;
        [SerializeField] VirtualDpad left;
        [SerializeField] VirtualDpad right;

        [SerializeField] SpriteResolver[] spriteResolver; // an array for a body part groups Sprite Resolver(s)
        public int id;

        public SpriteResolver[] SpriteResolver { get => spriteResolver; }

        public void Init(string[] labels)
        {
            buttonRight.onClick.AddListener(delegate { ChangePartsToRight(labels); }); // button click triggers ChangeParts            
            buttonLeft.onClick.AddListener(delegate { ChangePartsToLeft(labels); });
           // right.direction.AddListener(delegate { ChangePartsToRight(labels); }); // button click triggers ChangeParts            
           // left.onClick.AddListener(delegate { ChangePartsToLeft(labels); });
        }

        public void ChangePartsToRight(string[] labels)
        {
            id++;
            id %= labels.Length; // prevents array from getting out of index 

            foreach (var item in spriteResolver)
            {
                //Debug.Log(item.GetCategory() + " " + labels[id] + " " + id);
                item.SetCategoryAndLabel(item.GetCategory(), labels[id]);
            }
        }

        public void ChangePartsToLeft(string[] labels)
        {
            id--;
            if (id < 0)
            {
                id = labels.Length - 1;
            }

            foreach (var item in spriteResolver)
            {
                //Debug.Log(item.GetCategory() + " " + labels[id] + " " + id);
                item.SetCategoryAndLabel(item.GetCategory(), labels[id]);
            }
        }

        public void Confirm()
        {
            PlayerPrefs.SetInt("CharacterSelected", id);
            SceneManager.LoadScene("ServerScreenBuild");
           // PlayerPrefs.GetString("username");

        }
    }

}