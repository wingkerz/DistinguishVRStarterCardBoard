using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    public Manager _manager;

    public Text money;
    public Text safe;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        money.text = _manager.MoneyPoints.ToString();

        safe.text = _manager.safePoints.ToString();


	}
}
