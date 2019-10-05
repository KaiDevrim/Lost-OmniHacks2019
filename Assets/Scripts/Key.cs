using UnityEngine;

public class Key : MonoBehaviour
{
    private bool keyMotionActive = false;

    private bool keyPickup = false;

    private bool keyAvoid = false;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void Endings(int scenario)
    {
        switch (scenario)
        {
            case 1:
            keyMotionActive = false;
            keyPickup = true;
            keyAvoid = false;
            Debug.Log("Case 1");
            break;
            case 2:
            keyMotionActive = true;
            keyPickup = false;
            keyAvoid = false;
            Debug.Log("Case 2");
            break;
            case 3:
            keyMotionActive = true;
            keyPickup = false;
            keyAvoid = false;
            Debug.Log("Case 3");
            break;
            case 4:
            keyMotionActive = true;
            keyPickup = false;
            keyAvoid = false;
            Debug.Log("Case 4");
            break;
            case 5:
            keyMotionActive = false;
            keyPickup = true;
            keyAvoid = true;
            Debug.Log("Case 5");
            break;
        }
        
    }
}

