using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    private void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

    }

    [SerializeField] private List<GameObject> levels;

    private GameObject currentLevel;
    private int currentIndex;

    [Header("Design")]
    public float planetRepelForce;
    public float planetAttractForce;

    private void Start() {
        currentIndex = 0;
        LoadLevel();
    }

    public void LoadLevel() {
        if(currentLevel != null) {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[currentIndex % levels.Count]);
    }
    public void LoadNextLevel() {
        currentIndex++;
        LoadLevel();
    }
    public void LoadPrevLevel() {
        currentIndex = Mathf.Max(currentIndex - 1, 0);
        LoadLevel();
    }

}
