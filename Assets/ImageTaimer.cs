using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTaimer : MonoBehaviour
{
public float MaxTime;
public bool Tick;
private Image img;
private float currenTime;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        currenTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Tick = false;
        currenTime -= Time.deltaTime;

        if (currenTime <= 0)
        {
            Tick = true;
            currenTime = MaxTime;
        }

        img.fillAmount = currenTime / MaxTime;
    }
}
