using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : MonoBehaviour {

    Vector3 click_pos;
    Vector3 mouse_pos;

    Quaternion rot_zero = Quaternion.Euler(0, 0, 0);

    public bool bulldozing = false;

    public Mouse_Position mouse_position_script;
    public UI_Manager ui_manager_script;

    public GameObject bulldozer_object;
    GameObject bulldozer_placer;

    public void Bulldozer_Controller(){
        //Find the posision of the mouse
        mouse_pos = mouse_position_script.Get_Mouse_Pos();

        //If you click and you are not selecting an area
        //Make the click position equal the mouse position
        //Change bool to say you are selecting an area
        if (Input.GetMouseButtonUp(0) && bulldozing == false && ui_manager_script.Get_Button_Pressed() == false){
            click_pos = mouse_pos;
            bulldozing = true;}

        //If you click and you are selecting an area
        //Change bool to say you are not selecting an area
        else if (Input.GetMouseButtonUp(0) && bulldozing == true){
            bulldozing = false;}

        //If you right click and you are selecting an area
        //Change bool to say you are not selecting an area
        if (Input.GetMouseButtonUp(1) && bulldozing == true) { 
            bulldozing = false;}

        //Destroy old selector and place down new on inbetween the two corner points
        //Change the scale so that the selector goes between both corners.
        if (bulldozing == true){
            Destroy(bulldozer_placer);
            bulldozer_placer = Instantiate(bulldozer_object, new Vector3((click_pos[0] + mouse_pos[0]) / 2, 0, (click_pos[2] + mouse_pos[2]) / 2), rot_zero);
            bulldozer_placer.transform.localScale = new Vector3(Mathf.Abs(click_pos[0] - mouse_pos[0]) + 1, 0.1f, Mathf.Abs(click_pos[2] - mouse_pos[2]) + 1);
        }
    
        //If you are not selecting an area destory the previous selector and place down a new selector.
        else{
            Destroy(bulldozer_placer);
            bulldozer_placer = Instantiate(bulldozer_object, new Vector3(mouse_pos[0], 0, mouse_pos[2]), rot_zero);}}
      
    //Removes any left over objects
    public void End_Bulldozer(){
        Destroy(bulldozer_placer);}
}
