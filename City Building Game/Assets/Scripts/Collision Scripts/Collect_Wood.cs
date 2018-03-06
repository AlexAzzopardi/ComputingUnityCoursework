using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Wood : MonoBehaviour {

    Data_Manager data_manager_script;
    Resource_Collection resource_collection_script;

    bool selected = false;
    bool harvested = false;

    float next_time = 3;
    float add_time = 3;

    void FixedUpdate()
    {
        //If Collector_Change is greater than zero and bool is true
        if (data_manager_script.Get_Collector_Change() > 0 && selected == true)
        {
            //Subtracts that worker from the employer slots
            data_manager_script.Change_Collector_Amount(-1);
            //Sets bool to true
            harvested = true;
            //Creates a time delay
            next_time = Time.time + add_time;
        }
        //If bool is true and time delay has run out
        if (harvested == true && Time.time > next_time)
        {
            //Checks to see if it will go over the maximum storage.  
            if (data_manager_script.Check_Resources(1) + 10 <= data_manager_script.Get_Max_Storage())
            {
                //Add resources to inventory
                data_manager_script.Change_Resources(1, 10);
            }
            //Add one to the Collector_Amount
            data_manager_script.Change_Collector_Amount(1);
            //Destroys the gameobject
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider object_collider)
    {
        //If it touch an object with a collider and it has the tag "collector_all" or "collector_wood"
        if (object_collider.tag == "collector_all" || object_collider.tag == "collector_wood")
        {
            //If the boolean resource_collection is true and the player are clicking
            if (Input.GetMouseButtonDown(0) && resource_collection_script.resource_collection == true)
            {
                //Sets bool to true
                selected = true;
            }
        }
    }

    GameObject Center_Object;

    void Start()
    {
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();
        resource_collection_script = Center_Object.GetComponent<Resource_Collection>();
    }
}
