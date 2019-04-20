using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoyisi_SpecialMarkPoint : MonoBehaviour {

    public Xiaoyisi_InteractiveObj _Obj;

    public Manager _manager;

    public int addSafeNumber;
    public int addMoneyNumber;
    public pointType type;

    public enum pointType{

        type_Safe=0,
        type_Money=1


    };

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

        if (type == pointType.type_Money) {

            _manager.SpecialAddMoneyPoints(addMoneyNumber);


        } else if (type == pointType.type_Safe) {

            _manager.SpecialAddSafePoints(addSafeNumber);
        }


    }
}
