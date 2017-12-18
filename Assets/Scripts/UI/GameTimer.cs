using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;
        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) 
        {
            WinCondition();
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    void WinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach(GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }

}
