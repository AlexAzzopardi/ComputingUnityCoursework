using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    //TASK KEYS:
    //0 = nothing
    //1 = Road_Builder
    //2 = Building_Placer
    //3 = Farm_Placer
    //4 = Resource_Collection
    //5 = Bulldozer
    //6 = ...

    public Road_Builder road_builder_script;
    public Building_Placer building_placer_script;
    public Resource_Collection resource_collection_script;
    public Bulldozer bulldozer_script;
    public Farm_Placer farm_placer_script;

    int current_task_key = 0;

    public int Get_Current_Task_Key()
    {
        return current_task_key;
    }
    
    //Takes in value new task
    public void Change_Task(int change_task_key)
    {
        //If the new task and current task are the same
        //then make the new take equal to nothing
        //If not then make the current task the new task
        if (change_task_key == current_task_key){
            current_task_key = 0;}

        else{ current_task_key = change_task_key;}
    }

	void Update ()
    {
        //Checks current_task_key and runs the appropriate method
        if (current_task_key == 0) { }

        else if (current_task_key == 1){
            road_builder_script.Road_Builder_Controller();}

        else if (current_task_key == 2){
            building_placer_script.Building_Placer_Controller();}

        else if (current_task_key == 3){
            farm_placer_script.Farm_Placer_Controller();}

        else if (current_task_key == 4){
            resource_collection_script.Resource_Collection_Controller();}

        else if (current_task_key == 5){
            bulldozer_script.Bulldozer_Controller();}

        //Prints there is a problem     
        else{ print("Task Unavalable"); }
    }

}
