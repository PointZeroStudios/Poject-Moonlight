using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingScript : MonoBehaviour
{

    public float ScreenWidth;
    public float ScreenHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.aspect = ScreenWidth / ScreenHeight;
    }
    //copyright PointZeroStudios
}
