using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CharBehaviour))]
public class CharEditor : Editor
{

    //Start: General
    string[] kitName = { "Movement", "Atack", "Status", "Controls" };
    string lastObject; int currentTab;

    CharBehaviour script;
    //End: General

    //Start: Movement
    public bool configMovement, wrc, jump;
    int canMovement, canRun, canCrouch, canJump, movementInAir, bigJump, wallJump, doubleJump, soar;
    string[] onOff = { "On", "Off" };
    //End: Movement

    private void OnEnable() {

        //Foldout starts as it ended.
        int intWRC = PlayerPrefs.GetInt("wrc");
        if (intWRC == 0) wrc = false;
        else if(intWRC == 1) wrc = true;

        int intJump = PlayerPrefs.GetInt("jump");
        if (intJump == 0) jump = false;
        else if (intJump == 1) jump = true;

    }

    public override void OnInspectorGUI()
    {

        script = (CharBehaviour)target;

        if (EditorApplication.isPlaying) Repaint();

        //Start: Help Box
        EditorGUILayout.Space(10f);
        EditorGUILayout.HelpBox("Make sure that the Game Object has Rigidbody2D, Collider2D & Sprite Renderer for script operation.", MessageType.Warning);
        //End: Help Box

        ModifyKits();

    }

    public void ModifyKits()
    {

        //Start: Where it is defined which kit will be configured
        if (Application.isPlaying) { 

            EditorGUILayout.Space(10f);
            script.kit.viewGame = (Kit.ViewGame)EditorGUILayout.EnumPopup("Perspective", script.kit.viewGame);
        
        }

        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("Choose the Kit", EditorStyles.boldLabel);
        
        lastObject = PlayerPrefs.GetString("lastObjectFM2D");
        if (lastObject == script.gameObject.name) currentTab = PlayerPrefs.GetInt("lastTabFM2D");
        currentTab = GUILayout.Toolbar(currentTab, kitName);
        
        PlayerPrefs.SetInt("lastTabFM2D", currentTab); PlayerPrefs.SetString("lastObjectFM2D", script.gameObject.name);
        PlayerPrefs.Save();

        switch (currentTab) {

            case 0:

                MovementKit();

                break;

            case 1:

                AttackKit();

                break;

            case 2:

                StatusKit();

                break;

            case 3:

                ControlsKit();

                break;

        }
        //End: Where it is defined which kit will be configured

    }

