using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharBehaviour))]
public class CharEditor : Editor
{

    //Start: General
    string[] kitName = { "Movement", "Atack" };
    int currentTab;

    CharBehaviour script;
    //End: General

    //Start: Movement
    public enum colliderChoice { Single, Multiple }
    public colliderChoice cc;
    public GameObject scriptLocation;
    //End: Movement

    public override void OnInspectorGUI()
    {

        script = (CharBehaviour)target;

        //Start: Help Box
        EditorGUILayout.Space(10f);
        EditorGUILayout.HelpBox("Make sure that the Game Object has Rigidbody2D, Collider2D & Sprite Renderer for script operation.", MessageType.Warning);
        //End: Help Box
        
        ModifyKits();

    }

    public void ModifyKits()
    {

        //Start: Where it is defined which kit will be configured
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("Choose the Kit", EditorStyles.boldLabel);
        currentTab = GUILayout.Toolbar(currentTab, kitName);

        switch (currentTab) {

            case 0:

                MovementKit();

                break;

            case 1:

                AttackKit();

                break;

        }
        //End: Where it is defined which kit will be configured

    }

    public void AttackKit() {

        //Session: Start Kit
        if (!Application.isPlaying) { 

            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField("Activate or Disable Attack", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            string stateKit = script.attack ? "On" : "Off";
            EditorGUILayout.LabelField("The attack kit is : " + stateKit, GUILayout.Width(150f));

            if (GUILayout.Button((script.attack ? "Disable" : "Activate"), GUILayout.ExpandWidth(true))) script.attack = !script.attack;

            EditorGUILayout.EndHorizontal();


            if (GUILayout.Button(("Open attack reference"), GUILayout.ExpandWidth(true))) {

                Application.OpenURL("https://answers.unity.com/questions/21261/can-i-place-a-link-such-as-a-href-into-the-guilabe.html");

            }

        }

        //End of Session
        //Session: Attack variables

        if (script.attack) {

            

        }
        else {

            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField("Activate the attack kit to set variables");
            EditorGUILayout.Space(20f);

        }

        //End of Session

    }

    public void MovementKit() {

        //Session: Start Kit
        if (!Application.isPlaying) {

            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField("Activate or Disable Movement", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            string stateMovement = script.movement ? "On" : "Off";
            EditorGUILayout.LabelField("The movement kit is : " + stateMovement, GUILayout.Width(150f));

            if (GUILayout.Button((script.movement ? "Disable" : "Activate"), GUILayout.ExpandWidth(true))) script.movement = !script.movement;

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button(("Open movement reference"), GUILayout.ExpandWidth(true))) {

                Application.OpenURL("https://answers.unity.com/questions/21261/can-i-place-a-link-such-as-a-href-into-the-guilabe.html");

            }
        }

        //End of Session
        //Session: Movement variables

        if (script.movement) {

            
            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField("General Settings", EditorStyles.boldLabel);
            
            //Start: Colliders
            cc = (colliderChoice)EditorGUILayout.EnumPopup("Number of colliders", cc);
            
            if(cc == colliderChoice.Multiple) {

                

            }
            else {

                //scriptLocation = (GameObject)EditorGUILayout.ObjectField("Script Location", scriptLocation, typeof(GameObject), true);

            }
            //End: Colliders

        }
        else {

            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField("Activate the movement kit to set variables");
            EditorGUILayout.Space(20f);

        }

        //End of Session

    }

}