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
    [SerializeField] private CameraShake camShake;

    public float blackHoleSpinSpeed = 10;
    public float blackHoleActiveSpinSpeed = 30;
    [Header("Shadow")]
    public GameObject shadowPref;
    public GameObject planetHightlight;
    public float shadowDistance = 1f;

    [Header("Design")]
    public float planetRepelForce;
    public float planetAttractForce;
    public ParticleSystem dieParticles;

    private void Start() {
        currentIndex = 0;
        LoadLevel();
    }

    public void ShakeCamera() {
        camShake.Shake();
    }

    public void LoadLevel() {
        if(currentLevel != null) {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[currentIndex % levels.Count]);
		AudioManager.Instance.StopBlackHoleSound();
    }
    public void LoadNextLevel() {
        currentIndex++;
        if(currentIndex % levels.Count == 0) {
            UIManager.Instance.OpenMainPage();
        }
        LoadLevel();
    }
    public void LoadPrevLevel() {
        currentIndex = Mathf.Max(currentIndex - 1, 0);
        LoadLevel();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            LoadNextLevel();
        }
    }

}
