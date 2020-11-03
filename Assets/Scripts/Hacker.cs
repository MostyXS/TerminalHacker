using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hacker : MonoBehaviour
{
    //Game Configuration.
    const string menuHint = "You may type menu at any time";
    string[] lvl1Pass = { "anime", "stray", "jesus" };
    string[] lvl2Pass = { "slojniy", "parol", "neugadaesh", "nevzizni" };
    string[] lvl3Pass = { "Nasasali", "ElonMuskSpasiX", "rocketapidarasov" };
    int level;

    enum Screen { MainMenu, Password, WinScreen };
    Screen currentScreen = Screen.MainMenu;
    string password;
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine(menuHint);

    }

    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack?");
        Terminal.WriteLine("Press 1 to hack public library");
        Terminal.WriteLine("Press 2 to hack police station");
        Terminal.WriteLine("Press 3 to hack NASA");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {

            ShowMainMenu();
        }
        else if (input == "close" || input == "quit" || input == "exit")
        {
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {

            SelectLvl(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
            ResetPassword();

    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.WinScreen;
        Terminal.WriteLine(menuHint);
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
        Terminal.WriteLine("Is it angel?");
                Terminal.WriteLine(@"
____ <==> ____
\___\(**)/___/
 \___|  |___/ 
     L  J 
     |__|
      vv
");
                break;
            case 2:
                Terminal.WriteLine("Nu eto zalupa");
                Terminal.WriteLine(@"
───────────────▄████████▄─
──────────────██▒▒▒▒▒▒▒▒██──
─────────────██▒▒▒▒▒▒▒▒▒█
────────────██▒▒▒▒▒▒▒▒▒▒██─
───────────██▒▒▒▒▒▒▒▒▒██▀──
──────────██▒▒▒▒▒▒▒▒▒▒██───
─────────██▒▒▒▒▒▒▒▒▒▒▒██────
────────██▒████▒████▒▒██──
────────██▒▒▒▒▒▒▒▒▒▒▒▒██────
────────██▒────▒▒────▒██──
────────██▒██──▒▒██──▒██──
────────██▒────▒▒────▒██──
────────██▒▒▒▒▒▒▒▒▒▒▒▒██────
───────██▒▒▒████████▒▒▒▒██─
─────██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██─

");
                break;

            default:
                Terminal.WriteLine("Default level reached");
                break;
    
        }
    } 

    

    private void SelectLvl(string input)
    {

        switch (input)
        {

            case "1":
                    level = 1;
                    AskForPassword(level);
                break;
            case "2":
                    level = 2;
                    password = lvl2Pass[Random.Range(0, lvl2Pass.Length)];
                    AskForPassword(level);
                break;
            case "3":
                    level = 3;
                    password = "GayPolicay";
                    AskForPassword(level);
                    break;
            case "007":
                    Terminal.WriteLine("Please take a lvl, Mister Bond");
                break;
            default:
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine("Please choose a valid lvl");

                    
                break;
        }
    }

    private void AskForPassword(int level)
    {

        currentScreen = Screen.Password;
        
        Terminal.WriteLine("You have chosen lvl" + level);
        ResetPassword();

    }

    private void ResetPassword()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Please enter your password");
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint:" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch(level)
        {
            case 1:
                password = lvl1Pass[Random.Range(0, lvl1Pass.Length)];
                break;
            case 2:
                password = lvl2Pass[Random.Range(0, lvl2Pass.Length)];
                break;
            case 3:
                password = lvl3Pass[Random.Range(0, lvl3Pass.Length)];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

