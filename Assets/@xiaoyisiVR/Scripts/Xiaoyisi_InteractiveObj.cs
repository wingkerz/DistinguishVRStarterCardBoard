using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xiaoyisi_InteractiveObj : MonoBehaviour {


	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hovered(){


      

    }


	public void activated(){


        //这是示例代码，执行之后，会把自己变红
        this.GetComponent<MeshRenderer>().material.color=Color.red;

        //这句代码，可以让程序退出
        Application.Quit();



         //总之，注视两秒后，需要做什么，写在这里就行

        
	}


	public void leave(){

      

    }
}
