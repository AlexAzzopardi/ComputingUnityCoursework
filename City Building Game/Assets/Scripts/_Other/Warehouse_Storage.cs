using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse_Storage : MonoBehaviour {

    GameObject Center_Object;
    Data_Manager data_manager_script;

    //References the Center_Object and the Data_Manager on it
    void Start()
    {
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();
        //Adds 1000 to maximum storage
        data_manager_script.Change_Max_Storage(1000);
    }
}