    public void AttackKit() {
        
        EditorGUILayout.Space(2f);
        if (GUILayout.Button(("Open attack reference"), GUILayout.ExpandWidth(true))) {

            Application.OpenURL("https://answers.unity.com/questions/21261/can-i-place-a-link-such-as-a-href-into-the-guilabe.html");

        }

        //Session: Start Kit
        if (!Application.isPlaying) { 

            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField("Activate or Disable Attack", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

                string stateKit = script.attack ? "On" : "Off";
                EditorGUILayout.LabelField("The attack kit is : " + stateKit, GUILayout.Width(150f));

                if (GUILayout.Button((script.attack ? "Disable" : "Activate"), GUILayout.ExpandWidth(true))) {

                    script.attack = !script.attack;
                    EditorApplication.isPlaying = true; EditorApplication.isPlaying = false;

                }

            EditorGUILayout.EndHorizontal();

        }

        //End of Session
        //Session: Attack variables

        if (script.attack) {

            

        }
        else {

            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField(Application.isPlaying ? "Stop the game and activate the attack kit to set variables" : "Activate the attack kit to set variables");
            EditorGUILayout.Space(20f);

        }

        //End of Session

    }

    public void MovementKit() {

        EditorGUILayout.Space(2f);
        if (GUILayout.Button(("Open movement reference"), GUILayout.ExpandWidth(true))) {

            Application.OpenURL("https://answers.unity.com/questions/21261/can-i-place-a-link-such-as-a-href-into-the-guilabe.html");

        }

        //Session: Start Kit
        if (!Application.isPlaying) {

            EditorGUILayout.Space(10f);
            EditorGUILayout.LabelField("Activate or Disable Movement", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            string stateMovement = script.movement ? "On" : "Off";
            EditorGUILayout.LabelField("The movement kit is : " + stateMovement, GUILayout.Width(150f));

            if (GUILayout.Button((script.movement ? "Disable" : "Activate"), GUILayout.ExpandWidth(true))) {

                script.movement = !script.movement;
                EditorApplication.isPlaying = true; EditorApplication.isPlaying = false;

            }

            EditorGUILayout.EndHorizontal();

        }

        //End of Session
        //Session: Movement variables

        if (script.movement && script.kitMovement != null) {

            //Start: Walk, Run and Crouch
            EditorGUILayout.Space(1f);
            if (wrc = EditorGUILayout.Foldout(wrc, "Walk, Run and Crouch", true, EditorStyles.foldoutHeader)) {
            
                PlayerPrefs.SetInt("wrc", wrc ? 1 : 0); PlayerPrefs.Save();

                //Start: Can Movement
                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Walk", GUILayout.Width(150f));

                    canMovement = script.kitMovement.canMovement ? 0 : 1;
                    canMovement = GUILayout.Toolbar(canMovement, onOff);

                    switch (canMovement) {

                        case 0:

                            script.kitMovement.canMovement = true;

                            break;

                        case 1:

                            script.kitMovement.canMovement = false;

                            break;
                    }

                EditorGUILayout.EndHorizontal();
                //End: Can Movement
                //Start: Can Run
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Run", GUILayout.Width(150f));

                    canRun = script.kitMovement.canRun ? 0 : 1;
                    canRun = GUILayout.Toolbar(canRun, onOff);

                    switch (canRun) {

                        case 0:

                            script.kitMovement.canRun = true;

                            break;

                        case 1:

                            script.kitMovement.canRun = false;

                            break;
                    }

                EditorGUILayout.EndHorizontal();
                //End: Can Run
                //Start: Can Crouch
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Crouch", GUILayout.Width(150f));

                    canCrouch = script.kitMovement.canCrouch ? 0 : 1;
                    canCrouch = GUILayout.Toolbar(canCrouch, onOff);

                    switch (canCrouch) {

                        case 0:

                            script.kitMovement.canCrouch = true;

                            break;

                        case 1:

                            script.kitMovement.canCrouch = false;

                            break;
                    }

                EditorGUILayout.EndHorizontal();
                //End: Can Crouch
                //Start: Walk and Run Collider
                if (script.kitMovement.canMovement) {

                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField(script.kitMovement.canRun ? "Walk and Run: Collider" : "Walk: Collider", GUILayout.Width(150f));
                    script.kitMovement.walkCollider = (Collider2D)EditorGUILayout.ObjectField(script.kitMovement.walkCollider, typeof(Collider2D), true, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                }
                //End: Walk and Run Collider
                //Start: Crouch Collider
                if (script.kitMovement.canCrouch) { 

                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Crouch: Collider", GUILayout.Width(150f));
                    script.kitMovement.CrouchCollider = (Collider2D)EditorGUILayout.ObjectField(script.kitMovement.CrouchCollider, typeof(Collider2D), true, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                }
                //End: Crouch Collider
                //Start: Walk: Axis Raw
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Walk: Axis Raw", GUILayout.Width(150f));
                    script.kitMovement.enumWalkAxisRaw = (KitMovement.AxisRaw) EditorGUILayout.EnumPopup(script.kitMovement.enumWalkAxisRaw, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                switch (script.kitMovement.enumWalkAxisRaw) {

                    case KitMovement.AxisRaw.Off:

                        script.kitMovement.WalkAxisRaw = false;

                        break;

                    case KitMovement.AxisRaw.On:

                        script.kitMovement.WalkAxisRaw = true;

                        break;

                }
                //End: Walk: Axis Raw
                //Start: Run: Axis Raw
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("Run: Axis Raw", GUILayout.Width(150f));
                script.kitMovement.enumRunAxisRaw = (KitMovement.AxisRaw)EditorGUILayout.EnumPopup(script.kitMovement.enumRunAxisRaw, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                switch (script.kitMovement.enumRunAxisRaw) {

                    case KitMovement.AxisRaw.Off:

                        script.kitMovement.runAxisRaw = false;

                        break;

                    case KitMovement.AxisRaw.On:

                        script.kitMovement.runAxisRaw = true;

                        break;

                }
                //End: Run: Axis Raw
                //Start: Crouch: Axis Raw
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.LabelField("Crouch: Axis Raw", GUILayout.Width(150f));
                script.kitMovement.enumCrouchAxisRaw = (KitMovement.AxisRaw)EditorGUILayout.EnumPopup(script.kitMovement.enumCrouchAxisRaw, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                switch (script.kitMovement.enumCrouchAxisRaw) {

                    case KitMovement.AxisRaw.Off:

                        script.kitMovement.crouchAxisRaw = false;

                        break;

                    case KitMovement.AxisRaw.On:

                        script.kitMovement.crouchAxisRaw = true;

                        break;

                }
                //End: Crouch: Axis Raw
                //Start: Walk Speed
                if (script.kitMovement.canMovement) { 

                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Walk: Speed", GUILayout.Width(150f));
                    script.kitMovement.speed = EditorGUILayout.FloatField(script.kitMovement.speed, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                }
                //End: Walk Speed
                //Start: Run Multiplier
                if (script.kitMovement.canRun) { 

                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Run: Multiplier", GUILayout.Width(150f));
                    script.kitMovement.runMultiplier = EditorGUILayout.Slider(script.kitMovement.runMultiplier, 1, 5, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                }
                //End: Run Multiplier
                //Start: Crouch Multiplier
                if (script.kitMovement.canCrouch) { 

                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.LabelField("Crouch: Multiplier", GUILayout.Width(150f));
                    script.kitMovement.crouchMultiplier = EditorGUILayout.Slider(script.kitMovement.crouchMultiplier, 0, 1, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();

                }
                //End: Crouch Multiplier

            }
            //End: Walk, Run and Crouch
            //Start: Jump's
            EditorGUILayout.Space(1f);
            if (jump = EditorGUILayout.Foldout(jump, "Jump", true, EditorStyles.foldoutHeader)) {

                PlayerPrefs.SetInt("jump", wrc ? 1 : 0); PlayerPrefs.Save();

                //Start: Can Jump
                EditorGUILayout.Space(1f);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Jump", GUILayout.Width(150f));

                canJump = script.kitMovement.canJump ? 0 : 1;
                canJump = GUILayout.Toolbar(canJump, onOff);

                switch (canJump) {

                    case 0:

                        script.kitMovement.canJump = true;

                        break;

                    case 1:

                        script.kitMovement.canJump = false;

                        break;
                }

                EditorGUILayout.EndHorizontal();
                //End: Can Jump

                if (canJump == 0) {

                    //Start: Movement in Air
                    EditorGUILayout.Space(1f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Movement in Air", GUILayout.Width(150f));

                    movementInAir = script.kitMovement.movementInAir ? 0 : 1;
                    movementInAir = GUILayout.Toolbar(movementInAir, onOff);

                    switch (movementInAir) {

                        case 0:

                            script.kitMovement.movementInAir = true;

                            break;

                        case 1:

                            script.kitMovement.movementInAir = false;

                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    //End: Movement in Air
                    //Start: Big Jump
                    EditorGUILayout.Space(1f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Big Jump", GUILayout.Width(150f));

                    bigJump = script.kitMovement.bigJump ? 0 : 1;
                    bigJump = GUILayout.Toolbar(bigJump, onOff);

                    switch (bigJump) {

                        case 0:

                            script.kitMovement.bigJump = true;

                            break;

                        case 1:

                            script.kitMovement.bigJump = false;

                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    //End: Big Jump
                    //Start: Wall Jump
                    EditorGUILayout.Space(1f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Wall Jump", GUILayout.Width(150f));

                    wallJump = script.kitMovement.wallJump ? 0 : 1;
                    wallJump = GUILayout.Toolbar(wallJump, onOff);

                    switch (wallJump) {

                        case 0:

                            script.kitMovement.wallJump = true;

                            break;

                        case 1:

                            script.kitMovement.wallJump = false;

                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    //End: Wall Jump
                    //Start: Double Jump
                    EditorGUILayout.Space(1f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Double Jump", GUILayout.Width(150f));

                    doubleJump = script.kitMovement.doubleJump ? 0 : 1;
                    doubleJump = GUILayout.Toolbar(doubleJump, onOff);

                    switch (doubleJump) {

                        case 0:

                            script.kitMovement.doubleJump = true;

                            break;

                        case 1:

                            script.kitMovement.doubleJump = false;

                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    //End: Double Jump
                    //Start: Soar
                    EditorGUILayout.Space(1f);
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Soar", GUILayout.Width(150f));

                    soar = script.kitMovement.soar ? 0 : 1;
                    soar = GUILayout.Toolbar(soar, onOff);

                    switch (soar) {

                        case 0:

                            script.kitMovement.soar = true;

                            break;

                        case 1:

                            script.kitMovement.soar = false;

                            break;
                    }

                    EditorGUILayout.EndHorizontal();
                    //End: Soar
                }
            }
            //End: Jumps's
        }
        else {

        EditorGUILayout.Space(20f);
        EditorGUILayout.LabelField(Application.isPlaying ? "Stop the game and activate the movement kit to set variables" : "Activate the movement kit to set variables"); EditorGUILayout.Space(20f);

        }

        //End of Session

    }

    public void StatusKit() {

        EditorGUILayout.Space(2f);
        if (GUILayout.Button(("Open status reference"), GUILayout.ExpandWidth(true))) {

            Application.OpenURL("https://answers.unity.com/questions/21261/can-i-place-a-link-such-as-a-href-into-the-guilabe.html");

        }

        //Session: Start Kit
        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("Activate or Disable Status", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();

            string stateStatus = script.status ? "On" : "Off";
            EditorGUILayout.LabelField("The status kit is : " + stateStatus, GUILayout.Width(150f));

            if (GUILayout.Button((script.status ? "Disable" : "Activate"), GUILayout.ExpandWidth(true))) {

                script.status = !script.status;
                EditorApplication.isPlaying = true; EditorApplication.isPlaying = false;

            }

        EditorGUILayout.EndHorizontal();

        //End of Session
        //Session: Status variables

        if (script.status) {



        }
        else {

            EditorGUILayout.Space(20f);
            EditorGUILayout.LabelField(Application.isPlaying ? "Stop the game and activate the status kit to set variables" : "Activate the status kit to set variables");
            EditorGUILayout.Space(20f);

        }

        //End of Session


    }

    public void ControlsKit() {

        EditorGUILayout.Space(10f);
        EditorGUILayout.LabelField("Choose a button for each action below:", EditorStyles.boldLabel);

        if(script.kit.viewGame == Kit.ViewGame.SideView) {

            if (script.kitMovement != null) {

                EditorGUILayout.LabelField("Movement", EditorStyles.boldLabel);

                script.kitMovement.KCHorizontal = EditorGUILayout.TextField("Horizontal Axis", script.kitMovement.KCHorizontal);

                script.kitMovement.KCcrouch = (KeyCode)EditorGUILayout.EnumPopup("Crouch", script.kitMovement.KCcrouch);
                script.kitMovement.KCjump = (KeyCode)EditorGUILayout.EnumPopup("Jump", script.kitMovement.KCjump);
                script.kitMovement.KCrun = (KeyCode)EditorGUILayout.EnumPopup("Run", script.kitMovement.KCrun);

            }

        }

    }

}