using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*本案例中的核心脚本 。挂在相机上，它主要做这几件事：
  
    1.发射射线，检测前方有可交互的对象；
    2.如果检测到有交互对象，去获得它身上的功能脚本；
    3.开始计时，到达3秒，触发功能；
    4.如果用户中途离开，则重新计时；

它还顺便做了其他事情：
      
    1.准星，能够吸附到对象；
    2 没有交互对象的时候，重置准星的位置；
    */

public class Xiaoyisi_GazeController : MonoBehaviour {
	//the canvas that hold your reticle;
	public Canvas canvasPoint;
	public Image reticleImage;
	//gaze default distance
	public float deafaultGazeDistance;

	//store interactibated Objs
	private GameObject curInteractiveObj;
	private GameObject oldInteractiveObj;
	private Xiaoyisi_InteractiveObj objDoing;
	private Xiaoyisi_InteractiveObj oldobjDoing;

	// gazeInput need to count time ,so need two timeInfo
	private float gazeDurationTime=2.0f;
	private float counttime;

	// canvas position and rotation. will back to original,when no item dected;
	private Vector3 canvasOriginalPosition;
	private Vector3 canvasOriginalRotation;
	private Vector3 canvasOriginalScale;


	// Use this for initialization
	void Start () {
		// record the original paramters for canvas/reticle
		canvasOriginalPosition =new Vector3(0,0,deafaultGazeDistance);
		canvasOriginalRotation = canvasPoint.transform.eulerAngles;
		canvasOriginalScale = new Vector3 (0.02f, 0.02f, 0.02f);
		//fillamount should be 0
		reticleImage.fillAmount=0;

	}
	
	// Update is called once per frame
	void Update () {
		//a ray cast from camera,and toward to cameras direction;
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		// if the ray hit something ,gaze point will show at the hitpoint,and scale\rotate itself by distance;
		if (Physics.Raycast (ray, out hit, 100)) {
			canvasPoint.transform.localScale = hit.distance * canvasOriginalScale * 0.05f;
			canvasPoint.transform.position = hit.point;
			//hit normal will return the v3 direction of hit surface point;
			canvasPoint.transform.forward = hit.normal;


			//when we hit the new obj...,or this is first time we got a obj;
			if (hit.transform.gameObject != curInteractiveObj) {
				//we should store the obj as old one(before it been renew),as we want to do something on old obj;
				if (curInteractiveObj != null) {
					oldInteractiveObj = curInteractiveObj;
					oldobjDoing=oldInteractiveObj.GetComponent<Xiaoyisi_InteractiveObj> ();
					if (oldobjDoing) {
						oldobjDoing.leave ();
					}
				}
				curInteractiveObj = hit.transform.gameObject;
				//try to get the Peter_... on this obj
				objDoing = curInteractiveObj.GetComponent<Xiaoyisi_InteractiveObj> ();
				if(objDoing){
					objDoing.hovered ();
				}
			} 

			//when the obj is not changed(still being gazed)...start count time 
			else {
				counttime += Time.deltaTime;
				//start fill image, when time not reach 
				if (counttime < gazeDurationTime) {
				
					reticleImage.fillAmount = counttime / gazeDurationTime;

				} else {
				  // time engouth! something should happen here...
					reticleImage.fillAmount = 0.0f;
					counttime = 0;
                    objDoing.activated();

                }
			
			
			}


		} else {
		
			// user's point leaved,so our point need to reset;
			canvasPoint.transform.localPosition = canvasOriginalPosition;
			canvasPoint.transform.localEulerAngles = Vector3.zero;
			canvasPoint.transform.localScale = canvasOriginalScale;
			counttime = 0;
			reticleImage.fillAmount = 0;
			//gaze leaved, leave function should be exetuted,and set curobj as null;
			if (curInteractiveObj != null) {
			    objDoing=curInteractiveObj.GetComponent<Xiaoyisi_InteractiveObj> ();
				if (objDoing) {
					objDoing.leave ();
					curInteractiveObj = null;
				}
			}
		}

	}


    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(this.transform.position, "AutoMan.png");
    }

}
