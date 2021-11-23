using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
	public Text PreviousScoreText;
	public Text BestPlayerText;
	public InputField mainInputField;

	// Checks if there is anything entered into the input field.
	void LockInput(InputField input)
	{
		if (input.text.Length > 0)
		{
			MainManager_DataPersistance.Instance.namePlayer = input.text;
		}
		else if (input.text.Length == 0)
		{
			Debug.Log("Main Input Empty");
			MainManager_DataPersistance.Instance.namePlayer = "...";
		}
	}

    private void Start()
    {
		//If there was a player before
		if (MainManager_DataPersistance.Instance != null)
		{
			mainInputField.text = MainManager_DataPersistance.Instance.namePlayer;
		}

		PreviousScoreText.text = MainManager_DataPersistance.Instance.PreviousScore.ToString();

		MainManager_DataPersistance.Instance.LoadHighPlayer(); // Cargar el mejor jugador

		BestPlayerText.text = MainManager_DataPersistance.Instance.nameHighScorePlayer +
			" - HIGH SCORE: " + MainManager_DataPersistance.Instance.scoreHighScorePlayer;

		//Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
		//Passes the main input field into the method when "LockInput" is invoked
		mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });
	}

	public void ToGameScene()
    {
		SceneManager.LoadScene(1);
    }

}
