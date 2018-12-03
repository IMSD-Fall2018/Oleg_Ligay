using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    public Rotate rotateController;
    public Spawner _spanwer;
    public SimpleMove _simpleMove;
    public MeshRenderer _turnInvisible;
    public PlayMusic _playMusic;
    public Camera camtocontrol;
    public Color backColor;
    public TextMesh text;

    void Start () {
        text.text = "Hello World";
	}
	
	
	void Update () {

        CamBackgroundControl();
        TurnInvisible();
        CreateSpawner();
        Rotate();

    }



    bool backgroundFlag = true;
    void CamBackgroundControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && backgroundFlag == false)
        {
            camtocontrol.backgroundColor = backColor;
            backgroundFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && backgroundFlag == true)
        {
            //make random color
            Color randColor = new Color();
            randColor.r = Random.Range(0, 1f);
            randColor.g = Random.Range(0, 1f);
            randColor.b = Random.Range(0, 1f);

            camtocontrol.backgroundColor = randColor;
            backgroundFlag = true;
        }
    }

    void MoveControl()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (_simpleMove.moveSpeed == 0)
            {
                _simpleMove.moveSpeed += 10f;

            }
            else
            {
                _simpleMove.moveSpeed = 0;
            }
        }
    }

    void TurnInvisible()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if(_turnInvisible.enabled == true)
            {
                _turnInvisible.enabled = false;
            }
            else
            {
                _turnInvisible.enabled = true;
            }
        }
    }

    void Rotate()
    {
        //<-->Rotate Cube Control
        if (Input.GetKeyDown(KeyCode.Alpha1) && rotateController.rotateSpeed == 0f)
        {
            rotateController.rotateSpeed = 180f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && rotateController.rotateSpeed >= 1f)
        {
            rotateController.rotateSpeed = 0f;
        }

    }

    void CreateSpawner()
    {
        //< --> Create Spawner
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _spanwer.SpawnObject();
        }

    }
}

