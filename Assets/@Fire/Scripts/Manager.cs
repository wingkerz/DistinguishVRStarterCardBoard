using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public int safePoints;
    public int MoneyPoints;

    public bool hasGetTheCup;
    public bool hasGetTheDistinguish;
    


    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //直接加减分
    public void AddSafePoints(int values) {

        safePoints += values;
    }


    public void AddMoneyPoints(int values)
    {
        MoneyPoints += values;

    }

    //需要判定条件加减分

    public void SpecialAddMoneyPoints(int Values)

    {
        if (hasGetTheDistinguish)
        {


            MoneyPoints += Values;

        }
        else {


            hasGetTheDistinguish = true;
        }

    }

    public void SpecialAddSafePoints(int Values)

    {
        if (hasGetTheCup)
        {



            safePoints += Values;

        }
        else
        {


            hasGetTheCup = true;
        }

    }


    IEnumerator countTime() {

        yield return new WaitForSeconds(90.0f);

        //游戏结束逻辑

        //Application.Quit();

        //SceneManager.LoadScene(0);
    }


}
