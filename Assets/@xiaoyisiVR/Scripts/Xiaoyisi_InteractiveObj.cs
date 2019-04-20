using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xiaoyisi_InteractiveObj : MonoBehaviour {

    public delegate void Action();

    public event Action Activated;
	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hovered(){


      

    }


	public void activated(){


        Activated();

        
	}


	public void leave(){

      

    }
}
