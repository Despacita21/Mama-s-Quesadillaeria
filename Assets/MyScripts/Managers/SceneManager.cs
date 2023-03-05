using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneManager : MonoBehaviour
{

    public enum Scenes
    {
        OrderStation,
        BuildStation,
        CookingStation,
        ChipsStation
    }

    [Header("Scenes")]

    [SerializeField] Scenes currentScene;

    [SerializeField] private Camera OrderStationCamera;
    [SerializeField] private Camera BuildStationCamera;
    [SerializeField] private Camera CookingStationCamera;
    [SerializeField] private Camera ChipsStationCamera;

    [Space(10)]

    [Header("Change Scenes")]

    [SerializeField] Animator transitionAnimator;



    public void SwitchScenes(int requestedScene)
    {
        if (requestedScene != (int)currentScene)
        {
            currentScene = (Scenes)requestedScene;
            transitionAnimator.Play("SwipeAnim");
            Camera requestedCamera = Camera.main;
            switch (requestedScene)
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
    }

}