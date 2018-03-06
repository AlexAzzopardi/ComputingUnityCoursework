using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Data_Manager data_manager_script;
    public Game_Manager game_manager_script;

    public Button button_house;
    public Button button_road;
    public Button button_market_stall;
    public Button button_warehouse;

    public Button button_forestry;
    public Button button_mine;
    public Button button_farm;

    public Button button_collect_all;
    public Button button_collect_wood;
    public Button button_collect_stone;
    public Button button_collect_iron;

    public Button button_market_trade;
    public Button button_politics;
    public Button button_inventory;
    public Button button_data;
    public Button button_bulldoze;

    public GameObject general_buildings_tab;
    public GameObject utility_buildings_tab;
    public GameObject resource_buildings_tab;
    public GameObject resource_collection_tab;
    bool general_buildings_tab_active = false;
    bool utility_buildings_tab_active = false;
    bool resource_buildings_tab_active = false;
    bool resource_collection_tab_active = false;

    public Button general_buildings_button;
    public Button utility_buildings_button;
    public Button resource_buildings_button;
    public Button resource_collection_button;
    public Button market_trade_button;
    public Button politics_button;

    public Text text_wood;
    public Text text_stone;
    public Text text_iron;

    public Text text_income;
    public Text text_gold;
    public Text text_food;
    public Text text_population;
    public Text text_homeless;

    //Reference to text
    public Text text_unemployed;
    public Text text_builder;
    public Text text_forester;
    public Text text_miner;
    public Text text_farmer;
    public Text text_trader;

    //Reference to buttons
    public Button button_increase_builder;
    public Button button_decrease_builder;
    public Button button_increase_forester;
    public Button button_decrease_forester;
    public Button button_increase_miner;
    public Button button_decrease_miner;
    public Button button_increase_farmer;
    public Button button_decrease_farmer;
    public Button button_increase_trader;
    public Button button_decrease_trader;

    bool button_pressed = false;

    public bool Get_Button_Pressed()
    {
        return button_pressed;
    }

    void Update(){
        //If you are not clicking then button_pressed equals false
        if (Input.GetMouseButton(0) == false){
            button_pressed = false;}

        //If a button is pressed run the method in the brackets
        button_house.onClick.AddListener(House_Button);
        button_road.onClick.AddListener(Road_Button);
        button_warehouse.onClick.AddListener(Warehouse_Button);
        button_market_stall.onClick.AddListener(Market_Stall_Button);

        button_forestry.onClick.AddListener(Forestry_Button);
        button_mine.onClick.AddListener(Mine_Button);
        button_farm.onClick.AddListener(Farm_Button);

        button_collect_all.onClick.AddListener(Collect_All_Button);
        button_collect_wood.onClick.AddListener(Collect_Wood_Button);
        button_collect_stone.onClick.AddListener(Collect_Stone_Button);
        button_collect_iron.onClick.AddListener(Collect_Iron_Button);

        button_market_trade.onClick.AddListener(Market_Trade_Button);
        button_politics.onClick.AddListener(Politics_Button);
        button_inventory.onClick.AddListener(Inventory_Button);
        button_data.onClick.AddListener(Data_Button);
        button_bulldoze.onClick.AddListener(Bulldoze_Button);

        general_buildings_button.onClick.AddListener(General_Buildings_Button);
        utility_buildings_button.onClick.AddListener(Utility_Buildings_Button);
        resource_buildings_button.onClick.AddListener(Resource_Buildings_Button);
        resource_collection_button.onClick.AddListener(Resource_Collection_Button);
        market_trade_button.onClick.AddListener(Market_Trade_Button);
        politics_button.onClick.AddListener(Politics_Button);

        //Calls methods if buttons are pressed
        button_increase_builder.onClick.AddListener(Builder_Increase_Button);
        button_decrease_builder.onClick.AddListener(Builder_Decrease_Button);
        button_increase_forester.onClick.AddListener(Forester_Increase_Button);
        button_decrease_forester.onClick.AddListener(Forester_Decrease_Button);
        button_increase_miner.onClick.AddListener(Miner_Increase_Button);
        button_decrease_miner.onClick.AddListener(Miner_Decrease_Button);
        button_increase_farmer.onClick.AddListener(Farmer_Increase_Button);
        button_decrease_farmer.onClick.AddListener(Farmer_Decrease_Button);
        button_increase_trader.onClick.AddListener(Trader_Increase_Button);
        button_decrease_trader.onClick.AddListener(Trader_Decrease_Button);

        //Changes Text to the type plus the amount in storage
        //Converts the data obtained to a string       
        text_wood.text = ("Wood: " + data_manager_script.Check_Resources(1));
        text_stone.text = ("Stone: " + data_manager_script.Check_Resources(2));
        text_iron.text = ("Iron: " + data_manager_script.Check_Resources(4));

        text_income.text = ("Income: " + data_manager_script.Check_Total_Income());
        text_gold.text = ("Gold: " + data_manager_script.Check_Resources(0));
        text_food.text = ("Food: " + data_manager_script.Check_Resources(3));
        text_population.text = ("Population: " + data_manager_script.Check_Pop_Total());
        text_homeless.text = ("Homeless " + data_manager_script.Get_Homeless());

        //Get the total number of citizens without jobs
        text_unemployed.text = ("Unemployed: " + data_manager_script.Get_Unemployed());
        //Changes the text to total employed / total jobs for each specific job
        text_builder.text = ("Builder: " + (data_manager_script.Check_Total_Employed(4) + "/" + data_manager_script.Check_Jobs(4)));
        text_forester.text = ("Forester: " + data_manager_script.Check_Total_Employed(0) + "/" + data_manager_script.Check_Jobs(0));
        text_miner.text = ("Miner: " + data_manager_script.Check_Total_Employed(1) + "/" + data_manager_script.Check_Jobs(1));
        text_farmer.text = ("Farmer: " + data_manager_script.Check_Total_Employed(2) + "/" + data_manager_script.Check_Jobs(2));
        text_trader.text = ("Trader: " + data_manager_script.Check_Total_Employed(3) + "/" + data_manager_script.Check_Jobs(3));}

    void End_Task(){
        //Calls the correct end task method depending on what task was taking place
        if (game_manager_script.Get_Current_Task_Key() == 1)
        {
            game_manager_script.road_builder_script.End_Road_Builder();
        }
        else if (game_manager_script.Get_Current_Task_Key() == 2)
        {
            game_manager_script.building_placer_script.End_Building_Placer();
        }
        else if (game_manager_script.Get_Current_Task_Key() == 3)
        {
            game_manager_script.farm_placer_script.End_Farm_Placing();
        }
        else if (game_manager_script.Get_Current_Task_Key() == 4)
        {
            game_manager_script.resource_collection_script.End_Resource_Collection();
        }
        else if (game_manager_script.Get_Current_Task_Key() == 5)
        {
            game_manager_script.bulldozer_script.End_Bulldozer();
        }
        //Checks if there is no task
        else if (game_manager_script.Get_Current_Task_Key() == 0){ }
        //Creates validation
        else{
            print("current_task_key Invalid!");}}

    //MISC BUTTONS
    void Road_Button(){
        //Only runs once every time the button is pressed
        if (button_pressed == false)
        {
            //Calls function to end all tasks
            End_Task();
            //Says that the button is being pressed
            button_pressed = true;
            //Calls function to change task to "Road_Builder"
            game_manager_script.Change_Task(1);
        }
    }
    void Farm_Button(){
        //Only runs once every time the button is pressed
        if (button_pressed == false)
        {
            //Calls method to end all tasks
            End_Task();
            //Says that the button is being pressed
            button_pressed = true;
            //Calls function to change task to "Road_Builder"
            game_manager_script.Change_Task(3);
        }
    }
    void Bulldoze_Button(){
        //Only runs once every time the button is pressed
        if (button_pressed == false)
        {
            //Calls function to end all tasks
            End_Task();
            //Says that the button is being pressed
            button_pressed = true;
            //Calls function to change task to "Building_Placer"
            game_manager_script.Change_Task(5);
        }
    }

    //BUILDING BUTTONS
    void UI_Building_Placer_Controller(int building_key){
        //Only runs once every time the button is pressed
        if (button_pressed == false){
            //Validates input
            if (building_key >= 0 && building_key < 5)
            {
                //Calls method to end all tasks
                End_Task();

                if (game_manager_script.Get_Current_Task_Key() == 2 && game_manager_script.building_placer_script.Get_Current_Building_Key() == building_key){
                    //Calls function to change task to "Building_Placer"
                    game_manager_script.Change_Task(2);
                }
                else if (game_manager_script.Get_Current_Task_Key() == 2 && game_manager_script.building_placer_script.Get_Current_Building_Key() != building_key){
                    //Selects the correct building
                    game_manager_script.building_placer_script.Building_Selector(building_key);
                }
                else if (game_manager_script.Get_Current_Task_Key() != 2){
                    //Calls function to change task to "Building_Placer"
                    game_manager_script.Change_Task(2);
                    //Selects the correct building
                    game_manager_script.building_placer_script.Building_Selector(building_key);
                }
                //Says that the button is being pressed
                button_pressed = true;
            }
            //Prints if key is out of range
            else { print("Invalid building_key"); }
        }
    }
    void House_Button()
    {
        //Calls method to change to the correct building
        UI_Building_Placer_Controller(0);
    }
    void Forestry_Button()
    {
        //Calls method to change to the correct building
        UI_Building_Placer_Controller(1);
    }
    void Mine_Button()
    {
        //Calls method to change to the correct building
        UI_Building_Placer_Controller(2);
    }
    void Market_Stall_Button()
    {
        //Calls method to change to the correct building
        UI_Building_Placer_Controller(3);
    }
    void Warehouse_Button(){
        //Calls method to change to the correct building
        UI_Building_Placer_Controller(4);}

    //COLLECTOR BUTTONS
    void UI_Resource_Collector_Controller(int collector_key){
        //Only runs once every time the button is pressed
        if (button_pressed == false)
        {           
            //Makes sure the input is within a certain range.
            if (collector_key >= 0 && collector_key < 4)
            {
                //Calls method to end the correct task
                End_Task();
                //Call if you are running a different task or are using the same collector
                if (game_manager_script.Get_Current_Task_Key() != 4 || game_manager_script.resource_collection_script.Get_Current_Collector_Key() == collector_key)
                {
                    //Calls the function to change the task
                    game_manager_script.Change_Task(4);
                }
                //Call the function to change the collector
                game_manager_script.resource_collection_script.Change_Resouce_Collection(collector_key);
                //Says that the button is being pressed
                button_pressed = true;
            }
            //Validates the method
            else { print("Invalid collector_key"); }
        }
    }

    void Collect_All_Button()
    {
        //Calls method with 0 as an input
        UI_Resource_Collector_Controller(0);
    }
    void Collect_Wood_Button()
    {
        //Calls method with 0 as an input
        UI_Resource_Collector_Controller(1);
    }
    void Collect_Stone_Button()
    {
        //Calls method with 0 as an input
        UI_Resource_Collector_Controller(2);
    }
    void Collect_Iron_Button()
    {
        //Calls method with 0 as an input
        UI_Resource_Collector_Controller(3);
    }

    //GENERAL_BUILDINGS
    void General_Buildings_Button(){
        if (button_pressed == false){
            //If tabs is closed
            if (general_buildings_tab_active == false){
                //Open tab and close every other tab
                general_buildings_tab_active = true;
                utility_buildings_tab_active = false;
                resource_buildings_tab_active = false;
                resource_collection_tab_active = false;
                general_buildings_tab.SetActive(true);
                utility_buildings_tab.SetActive(false);
                resource_buildings_tab.SetActive(false);
                resource_collection_tab.SetActive(false);}
            //If tabs is open
            else if (general_buildings_tab_active == true){
                //Close tab
                general_buildings_tab_active = false;
                general_buildings_tab.SetActive(false);}
            button_pressed = true;}}

    //UTILITY_BUILDINGS
    void Utility_Buildings_Button(){
        if (button_pressed == false){
            //If tabs is closed
            if (utility_buildings_tab_active == false){
                //Open tab and close every other tab
                general_buildings_tab_active = false;
                utility_buildings_tab_active = true;
                resource_buildings_tab_active = false;
                resource_collection_tab_active = false;
                general_buildings_tab.SetActive(false);
                utility_buildings_tab.SetActive(true);
                resource_buildings_tab.SetActive(false);
                resource_collection_tab.SetActive(false);}
            //If tabs is open
            else if (utility_buildings_tab_active == true){
                //Close tab
                utility_buildings_tab_active = false;
                utility_buildings_tab.SetActive(false);}
            button_pressed = true;}}

    //RESOURCE_BUILDINGS
    void Resource_Buildings_Button(){
        if (button_pressed == false){
            //If tabs is closed
            if (resource_buildings_tab_active == false){
                //Open tab and close every other tab
                general_buildings_tab_active = false;
                utility_buildings_tab_active = false;
                resource_buildings_tab_active = true;
                resource_collection_tab_active = false;
                general_buildings_tab.SetActive(false);
                utility_buildings_tab.SetActive(false);
                resource_buildings_tab.SetActive(true);
                resource_collection_tab.SetActive(false);}
            //If tabs is open
            else if (resource_buildings_tab_active == true){
                //Close tab
                resource_buildings_tab_active = false;
                resource_buildings_tab.SetActive(false);}
            button_pressed = true;}}

    //RESOURCE_COLLECTION
    void Resource_Collection_Button(){
        if (button_pressed == false){
            //If tabs is closed
            if (resource_collection_tab_active == false){
                //Open tab and close every other tab
                general_buildings_tab_active = false;
                utility_buildings_tab_active = false;
                resource_buildings_tab_active = false;
                resource_collection_tab_active = true;
                general_buildings_tab.SetActive(false);
                utility_buildings_tab.SetActive(false);
                resource_buildings_tab.SetActive(false);
                resource_collection_tab.SetActive(true);}
            //If tabs is open
            else if (resource_collection_tab_active == true){
                //Close tab
                resource_collection_tab_active = false;
                resource_collection_tab.SetActive(false);}
            button_pressed = true;}}

    //INCREASING AND DECREASNG BUTTONS
    void UI_Increase_Buttons(int job_key){
        //Alls method to be run only once when the button is pressed
        if (button_pressed == false){
            //If the number of employed in this job is less that the number of this type of jobs
            if (data_manager_script.Check_Total_Employed(job_key) < data_manager_script.Check_Jobs(job_key) && data_manager_script.Get_Unemployed() > 0){
                //Adds 1 from the employment slots
                data_manager_script.Change_Employer_Slots(job_key, 1);
                //Add 1 to the total employed in a specific job
                data_manager_script.Change_Total_Employed(job_key, 1);
            }
            //Changes bool to true
            button_pressed = true;
        }
    }
    void UI_Decrease_Button(int job_key){
        //Alls method to be run only once when the button is pressed
        if (button_pressed == false){
            //If the number of employed in the job is greater then zero
            if (data_manager_script.Check_Total_Employed(job_key) > 0){
                //Subtracts 1 from the employment slots
                data_manager_script.Change_Employer_Slots(job_key, -1);
                //Subtracts 1 to the total employed in a specific job
                data_manager_script.Change_Total_Employed(job_key, -1);
            }
            //Changes bool to true
            button_pressed = true;
        }
    }

    //Calls the methods to run the method with the correct input
    void Builder_Increase_Button(){
        UI_Increase_Buttons(4);}
    void Builder_Decrease_Button(){
        UI_Decrease_Button(4);}
    void Forester_Increase_Button(){
        UI_Increase_Buttons(0);}
    void Forester_Decrease_Button(){
        UI_Decrease_Button(0);}
    void Miner_Increase_Button(){
        UI_Increase_Buttons(1);}
    void Miner_Decrease_Button(){
        UI_Decrease_Button(1);}
    void Farmer_Increase_Button(){
        UI_Increase_Buttons(2);}
    void Farmer_Decrease_Button(){
        UI_Decrease_Button(2);}
    void Trader_Increase_Button(){
        UI_Increase_Buttons(3);}
    void Trader_Decrease_Button(){
        UI_Decrease_Button(3);}

    //MARKET_TRADE
    void Market_Trade_Button()
    {
    }

    //POLITICS
    void Politics_Button()
    {
    }

    //INVENTORY
    void Inventory_Button()
    {
    }

    //DATA
    void Data_Button()
    {
    }
}