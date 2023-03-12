using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartSelector : MonoBehaviour
{
    enum bodyParts
    {
        head, torso, leg
    }
    // Head part array
    public GameObject head;

    // Torso part game objects
    //public GameObject torso;
    public GameObject body;
    public GameObject r_UpperArm;
    public GameObject r_LowerArm;
    public GameObject r_Arm;
    public GameObject l_UpperArm;
    public GameObject l_LowerArm;
    public GameObject l_Arm;

    //Legs part array
    //public GameObject leg;
    public GameObject r_UpperLeg;
    public GameObject r_LowerLeg;
    public GameObject r_Foot;
    public GameObject l_UpperLeg;
    public GameObject l_LowerLeg;
    public GameObject l_Foot;

    //private GameObject selectedPartObject;

    //private Sprite[] SelectedPartSprite;
    public ScriptablesSprite  heads;


    // public Sprite[] torsos;
    public ScriptablesSprite bodies;
    public ScriptablesSprite r_UpperArms;
    public ScriptablesSprite r_LowerArms;
    public ScriptablesSprite r_Arms;
    public ScriptablesSprite l_UpperArms;
    public ScriptablesSprite l_LowerArms;
    public ScriptablesSprite l_Arms;

    // public Sprite[] legs
    public ScriptablesSprite r_UpperLegs;
    public ScriptablesSprite r_LowerLegs;
    public ScriptablesSprite r_Feet;
    public ScriptablesSprite l_UpperLegs;
    public ScriptablesSprite l_LowerLegs;
    public ScriptablesSprite l_Feet;

    //private bodyParts partIndex = 0;
    // //private int tempIndex;
    
    // ***** Remember to change the index to the selected character from the qwuestionaire ****

    public static int headIndex = 2;

    // Torsos arrays
    public static int bodyIndex = 2;
    public static int r_UpperArmIndex = 2;
    public static int r_LowerArmIndex = 2;
    public static int r_ArmIndex = 2;
    public static int l_UpperArmIndex = 2;
    public static int l_LowerArmIndex = 2;
    public static int l_ArmIndex = 2;


    // Legs arrays
    public static int r_UpperLegIndex = 2;
    public static int r_LowerLegIndex = 2;
    public static int r_FootIndex = 2;
    public static int l_UpperLegIndex = 2;
    public static int l_LowerLegIndex = 2;
    public static int l_FootIndex = 2;


    public PlayFabManager playFabManager;
    public string kpasa;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing Head
        head.GetComponent<SpriteRenderer>().sprite = heads.Sprites[headIndex];

        // Initializing Torsos
        body.GetComponent<SpriteRenderer>().sprite = bodies.Sprites[bodyIndex];
        r_UpperArm.GetComponent<SpriteRenderer>().sprite = r_UpperArms.Sprites[r_UpperArmIndex];
        r_LowerArm.GetComponent<SpriteRenderer>().sprite = r_LowerArms.Sprites[r_LowerArmIndex];
        r_Arm.GetComponent<SpriteRenderer>().sprite = r_Arms.Sprites[r_ArmIndex];
        l_UpperArm.GetComponent<SpriteRenderer>().sprite = l_UpperArms.Sprites[l_UpperArmIndex];
        l_LowerArm.GetComponent<SpriteRenderer>().sprite = l_LowerArms.Sprites[l_LowerArmIndex];
        l_Arm.GetComponent<SpriteRenderer>().sprite = l_Arms.Sprites[l_ArmIndex];

        // Initializing Legs
        r_UpperLeg.GetComponent<SpriteRenderer>().sprite = r_UpperLegs.Sprites[r_UpperLegIndex];
        r_LowerLeg.GetComponent<SpriteRenderer>().sprite = r_LowerLegs.Sprites[r_LowerLegIndex];
        r_Foot.GetComponent<SpriteRenderer>().sprite = r_Feet.Sprites[r_FootIndex];
        l_UpperLeg.GetComponent<SpriteRenderer>().sprite = l_UpperLegs.Sprites[l_UpperLegIndex];
        l_LowerLeg.GetComponent<SpriteRenderer>().sprite = l_LowerLegs.Sprites[l_LowerLegIndex];
        l_Foot.GetComponent<SpriteRenderer>().sprite = l_Feet.Sprites[l_FootIndex];

        //PartSelectorTorso();
    }
        
    public void PartSelectorHead(int direction)
    {
        //SelectedPartSprite = heads;
        //selectedPartObject = head;
        //partIndex = bodyParts.head;
        //Debug.Log("Head selected");

        headIndex = (headIndex + direction) % heads.Sprites.Length;
        if (headIndex < 0)
        {
            headIndex += heads.Sprites.Length;            
        }

        head.GetComponent<SpriteRenderer>().sprite = heads.Sprites[headIndex];
        

        // Playfab
        kpasa = headIndex.ToString();
        playFabManager.HeadIndex(kpasa);
    }
    public void PartSelectorLeg(int direction)
    {
        /*SelectedPartSprite = legs;
        selectedPartObject = leg;
        partIndex = bodyParts.leg;
        Debug.Log("Leg selected");*/
        //legIndex = (legIndex + direction) % legs.Length;

        r_UpperLegIndex = (r_UpperLegIndex + direction) % r_UpperLegs.Sprites.Length;
        r_LowerLegIndex = (r_LowerLegIndex + direction) % r_LowerLegs.Sprites.Length;
        r_FootIndex = (r_FootIndex + direction) % r_Feet.Sprites.Length;
        l_UpperLegIndex = (l_UpperLegIndex + direction) % l_UpperLegs.Sprites.Length;
        l_LowerLegIndex = (l_LowerLegIndex + direction) % l_LowerLegs.Sprites.Length;
        l_FootIndex = (l_FootIndex + direction) % l_Feet.Sprites.Length;

        if (r_UpperLegIndex < 0)
        {
            r_UpperLegIndex += r_UpperLegs.Sprites.Length;
            r_LowerLegIndex += r_LowerLegs.Sprites.Length;
            r_FootIndex += r_Feet.Sprites.Length;
            l_UpperLegIndex += l_UpperLegs.Sprites.Length;
            l_LowerLegIndex += l_LowerLegs.Sprites.Length;
            l_FootIndex += l_Feet.Sprites.Length;
        }


        //leg.GetComponent<SpriteRenderer>().sprite = legs[legIndex];
        r_UpperLeg.GetComponent<SpriteRenderer>().sprite = r_UpperLegs.Sprites[r_UpperLegIndex];
        r_LowerLeg.GetComponent<SpriteRenderer>().sprite = r_LowerLegs.Sprites[r_LowerLegIndex];
        r_Foot.GetComponent<SpriteRenderer>().sprite = r_Feet.Sprites[r_FootIndex];
        l_UpperLeg.GetComponent<SpriteRenderer>().sprite = l_UpperLegs.Sprites[l_UpperLegIndex];
        l_LowerLeg.GetComponent<SpriteRenderer>().sprite = l_LowerLegs.Sprites[l_LowerLegIndex];
        l_Foot.GetComponent<SpriteRenderer>().sprite = l_Feet.Sprites[l_FootIndex];

    }

    public void PartSelectorTorso(int direction)
    {
        /*SelectedPartSprite = torsos;
        selectedPartObject = torso;
        partIndex = bodyParts.torso;
        Debug.Log("Torso selected");*/
        //torsoIndex = (torsoIndex + direction) % torsos.Length;

        bodyIndex = (bodyIndex + direction) % bodies.Sprites.Length;
        r_UpperArmIndex = (r_UpperArmIndex + direction) % r_UpperArms.Sprites.Length;
        r_LowerArmIndex = (r_LowerArmIndex + direction) % r_LowerArms.Sprites.Length;
        r_ArmIndex = (r_ArmIndex + direction) % r_Arms.Sprites.Length;
        l_UpperArmIndex = (l_UpperArmIndex + direction) % l_UpperArms.Sprites.Length;
        l_LowerArmIndex = (l_LowerArmIndex + direction) % l_LowerArms.Sprites.Length;
        l_ArmIndex = (l_ArmIndex + direction) % l_Arms.Sprites.Length;

        if (bodyIndex < 0)
        {
            //torsoIndex += torsos.Length;
            bodyIndex = bodies.Sprites.Length;
            r_UpperArmIndex = r_UpperArms.Sprites.Length;
            r_LowerArmIndex = r_LowerArms.Sprites.Length;
            r_ArmIndex = r_Arms.Sprites.Length;
            l_UpperArmIndex = l_UpperArms.Sprites.Length;
            l_LowerArmIndex = l_LowerArms.Sprites.Length;
            l_ArmIndex = l_Arms.Sprites.Length;

        }
        //torso.GetComponent<SpriteRenderer>().sprite = torsos[torsoIndex];
        body.GetComponent<SpriteRenderer>().sprite = bodies.Sprites[bodyIndex];
        r_UpperArm.GetComponent<SpriteRenderer>().sprite = r_UpperArms.Sprites[r_UpperArmIndex];
        r_LowerArm.GetComponent<SpriteRenderer>().sprite = r_LowerArms.Sprites[r_LowerArmIndex];
        r_Arm.GetComponent<SpriteRenderer>().sprite = r_Arms.Sprites[r_ArmIndex];
        l_UpperArm.GetComponent<SpriteRenderer>().sprite = l_UpperArms.Sprites[l_UpperArmIndex];
        l_LowerArm.GetComponent<SpriteRenderer>().sprite = l_LowerArms.Sprites[l_LowerArmIndex];
        l_Arm.GetComponent<SpriteRenderer>().sprite = l_Arms.Sprites[l_ArmIndex];
    }

    public void ReceiveData(string headData)//, string torsoData, string legsData )
    {
        headIndex = int.Parse(headData);
        //bodyIndex = r_UpperArmIndex = r_LowerArmIndex = r_ArmIndex = l_UpperArmIndex = l_LowerArmIndex = l_ArmIndex = int.Parse(torsoData);
        //r_UpperLegIndex = r_LowerLegIndex = r_FootIndex = l_UpperLegIndex = l_LowerLegIndex = l_FootIndex = int.Parse(legsData);
        
        // Head
        head.GetComponent<SpriteRenderer>().sprite = heads.Sprites[headIndex];

        /*
        // Torsos
        body.GetComponent<SpriteRenderer>().sprite = bodies[bodyIndex];
        r_UpperArm.GetComponent<SpriteRenderer>().sprite = r_UpperArms[r_UpperArmIndex];
        r_LowerArm.GetComponent<SpriteRenderer>().sprite = r_LowerArms[r_LowerArmIndex];
        r_Arm.GetComponent<SpriteRenderer>().sprite = r_Arms[r_ArmIndex];
        l_UpperArm.GetComponent<SpriteRenderer>().sprite = l_UpperArms[l_UpperArmIndex];
        l_LowerArm.GetComponent<SpriteRenderer>().sprite = l_LowerArms[l_LowerArmIndex];
        l_Arm.GetComponent<SpriteRenderer>().sprite = l_Arms[l_ArmIndex];

        // Legs
        r_UpperLeg.GetComponent<SpriteRenderer>().sprite = r_UpperLegs[r_UpperLegIndex];
        r_LowerLeg.GetComponent<SpriteRenderer>().sprite = r_LowerLegs[r_LowerLegIndex];
        r_Foot.GetComponent<SpriteRenderer>().sprite = r_Feet[r_FootIndex];
        l_UpperLeg.GetComponent<SpriteRenderer>().sprite = l_UpperLegs[l_UpperLegIndex];
        l_LowerLeg.GetComponent<SpriteRenderer>().sprite = l_LowerLegs[l_LowerLegIndex];
        l_Foot.GetComponent<SpriteRenderer>().sprite = l_Feet[l_FootIndex];
        */

    }

    
    
    /*
    public void Change(int direction)
    {
        switch (partIndex)
        {
            case bodyParts.head:
                headIndex = (headIndex + direction) % heads.Length;
                if (headIndex < 0)
                {
                    headIndex += heads.Length;
                }
                head.GetComponent<SpriteRenderer>().sprite = heads[headIndex];
                break;
            case bodyParts.torso:
                torsoIndex = (torsoIndex + direction) % torsos.Length;
                if (torsoIndex < 0)
                {
                    torsoIndex += torsos.Length;
                }
                torso.GetComponent<SpriteRenderer>().sprite = torsos[torsoIndex];
                break;
            case bodyParts.leg:
                legIndex = (legIndex + direction) % legs.Length;
                if (legIndex < 0)
                {
                    legIndex += legs.Length;
                }
                leg.GetComponent<SpriteRenderer>().sprite = legs[legIndex];
                break;
            default:
                break;
        }
    }
    */
    
    /*
    private void UpdateIndex(int currentIndex)
    {
        if (gameObject.tag == "HeadSelected")
        {
            Debug.Log("OLD Head index: " + headIndex);            
            headIndex = currentIndex;
            Debug.Log("NEW Head index: " + headIndex);
        }
        else if (gameObject.tag == "LegSelected")
        {
            Debug.Log("OLD Leg index: " + legIndex);
            legIndex = currentIndex;
            Debug.Log("OLD Leg index: " + legIndex);
        }
        else
        {
            Debug.Log("OLD Torso index: " + torsoIndex);
            torsoIndex = currentIndex;
            Debug.Log("OLD Torso index: " + torsoIndex);
        }
    }
    */
}
