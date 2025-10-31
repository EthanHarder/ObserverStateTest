using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    [SerializeField]
    public float startPoint;
    [SerializeField]
    public float endPoint;

    [SerializeField]
    GameObject ui;


    public void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerStateHandler>().ProgressEvent.AddListener(OnEventTriggered);

    }
    public void OnEventTriggered()
    {
        RectTransform rectTransform = ui.GetComponent<RectTransform>();

        float weight = GameObject.Find("Player").GetComponent<PlayerStateHandler>().progress / 100;
        Mathf.Clamp(weight, 0.0f,1.0f);
        rectTransform.position = new Vector3(rectTransform.position.x, Mathf.Lerp(startPoint, endPoint, weight));
    }
}
