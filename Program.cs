/*
Shopping list program that stores user inputted items into a cart, and displays total price
based on inputted items
*/
using System.Collections;

bool runProgram = true;
Dictionary<string, double> store = new Dictionary<string, double>

{
    {"Milk", 3.49},
    {"Eggs", 2.79},
    {"Bananas", 0.59},
    {"Bread", 2.99},
    {"Chicken Breast", 4.99},
    {"Rice", 1.99},
    {"Cheddar Cheese", 3.29},
    {"Orange Juice", 3.69}
};

string userInput;
List<string> cart = new List<string>();


do
{
    //Displays the store catalog, used formatting to keep the values uniform in presentation
    foreach(KeyValuePair<string, double> item in store)
    {
        System.Console.WriteLine($"{item.Key, -20}{item.Value, 10:F2}");
    }

    System.Console.WriteLine("Please enter an item name: ");
    userInput = Console.ReadLine();

    bool existsInStore = true;

    //checks if the item is in the store, if it is, break the loop
    foreach(string s in store.Keys)
    {
        if (s.ToLower().Contains(userInput.ToLower().Trim()))
        {
            cart.Add(s);
            existsInStore = true;
            break;
        }
        else
        {
            
            existsInStore = false;
        }
       
    }
    //if after going through loop, the item is not found, display this message
    if (existsInStore == false)
    {
        System.Console.WriteLine("This item does not exist in our store, please try again");
    }

    //Ask user if they want to input again
    runProgram = QuestionUser(runProgram);

    //If they do, nothing happens, goes back to start
    if (runProgram == true)
    {

    }
    else if (runProgram == false)
    {
        
        System.Console.WriteLine("Thank you for your order!");

        string mostExpensive = null;
        double mostValue = double.MinValue;
        string leastExpensive = null;
        double leastValue = double.MaxValue;
        double total = 0;

        //List that will sort the items from least to most expensive
        List<KeyValuePair<string, double>> sortCart = new List<KeyValuePair<string, double>>();
        
        /*
        Foreach loop displays all the items currently in the user's cart, adds the prices up
        to a total variable, as well as keeps track of which items are most or least expensive
        */
        foreach(string s in cart)
        {
            total += store[s];

            sortCart.Add(new KeyValuePair<string, double>(s, store[s]));
            if (store[s] > mostValue)
            {
                mostExpensive = s;
                mostValue = store[s];
            }

            if (store[s] < leastValue)
            {
                leastExpensive = s;
                leastValue = store[s];
            }
        }

        //Use the built-in sort method to sort the list based on value
        sortCart.Sort((x, y) => x.Value.CompareTo(y.Value));

        //Displays the cart, sorted from least to most expensive
        foreach(KeyValuePair<string, double> item in sortCart)
        {
            System.Console.WriteLine($"{item.Key, -20}{item.Value, 10}");
        }

        //Used math.round because one test case I used had like a bunch of decimals
        total = Math.Round(total, 2);

        //Display final information, and ends program
        System.Console.WriteLine($"Here is the total price: {total}");
        System.Console.WriteLine($"The most expensive item is: {mostExpensive}");
        System.Console.WriteLine($"The least expensive item is: {leastExpensive}");


        runProgram = false;
    }
    
    
} while (runProgram);

 //Method that asks user if they would like to continue running th eprogram
static bool QuestionUser(bool answer){
    while(true){
        System.Console.WriteLine("Would you like to add another item? Please enter yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower().Trim() == "yes"){
            answer = true;
            break;
        } 
        else if (choice.ToLower().Trim() == "no"){
            answer = false;
            break;
        } 
        else {
            System.Console.WriteLine("Invalid response");
        }
    }
    return answer;
}
