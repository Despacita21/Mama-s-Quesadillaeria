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

    [SerializeField] private Vector3 OrderStationPosition;
    [SerializeField] private Vector3 BuildStationPosition;
    [SerializeField] private Vector3 CookingStationPosition;
    [SerializeField] private Vector3 ChipsStationPosition;

    [Space(10)]

    [Header("Change Scenes")]

    [SerializeField] Animator transitionAnimator;



    public void SwitchScenes(int requestedScene)
    {
        if (requestedScene != (int)currentScene)
        {
            currentScene = (Scenes)requestedScene;
            transitionAnimator.Play("SwipeAnim");
            Vector3 requestedPosition;
            switch (requestedScene)
            {
                case 0:
                    requestedPosition = OrderStationPosition;
                    break;
                case 1:
                    requestedPosition = BuildStationPosition;
                    break;
                case 2:
                    requestedPosition = CookingStationPosition;
                    break;
                case 3:
                    requestedPosition = ChipsStationPosition;
                    break;
                default:
                    requestedPosition = Vector3.zero;
                    break;
            }

            StartCoroutine(AnimationTimer(requestedPosition));
        }
    }

    public IEnumerator AnimationTimer(Vector3 requestedPosition)
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = requestedPosition;
    }

}