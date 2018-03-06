using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Collection : MonoBehaviour {

    Vector3 click_pos;
    Vector3 mouse_pos;

    Quaternion rot_zero = Quaternion.Euler(0, 0, 0);

    public bool resource_collection = false;

    public Mouse_Position mouse_position_script;
    public UI_Manager ui_manager_script;

    GameObject current_resource_collector;
    GameObject resource_collector_placer;

    public GameObject resource_collector_all;
    public GameObject resource_collector_wood;
    public GameObject resource_collector_stone;
    public GameObject resource_collector_iron;

    int current_collector_key;

    public int Get_Current_Collector_Key()
    {
        return current_collector_key;
    }

    public void Resource_Collection_Controller()
    {
        //Find the posision of the mouse
        mouse_pos = mouse_position_script.Get_Mouse_Pos();

        //If you left click and you are not collecting a resource
        //If you are not clicking a button
        if (Input.GetMouseButtonUp(0) && resource_collection == false && ui_manager_script.Get_Button_Pressed() == false){
            //Make the click position equal the mouse position
            //Change bool to say you are selecting an area
            click_pos = mouse_pos;
            resource_collection = true;}

        //If you left click and you are collecting a resource
        else if (Input.GetMouseButtonUp(0) && resource_collection == true){
            //Change bool to say you are not collecting a resource
            resource_collection = false;}

        //If you right click and you are collecting a resource
        if (Input.GetMouseButtonUp(1) && resource_collection == true){
            //Change bool to say you are not collecting a resource
            resource_collection = false;}

        //If you are collecting a resource
        if(resource_collection == true){
            //Destroy old collector and places down a new one inbetween the two points
            //Change the scale so that the selector fits between both corners.
            Destroy(resource_collector_placer);
            resource_collector_placer = Instantiate(current_resource_collector, new Vector3((click_pos[0] + mouse_pos[0]) / 2, 0, (click_pos[2] + mouse_pos[2]) / 2), rot_zero);
            resource_collector_placer.transform.localScale = new Vector3(Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1, 0.1f, Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1);
        }

        //If you are not collecting a resource
        else{
            //Destory the previous collector and place down a new one
            Destroy(resource_collector_placer);
            resource_collector_placer = Instantiate(current_resource_collector, new Vector3(mouse_pos[0], 0, mouse_pos[2]), rot_zero);
        }
    }

    //Resource Key
    //0 = All
    //1 = Wood
    //2 = Stone
    //3 = Iron

    //Changes the Selectors gameobject depending on the key given
    public void Change_Resouce_Collection(int resource_collection_key)
    {
        //Sets the current key
        current_collector_key = resource_collection_key;

        //Changes the current_resource_collector to the correct collector
        if(resource_collection_key == 0){
            current_resource_collector = resource_collector_all;}

        else if (resource_collection_key == 1){
            current_resource_collector = resource_collector_wood;}

        else if (resource_collection_key == 2){
            current_resource_collector = resource_collector_stone;}

        else if (resource_collection_key == 3){
            current_resource_collector = resource_collector_iron;}

        //Prints if there is a problem with the key
        else { print("Key Invalid"); }       
    }

    //Removes any left over objects
    public void End_Resource_Collection()
    {
        Destroy(resource_collector_placer);
    }
}

