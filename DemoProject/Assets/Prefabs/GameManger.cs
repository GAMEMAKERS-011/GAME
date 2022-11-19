using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Completed
{
	using System.Collections.Generic;		//Allows us to use Lists. 
	using UnityEngine.UI;					//Allows us to use UI.
	
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance = null;				//Static instance of GameManager which allows it to be accessed by any other script.
        public GameObject overImage; 
		//Awake is always called before any Start functions
		void Awake()
		{
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);	
			
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
			
			//Call the InitGame function to initialize the first level 
			InitGame();
		}

		
		//Initializes the game for each level.
		void InitGame()
		{
			overImage = GameObject.Find("overImage");
            overImage.SetActive(false);
            Debug.Log("init Game");
		}
		
		
		//Update is called every frame.
		void Update()
		{
            if(Input.GetKeyUp(KeyCode.UpArrow)){
                GameOver();
                Debug.Log("down");
            }
		}
		
		
		
		//GameOver is called when the player reaches 0 food points
		public void GameOver()
		{
			//Enable black background image gameObject.
			// overImage.SetActive(true);
            Debug.Log("Game over");
		}
    }
}
