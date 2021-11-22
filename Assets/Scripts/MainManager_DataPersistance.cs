using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager_DataPersistance : MonoBehaviour
{
    public static MainManager_DataPersistance Instance;

	public string namePlayer;
    public string PreviousScore = "0";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
