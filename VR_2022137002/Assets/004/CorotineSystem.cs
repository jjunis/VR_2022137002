using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorotineSystem : MonoBehaviour
{
    private Queue corountineQueue = new Queue();

    public void AddCoruntineQueue(IEnumerable coroutine)
    {
        corountineQueue.Enqueue(coroutine);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddCoruntineQueue(Logging(10));
        AddCoruntineQueue(Logging(100));
        AddCoruntineQueue(Logging(1000));
        if ( corountineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)corountineQueue.Dequeue());
        }
    }

    IEnumerable Logging(int number)
    {
        for(int i = number; i < number + 10; i++)
        {
            Debug.Log(i.ToString() + " <--");
            yield return new WaitForSeconds(0.1f);
        }

        if(corountineQueue.Count > 0)
        {
            StartCoroutine((IEnumerator)corountineQueue.Dequeue());
        }
    }
}
