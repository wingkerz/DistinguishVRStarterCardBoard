using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoyisi_MovePoint : MonoBehaviour {

    public Xiaoyisi_InteractiveObj _Obj;

    public PlayMakerFSM pm;


    private void OnEnable()
    {
        _Obj.Activated += activated;
    }

    private void OnDisable()
    {
        _Obj.Activated -= activated;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void activated() {



        pm.SendEvent("n");


    }



}
