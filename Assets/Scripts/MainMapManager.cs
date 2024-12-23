using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMapManager : MonoBehaviour
{
    private GameObject player;
    private Transform playerPosition;
    public bool isServerActivated = false;
    private GameObject ceiling;
    private Image targetImage;
    private float blinkSpeed = 1.0f;
    private float initialActivationTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ceiling = GameObject.Find("Ceiling Skylight");
        isServerActivated = false;

        GameObject obj = GameObject.Find("Alert_Red");
        targetImage = obj.GetComponent<Image>();
        Color color = targetImage.color;
        color.a = 0;
        targetImage.color = color;
        initialActivationTime = -10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isServerActivated)
        {
            foreach (Transform child in ceiling.GetComponentsInChildren<Transform>())
            {
                if (child.name == "LP_Skylight_glass_snaps")
                {
                    child.gameObject.SetActive(false);
                }
            }

            if(initialActivationTime < 0)
            {
                initialActivationTime = Time.time;
            }

            if(Time.time - initialActivationTime < 10.0f)
            {
                Color color = targetImage.color;
                color.a = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed)) * 0.15f;
                targetImage.color = color;
            }
            else
            {
                Color color = targetImage.color;
                color.a = 0;
                targetImage.color = color;
            }
        }
    }
}
