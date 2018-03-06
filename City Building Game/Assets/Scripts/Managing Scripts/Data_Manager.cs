using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Manager : MonoBehaviour {

    void Start(){
        Change_Employer_Slots(5, 1);
        Change_Resources(0,400);
        Change_Resources(1, 400);
        Change_Resources(2, 400);
        Change_Resources(4, 400);

        Change_Resources(3, 100);
        Change_Pop(10);
    }

    //RESOURCES

    //LEGEND - resource_amounts
    //0 = money
    //1 = wood
    //2 = stone
    //3 = food
    //4 = iron 
    //5 = ...

    //Creates an array.
    //I will change the length as more items are added.
    float[] resource_amounts = new float[5];

    //Returns an integer based off of the amount of a paticular resource.
    public float Check_Resources(int resource_key)
    {
        //Checkes to make sure that the key is in the correct range.
        if (resource_key < 5 && resource_key >= 0)
        {
            return resource_amounts[resource_key];
        }
        else
        {
            print("Invalid Key!");
            return 0;
        }
    }
    //Change the amount of a resource stored based off a key and the amount changed.
    public void Change_Resources(int resource_key, float resource_change)
    {
        //Checkes to make sure that the key is in the correct range.
        if (resource_key < 5 && resource_key >= 0)
        {
            resource_amounts[resource_key] += resource_change;
        }
        else
        {
            print("Invalid Key!");
        }
    }

    //BUILDINGS

    //LEGEND - building_amounts
    //0 = house
    //1 = forestry
    //2 = mine
    //3 = market stall
    //4 = warehouse
    //5 = farm
    //6 = ...

    //Creates an array.
    //I will change the length as more items are added.
    int[] building_amounts = new int[6];

    //Returns an integer based off of the numberof a paticular building there is.
    //Validates that the input is acceptable.
    //If not it returns 0.
    public int Check_Building(int building_key)
    {
        if (building_key < 6 && building_key >= 0)
        {
            return building_amounts[building_key];
        }
        else
        {
            print("Invalid Key!");
            return 0;
        }
    }
    //Change the amount of a type of building stored based off a key and the amount changed.
    //Validates that the input is acceptable.
    public void Change_Building(int building_key, int building_change)
    {
        if (building_key < 6 && building_key >= 0)
        {
            building_amounts[building_key] += building_change;
        }
        else
        {
            print("Invalid Key!");
        }
    }

    //JOBS

    //LEGEND - Job_amounts
    //0 = forester
    //1 = miner
    //2 = farmer
    //3 = trader
    //4 = builder
    //5 = collector
    //6 = ...

    //Creates an array.
    //I will change the length as more items are added.
    float[] job_amounts = new float[6];

    //return a float which is the number of jobs depending on what key is given
    //Validates that the input is acceptable.
    //If not it returns 0.
    public float Check_Jobs(int job_key)
    {
        if (job_key < 6 && job_key >= 0)
        {
            return job_amounts[job_key];
        }
        else
        {
            print("Invalid Key!");
            return 0;
        }
    }

    //Adds or subtracts an amount from the jobs depending on the key given
    //Validates that the input is acceptable.
    public void Change_Jobs(int job_key, float job_change)
    {
        if (job_key < 6 && job_key >= 0)
        {
            job_amounts[job_key] += job_change;
        }
        else
        {
            print("Invalid Key!");
        }
    }

    //EMPLOYER SLOTS

    float[] employer_amounts = new float[6];
    float[] employer_slots_amounts = new float[6];

    //return an integer which is the number of employer slots depending on what key is given
    //Validates that the input is acceptable.
    //If not it returns 0.
    public float Check_Employer_Slots(int employed_key)
    {
        if (employed_key < 6 && employed_key >= 0)
        {
            return employer_slots_amounts[employed_key];
        }
        else
        {
            print("Invalid Key!");
            return 0;
        }
    }

    //Adds or subtracts an amount from the employer slots depending on the key given
    //Validates that the input is acceptable.
    public void Change_Employer_Slots(int employed_key, float employed_change)
    {
        if (employed_key < 6 && employed_key >= 0)
        {
            employer_slots_amounts[employed_key] += employed_change;
        }
        else
        {
            print("Invalid Key!");
        }
    }

    //TOTAL EMPLOYED

    //return an integer which is the number of employed depending on what key is given
    //Validates that the input is acceptable.
    //If not it returns 0.
    public float Check_Total_Employed(int employed_key)
    {
        if (employed_key < 6 && employed_key >= 0)
        {
            return employer_amounts[employed_key];
        }
        else
        {
            print("Invalid Key!");
            return 0;
        }
    }

    //Adds or subtracts an amount from the employed depending on the key given
    //Validates that the input is acceptable.
    public void Change_Total_Employed(int employed_key, float employed_change)
    {
        if (employed_key < 6 && employed_key >= 0)
        {
            employer_amounts[employed_key] += employed_change;
        }
        else
        {
            print("Invalid Key!");
        }
    }

    //POPULATION

    //int[] pop_class = new int[1];

    float pop_total;

    //return an integer which is the total population
    public float Check_Pop_Total()
    {
        return pop_total;
    }

    //Adds or subtracts an amount from the total population
    public void Change_Pop(float pop_change)
    {
        pop_total += pop_change;
    }

    //BEDS

    int beds_total;

    //return an integer which is the total beds
    public int Check_Beds_Total()
    {
        return beds_total;
    }

    //Adds or subtracts an amount from the total beds
    public void Change_Beds(int beds_change)
    {
        beds_total += beds_change;
    }

    public int Check_Total_Income()
    {
        return 0;
    }

    int max_storage = 1000;

    public int Get_Max_Storage()
    {
        return max_storage;
    }

    public void Change_Max_Storage(int amount_changed)
    {
        max_storage += amount_changed;
    }

    int Collector_Change = 1;
     
    public int Get_Collector_Change()
    {
        return Collector_Change;
    }

    public void Change_Collector_Amount(int amount_change)
    {
        Collector_Change += amount_change;
    }

    float unemployed;

    public float Get_Unemployed()
    {
        //Works out the number of unemployed people
        unemployed = (Check_Pop_Total() - (Check_Total_Employed(0) + Check_Total_Employed(1) + Check_Total_Employed(2) + Check_Total_Employed(3)));
        return unemployed;
    }

    float homeless;

    public float Get_Homeless()
    {
        homeless = Check_Pop_Total() - Check_Beds_Total();
        if(homeless < 0){
            homeless = 0;}
        return homeless;
    }
}
