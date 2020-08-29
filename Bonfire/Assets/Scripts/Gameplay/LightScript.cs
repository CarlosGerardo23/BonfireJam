using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    Light _light;
    bool goUp;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        goUp = false;
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_light.intensity > 1.2f)
        {
            goUp = false;
        }
        else if (_light.intensity < .2f)
        {
            goUp = true;
        }

        if (goUp)
        {
            _light.intensity += Time.deltaTime * speed;
        }
        else
        {
            _light.intensity -= Time.deltaTime * speed;
        }
        
    }
}
