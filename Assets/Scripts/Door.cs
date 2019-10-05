using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorLock = true;
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
    
    void Endings(int scenario){
        switch (scenario)
        {
            case 1:
                doorLock = false;
                break;
            default:
                doorLock = true;
                break;
        }

    }
}
