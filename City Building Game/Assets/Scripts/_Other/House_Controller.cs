using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Controller : MonoBehaviour {

    Data_Manager data_manager_script;
    GameObject Center_Object;

    //Refferences the Center_Object and the Data_Manager on it
    void Start()
    {
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();

        //Adds beds to the bed list
        data_manager_script.Change_Beds(4);
    }
}
