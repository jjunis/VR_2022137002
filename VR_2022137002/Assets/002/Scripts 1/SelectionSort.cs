using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectionSort : MonoBehaviour
{
    public int NumberOfCubes = 10;
    public int CubeHeightMax = 10;
    public GameObject[] Cubes;
    // Start is called before the first frame update
    void Start()
    {
        InitalizeRandom();
        StartCoroutine(SelectionSortfunction(Cubes));
    }
    void InitalizeRandom()
    {
        Cubes = new GameObject[NumberOfCubes];  //10�� ť�긦 �����Ѵ�. 

        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);  //�����ϰ� ť�긦 ���� (1 ~ 10)

            GameObject Temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Temp.transform.localScale = new Vector3(0.9f, randomNumber / 2.0f, 1);
            Temp.transform.position = new Vector3(i - 5, randomNumber / 4.0f, -1);
            Temp.transform.parent = this.transform;                     //�θ� ������Ʈ ���̷�Ű ���ʿ� �ִ´�. 
            Cubes[i] = Temp;
        }
    }

    IEnumerator SelectionSortfunction(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)    //GameObject ���̵��� �ݺ�
        {
            min = i;
            yield return new WaitForSeconds(1); // for ���ȿ��� 1�ʾ� ��� ������ �����ش�. 
            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {   //���̸� ���Ͽ��� ������ ���� ����
                    min = j;
                }
            }

            if (min != 1)    //������ �ʿ��� ��� 
            {
                yield return new WaitForSeconds(1);
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;               //�迭������ ��ġ ��ȯ�� �Ѵ�. 
                tempPosition = unsortedList[i].transform.localPosition; //������ ȭ�鿡�� ��ü�Ǿ���� ��ġ�� ���� 

                LeanTween.moveLocalX(unsortedList[i], unsortedList[min].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(unsortedList[i], -3, 0.5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortedList[min], tempPosition.x, 1);
                LeanTween.moveLocalZ(unsortedList[min], 3, 0.5f).setLoopPingPong(1);
            }
            LeanTween.color(unsortedList[i], Color.green, 1.0f);    //��ü�ɰ� �ʷϻ����� ǥ�� 
        }
    }

}
