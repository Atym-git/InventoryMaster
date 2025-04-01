using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"There is more than one {instance} in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        //Application.persistentDataPath is a default directory where the data will be saved
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }
    public void LoadGame()
    {
        //Load saved data from a file using file handler
        gameData = dataHandler.Load();

        //If no data to be found, initialize a new game
        if (gameData == null)
        {
            Debug.Log("No Data found to load");
            NewGame();
        }

        //TODO - Push the loaded data into all scripts than need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log($"Loaded Items Count: {gameData.itemCount}");
    }
    public void SaveGame()
    {
        //TODO - Pass the data to the other scripts to they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.Log($"Saved Items Count: {gameData.itemCount}");

        // Save the given data into file using data handler
        dataHandler.Save(gameData);
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
