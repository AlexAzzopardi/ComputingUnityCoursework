using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Builder : MonoBehaviour {

    //References UI_Manager script
    public UI_Manager ui_manager_script;
    public Mouse_Position mouse_position_script;

    public GameObject temp_road_object;
    public GameObject temp_road_parent;
    GameObject temp_road;
    public GameObject perm_road_object;
    public GameObject perm_road_parent;
    GameObject perm_road;

    Quaternion rot_zero = Quaternion.Euler(0, 0, 0);

    Vector3 mouse_pos;
    Vector3 click_pos;

    float x_dif;
    float z_dif;

    bool drawing_road = false;

    bool is_colliding = false;

    void Start()
    {
        //Creates a gameobject and stores it in variable perm_road
        perm_road = Instantiate(perm_road_parent);
    }

    public void Collided()
    {
        is_colliding = true;
    }

    public void Road_Builder_Controller ()
    {
        //Calls function Get_Mouse_Pos from another script and stores output in mouse_pos
        mouse_pos = mouse_position_script.Get_Mouse_Pos();

        //Destroys and recreates temp_road with gameobject temp_road_parent in it
        Destroy(temp_road);
        temp_road = Instantiate(temp_road_parent);

        //if variable is false create a gameobject as a child of temp_road
        if(drawing_road == false){
            Instantiate(temp_road_object, mouse_pos, rot_zero, temp_road.transform);
        }

        //If you are clicking the left mouse button
        //If you are not drawing a road
        //If your not clicking a button
        if (Input.GetMouseButtonUp(0) && drawing_road == false && ui_manager_script.Get_Button_Pressed() == false) {

            //Make the click position equal the mouse position
            //Change bool to say you are selecting an area
            drawing_road = true;
            click_pos = mouse_pos;
        }

        //If you are clicking the left mouse button
        //If you are not drawing a road
        //If you are not colliding with anything
        //If your not clicking a button
        else if (Input.GetMouseButtonUp(0) && ui_manager_script.Get_Button_Pressed() == false && drawing_road == true && is_colliding == false)
        {
            //Stop drawing road 
            //Run the method
            drawing_road = false;
            Perm_Road_Placer();
        }

        //If variable is true run procdure
        else if(drawing_road == true)
        {
            Temp_Road_Placer();
        }

        //right clicking stops the building of a road
        if (Input.GetMouseButtonUp(1) && drawing_road == true) {
            drawing_road = false;
        }

        //Every time the script is run it resets the bool to false
        is_colliding = false;
    }

    string Direction()
    {
        //Finds distance across x and z plane between two points
        x_dif = mouse_pos[0] - click_pos[0];
        z_dif = mouse_pos[2] - click_pos[2];

        //Checks to see if they points in the northeast direction
        if (x_dif >= 0 && z_dif >= 0)
        {
            return "northeast";
        }
        //Checks to see if they points in the southeast direction
        else if (x_dif >= 0 && z_dif <= 0)
        {
            return "southeast";
        }
        //Checks to see if they points in the southwest direction
        else if (x_dif <= 0 && z_dif <= 0)
        {
            return "southwest";
        }
        //Checks to see if they points in the northwest direction
        else if (x_dif <= 0 && z_dif >= 0)
        {
            return "northwest";
        }
        //If null the return nothing
        else
        {
            return "";
        }
    }

    void Temp_Road_Placer(){
        //Takes in what direcion the two points are facing so that it can draw a road in the correct direction
        if (Direction() == "northeast"){
            //Creates two for loops one for the z axis and one for the x axis
            for (int i = 0; i <= z_dif; i++){
                //Places roads every segment creating the illusion of the road
                //Creates them as a child of the temp_road objects so they can be removed easily.
                Instantiate(temp_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, temp_road.transform);}
            for (int i = 1; i <= x_dif; i++){
                Instantiate(temp_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, temp_road.transform);}}
        else if (Direction() == "southeast"){
            for (int i = 0; i >= z_dif; i--){
                Instantiate(temp_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, temp_road.transform);}
            for (int i = 1; i <= x_dif; i++){
                Instantiate(temp_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, temp_road.transform);}}
        else if (Direction() == "southwest"){
            for (int i = 0; i >= z_dif; i--){
                Instantiate(temp_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, temp_road.transform);}
            for (int i = -1; i >= x_dif; i--){
                Instantiate(temp_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, temp_road.transform);}}
        else if (Direction() == "northwest"){
            for (int i = 0; i <= z_dif; i++){
                Instantiate(temp_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, temp_road.transform);}
            for (int i = -1; i >= x_dif; i--){
                Instantiate(temp_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, temp_road.transform);}}
        else { print("Direction Invalid"); }
    }

    void Perm_Road_Placer() {
        //Takes in what direcion the two points are facing so that it can draw a road in the correct direction
        if (Direction() == "northeast"){
            //Creates two for loops one for the z axis and one for the x axis
            for (int i = 0; i <= z_dif; i++){
                //Places roads every segment creating the illusion of the road
                //Creates them as a child of the temp_road objects so they can be removed easily.
                Instantiate(perm_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, perm_road.transform);}
            for (int i = 1; i <= x_dif; i++){
                Instantiate(perm_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, perm_road.transform);}}
        else if (Direction() == "southeast"){
            for (int i = 0; i >= z_dif; i--){
                Instantiate(perm_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, perm_road.transform);}
            for (int i = 1; i <= x_dif; i++){
                Instantiate(perm_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, perm_road.transform);}}
        else if (Direction() == "southwest"){
            for (int i = 0; i >= z_dif; i--){
                Instantiate(perm_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, perm_road.transform);}
            for (int i = -1; i >= x_dif; i--){
                Instantiate(perm_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, perm_road.transform);}}
        else if (Direction() == "northwest"){
            for (int i = 0; i <= z_dif; i++){
                Instantiate(perm_road_object, new Vector3(click_pos[0], 0, click_pos[2] + i), rot_zero, perm_road.transform);}
            for (int i = -1; i >= x_dif; i--){
                Instantiate(perm_road_object, new Vector3(click_pos[0] + i, 0, click_pos[2] + z_dif), rot_zero, perm_road.transform);}}
        //Prints if direction is invalid
        else { print("Invalid Direcion"); }
    }

    public void End_Road_Builder()
    {
        //Removes the temporary objects 
        Destroy(temp_road);
        drawing_road = false;
    }
}
