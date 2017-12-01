using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

//Singleton class
public class Player {

    //declaring gamecontroller object
    public UIController gameController;

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    //class object
    private static Player _instance;

    //class copy representing an object of Player class
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }

    //accessor and mutator for calculating score
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            //calls update method and updates the score in canvas
            gameController.UpdateUI();
        }
    }

    //accessor and mutator for calculating life
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                //calls update method and updates the health in canvas
                gameController.UpdateUI();
                //calls gameover method
                gameController._endGame();
            }
            else
            {
                //calls update method and updates the health in canvas
                gameController.UpdateUI();
            }
        }
    }

}
