using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoyisi_FunctionPoint : MonoBehaviour {

    public Xiaoyisi_InteractiveObj _Obj;

    public GameObject[] showSth;
    public GameObject[] hideSth;

    public bool isHideMyself;


    private void OnEnable()
    {
        _Obj.Activated += activated;
    }

    private void OnDisable()
    {
        _Obj.Activated -= activated;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void activated()
    {

        foreach (var i in showSth) {

            i.SetActive(true);

        }

        foreach (var i in hideSth)
        {

            i.SetActive(false);

        }


        if (isHideMyself) {


            this.gameObject.SetActive(false);
        }


    }
}
