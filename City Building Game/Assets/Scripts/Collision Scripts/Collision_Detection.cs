using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour {

    GameObject Center_Object;

    Building_Placer building_placer_script;
    Road_Builder road_builder_script;
    Farm_Placer farm_placer_script;
	
    void Start()
    {
        //References "Center_Object" and get all the relavent scripts from the gameobject.
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        building_placer_script = Center_Object.GetComponent<Building_Placer>();
        road_builder_script = Center_Object.GetComponent<Road_Builder>();
        farm_placer_script = Center_Object.GetComponent<Farm_Placer>();
    }

    //When the gameobject theis script is attached to collides with another gameobject
    //It checks the tag and if the tag is one on the list then it calls the Collided methods on the other scripts  
	void OnTriggerEnter (Collider object_collider) {
        if (object_collider.tag == "house" || object_collider.tag == "road" || object_collider.tag == "forestry" || object_collider.tag == "mine" || object_collider.tag == "warehouse" || object_collider.tag == "market_stall" || object_collider.tag == "farm")
        {
            building_placer_script.Collided();
            road_builder_script.Collided();
            farm_placer_script.Collided();
        }
	}
}
