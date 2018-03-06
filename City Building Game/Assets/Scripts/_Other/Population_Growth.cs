using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Population_Growth : MonoBehaviour {

    public Data_Manager data_manager_script;
    public UI_Manager ui_manager_script;

    //Amount of time between resource collection
    float next_time = 30;
    float add_time = 30;

    int population_growth_factor;
    float population_growth;

    void FixedUpdate()
    {
        //Checks if the time sice this scritpt stated is greater that current_time
        if (Time.time > next_time)
        {
            population_growth_factor = 0;

            //Changes the rate of population growth depending on the amount of food
            if(data_manager_script.Check_Resources(3) >= data_manager_script.Check_Pop_Total() * 10)
            {
                population_growth_factor += 20;
            }
            else if(data_manager_script.Check_Resources(3) >= data_manager_script.Check_Pop_Total() * 5)
            {
                population_growth_factor += 10;
            }
            else if (data_manager_script.Check_Resources(3) <= data_manager_script.Check_Pop_Total() * 3)
            {
                population_growth_factor -= 20;
            }

            if(data_manager_script.Check_Beds_Total() > data_manager_script.Check_Pop_Total() * 1.5)
            {
                population_growth_factor += 20;
            }
            else if(data_manager_script.Check_Beds_Total() > data_manager_script.Check_Pop_Total() * 1.1)
            {
                population_growth_factor += 10;
            }
            else if (data_manager_script.Check_Beds_Total() < data_manager_script.Check_Pop_Total() * 0.7)
            {
                population_growth_factor -= 10;
            }

            //Changes the population
            population_growth = Mathf.Ceil(data_manager_script.Check_Pop_Total()/300 * population_growth_factor);
            data_manager_script.Change_Pop(population_growth);

            //Add the current time to varible add_time
            next_time = Time.time + add_time;
        }
        //If unemployment goes below zero run the method.
        if (data_manager_script.Get_Unemployed() < 0){
            Unemployment_Controller();}

        //When all the citizens die end the game
        if (data_manager_script.Check_Pop_Total() <= 0){
            //SceneManager.LoadScene(1);
        }
    }

    void Unemployment_Controller(){
        //Check to see if anyone is employed in each job 
        //If so then it removes a job and an employment slot
        if (data_manager_script.Check_Total_Employed(0) > 0){
            data_manager_script.Change_Total_Employed(0, -1);
            data_manager_script.Change_Employer_Slots(0, -1);
        }
        else if (data_manager_script.Check_Total_Employed(1) > 0){
            data_manager_script.Change_Total_Employed(1, -1);
            data_manager_script.Change_Employer_Slots(1, -1);
        }
        else if (data_manager_script.Check_Total_Employed(2) > 0){
            data_manager_script.Change_Total_Employed(2, -1);
            data_manager_script.Change_Employer_Slots(2, -1);
        }
        else if (data_manager_script.Check_Total_Employed(3) > 0){
            data_manager_script.Change_Total_Employed(3, -1);
            data_manager_script.Change_Employer_Slots(3, -1);
        }
        else if (data_manager_script.Check_Total_Employed(4) > 0){
            data_manager_script.Change_Total_Employed(4, -1);
            data_manager_script.Change_Employer_Slots(4, -1);
        }      
        //Continues to run the method while unemployed is less than zero
        if (data_manager_script.Get_Unemployed() < 0){
            Unemployment_Controller();
        }
    }
}
