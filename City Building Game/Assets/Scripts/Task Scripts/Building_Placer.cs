using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Placer : MonoBehaviour {

    public UI_Manager ui_manager_script;
    public Mouse_Position mouse_position_script;
    public Data_Manager data_manager_script;

    Quaternion rot_building = Quaternion.Euler(0, 0, 0);
    Vector3 mouse_pos;
    int rot_y = 0;

    //This will change as i add more buildings
    static int number_of_buildings = 5;

    //Creates two gameobjects arrays with a set length
    GameObject[] perm_buildings = new GameObject[number_of_buildings];
    GameObject[] temp_buildings = new GameObject[number_of_buildings];
    
    //Buildings
    public GameObject perm_house_0;
    public GameObject temp_house_0;
    public GameObject perm_forestry;
    public GameObject temp_forestry;
    public GameObject perm_mine;
    public GameObject temp_mine;
    public GameObject perm_market_stall;
    public GameObject temp_market_stall;
    public GameObject perm_warehouse;
    public GameObject temp_warehouse;

    GameObject perm_building;
    GameObject temp_building;
    GameObject temp_building_object;

    //BUILDING COSTS
    //Posison in the array corrisponds to what building it is
    int gold_cost;
    int[] gold_cost_list = new int[] { 0, 0, 0, 0, 0 };

    int wood_cost;
    int[] wood_cost_list = new int[] { 100, 100, 150, 100, 200 };

    int stone_cost;
    int[] stone_cost_list = new int[] { 100, 150, 100, 50, 200 };

    int iron_cost;
    int[] iron_cost_list = new int[] { 0, 0, 0, 0, 0 };

    //LEGEND
    //0 = house
    //1 = forestry
    //2 = mine
    //3 = market_stall
    //4 = warehouse
    //5 = ...

    void Start() {
        //Inputs the correct gameobjects into the correct arrays
        perm_buildings[0] = perm_house_0;
        perm_buildings[1] = perm_forestry;
        perm_buildings[2] = perm_mine;
        perm_buildings[3] = perm_market_stall;
        perm_buildings[4] = perm_warehouse;

        //Inputs the correct gameobjects into the correct arrays
        temp_buildings[0] = temp_house_0;
        temp_buildings[1] = temp_forestry;
        temp_buildings[2] = temp_mine;
        temp_buildings[3] = temp_market_stall;
        temp_buildings[4] = temp_warehouse;

        //Starts off the perm and temp buildings as building 0
        Building_Selector(0);
    }

    int current_building_key;

    public int Get_Current_Building_Key()
    {
        return current_building_key;
    }

    public bool is_colliding = false;

    public void Collided()
    {
        is_colliding = true;
    }

    public void Building_Placer_Controller ()
    {
        //Calls function Get_Mouse_Pos and returns vector3
        mouse_pos = mouse_position_script.Get_Mouse_Pos();

        //Makes sure that the object isnt inside another object
        //Checks to see if you have enough resources in the inventory
        //Makes sure you arent clicking a button
        if (Input.GetMouseButtonUp(0) && ui_manager_script.Get_Button_Pressed() == false && is_colliding == false && gold_cost <= data_manager_script.Check_Resources(0) && wood_cost <= data_manager_script.Check_Resources(1) && stone_cost <= data_manager_script.Check_Resources(2) && iron_cost <= data_manager_script.Check_Resources(3))
        {
            //Places a building at mouse
            Instantiate(perm_building, mouse_pos, rot_building);

            //Takes away the correct amount of resoucrces for the building
            data_manager_script.Change_Resources(1, -gold_cost);
            data_manager_script.Change_Resources(1, -wood_cost);
            data_manager_script.Change_Resources(2, -stone_cost);
            data_manager_script.Change_Resources(1, -iron_cost);

            //Changes the amount of that type of building in the list by 1
            data_manager_script.Change_Building(current_building_key, 1);
        }
        
        else {
            //Destroys the old tempereary building and creates new one at the mouse
            Destroy(temp_building_object);
            temp_building_object = Instantiate(temp_building, mouse_pos, rot_building);
        }

        //If R is pressed call the method
        if (Input.GetKeyDown("r") == true)
        {
            Building_Rotation();
        }

        //Every time the script is run it resets the bool to false
        is_colliding = false;
    }
    
    public void Building_Selector(int building_key) {
        current_building_key = building_key;

        //Makes sure the key is valid
        if (building_key <= number_of_buildings && building_key >= 0)
        {
            //Selects the correct building as compared to the key
            perm_building = perm_buildings[building_key];
            temp_building = temp_buildings[building_key];

            //Changes the costs to fit the building
            gold_cost = gold_cost_list[building_key];
            wood_cost = wood_cost_list[building_key];
            stone_cost = stone_cost_list[building_key];
            iron_cost = iron_cost_list[building_key];           
        }
        //Validation
        else { print("building_key Invalid"); }
    }

    void Building_Rotation() {
        //Add 90 degrees to angle and make sure it stays below 360
        rot_y += 90;
        if(rot_y >= 360){
            rot_y = 0;}
        //Sets all of the rotation to the new rotation.
        rot_building = Quaternion.Euler(0, rot_y, 0);
    }

    public void End_Building_Placer()
    {
        //Removes the temporary objects 
        Destroy(temp_building_object);
    }
}
