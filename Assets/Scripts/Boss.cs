using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame updat
    [Range(1, 1000)]
    public int hp;
    void Start()
    {
        hp = 500;
    }
}
