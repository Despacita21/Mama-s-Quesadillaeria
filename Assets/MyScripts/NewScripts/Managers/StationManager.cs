using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class StationManager : MonoBehaviour
{

    public static StationManager instance;
    private void Awake()
    {
        print("Awake has been called");
        instance = this;
    }


    public UnityEvent OnSceneTransition;
    public void TransitionScenes(string newScene)
    {
        OnSceneTransition.Invoke();
    }


    public enum Stations
    {
        OrderStation,
        BuildStation,
        CookingStation,
        ChipsStation
    }

    [Header("Scenes")]

    public Stations currentStation;

    [SerializeField] private Camera OrderStationCamera;
    [SerializeField] private Camera BuildStationCamera;
    [SerializeField] private Camera CookingStationCamera;
    [SerializeField] private Camera ChipsStationCamera;

    [Space(10)]

    [Header("Change Scenes")]

    [SerializeField] Animator transitionAnimator;



    public void SwitchScenes(int requestedStation)
    {
        if (requestedStation != (int)currentStation)
        {
            currentStation = (Stations)requestedStation;
            transitionAnimator.Play("SwipeAnim");
            Camera requestedCamera = Camera.main;
            switch (requestedStation)
            {
                case 0:
                    requestedCamera = OrderStationCamera;
                    break;
                case 1:
                    requestedCamera = BuildStationCamera;
                    break;
                case 2:
                    requestedCamera = CookingStationCamera;
                    break;
                case 3:
                    requestedCamera = ChipsStationCamera;
                    break;
                default:
                    Debug.LogError("No scene camera found");
                    break;
            }
            StartCoroutine(AnimationTimer(requestedCamera));
        }
    }

    public IEnumerator AnimationTimer(Camera requestedCamera)
    {
        yield return new WaitForSeconds(0.2f);
        OrderStationCamera.gameObject.SetActive(false);
        BuildStationCamera.gameObject.SetActive(false);
        CookingStationCamera.gameObject.SetActive(false);
        ChipsStationCamera.gameObject.SetActive(false);
        requestedCamera.gameObject.SetActive(true);
        OnSceneTransition.Invoke();
    }

}