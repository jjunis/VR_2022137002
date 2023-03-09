using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstArray : MonoBehaviour
{

    public int[] numbers = new int[] { 9, -11, 6, -12, 1 };
    // Start is called before the first frame update
    void Start()
    {
        numbers[1] = 11;
        numbers[2] = 12;
        Debug.Log(numbers[0]);
    }
}
