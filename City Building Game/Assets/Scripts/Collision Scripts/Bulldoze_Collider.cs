using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldoze_Collider : MonoBehaviour
{
    //Runs when it collides with another collider
    void OnTriggerEnter(Collider object_collider)
    {
        //If the player is left clicking and the tag on the object is "forestry"
        if (object_collider.tag == "forestry" && Input.GetMouseButtonDown(0))
        {
            //References the unique script on the prefab
            GameObject forestry = object_collider.gameObject;
            Forestry_Wood_Collection forestry_wood_collection_script = forestry.GetComponent<Forestry_Wood_Collection>();
            //Subtracts a job from the jobs lists
            data_manager_script.Change_Jobs(0, -forestry_wood_collection_script.Get_Local_Max_Employed());
            //Subtracts the amount that wa employed by the building from the employed list
            data_manager_script.Change_Total_Employed(0, -forestry_wood_collection_script.Get_Local_Employed());

            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(1, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "mine"
        if (object_collider.tag == "mine" && Input.GetMouseButtonDown(0))
        {
            //References the unique script on the prefab
            GameObject mine = object_collider.gameObject;
            Mine_Stone_Iron_Collection mine_stone_collection_script = mine.GetComponent<Mine_Stone_Iron_Collection>();
            //Subtracts a job from the jobs list
            data_manager_script.Change_Jobs(1, -mine_stone_collection_script.Get_Local_Max_Employed());
            //Subtracts the amount that wa employed by the building from the employed list
            data_manager_script.Change_Total_Employed(1, -mine_stone_collection_script.Get_Local_Employed());

            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(2, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "market_stall"
        if (object_collider.tag == "market_stall" && Input.GetMouseButtonDown(0))
        {
            //References the unique script on the prefab
            GameObject market_stall = object_collider.gameObject;
            Market_Stall_Gold_Collection market_stall_gold_collection_script = market_stall.GetComponent<Market_Stall_Gold_Collection>();
            //Subtracts a job from the jobs list
            data_manager_script.Change_Jobs(3, -market_stall_gold_collection_script.Get_Local_Max_Employed());
            //Subtracts the amount that wa employed by the building from the employed list
            data_manager_script.Change_Total_Employed(3, -market_stall_gold_collection_script.Get_Local_Employed());

            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(3, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "farm"
        if (object_collider.tag == "farm" && Input.GetMouseButtonDown(0))
        {
            //References the unique script on the prefab
            GameObject farm = object_collider.gameObject;
            Farm_Food_Collection farm_food_collection_script = farm.GetComponent<Farm_Food_Collection>();
            //Subtracts a job from the jobs list
            data_manager_script.Change_Jobs(2, -farm_food_collection_script.Get_Local_Max_Employed());
            //Subtracts the amount that wa employed by the building from the employed list
            data_manager_script.Change_Total_Employed(2, -farm_food_collection_script.Get_Local_Employed());

            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(5, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "house"
        if (object_collider.tag == "house" && Input.GetMouseButtonDown(0))
        {
            //Subtracts beds from beds list
            data_manager_script.Change_Beds(-4);
            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(0, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "warehouse"
        if (object_collider.tag == "warehouse" && Input.GetMouseButtonDown(0))
        {
            //Subtracts 1000 from the max storage
            data_manager_script.Change_Max_Storage(-1000);
            //Subtracts one of this building from the buildings amount list
            data_manager_script.Change_Building(4, -1);
            //Destroys the building
            Destroy(object_collider.gameObject);
        }

        //If the player is left clicking and the tag on the object is "road"
        if (object_collider.tag == "road" && Input.GetMouseButtonDown(0))
        {
            //Destroys the gameobject        
            Destroy(object_collider.gameObject);
        }
    }

    GameObject Center_Object;
    Data_Manager data_manager_script;

    //References the Center_Object and the Data_Manager on it
    void Start()
    {
        Center_Object = GameObject.FindGameObjectWithTag("Center_Object");
        data_manager_script = Center_Object.GetComponent<Data_Manager>();
    }
}
