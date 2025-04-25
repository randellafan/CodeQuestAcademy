using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField]private float offsetV;
    [SerializeField]private float offsetH;
    [SerializeField]private GameObject[] itemsTop;
    [SerializeField]private GameObject[] itemsBottom;

    void Start()
    {
        ShuffleItems(itemsTop);
        ShuffleItems(itemsBottom);

        ArrangeItems(itemsTop,offsetH);
        ArrangeItems(itemsBottom,-offsetV);
    }

    void ShuffleItems(GameObject[]items)
    {
        int numItems = items.Length;
        
        for (int i = numItems -1 ; i>0 ; i--)
        { 
            int randomIndex = Random.Range(0, i+1);
            GameObject temp= items[i];
            items[i] = items[randomIndex];
            items[randomIndex] = temp;
        }
    }
    void ArrangeItems(GameObject[] items,float offsetY)
    {
        int numItems = items.Length;
        float itemWidth = items[0].GetComponent<Renderer>().bounds.size.x + offsetV;
        float totalWidth = itemWidth * numItems;
        float firstItemX = transform.position.x - (totalWidth / 2 ) + (itemWidth / 2);

        for(int i = 0; i <numItems; i++)
        {
            float offsetX = firstItemX + i * itemWidth;
            Vector3 itemPosition = new Vector3(offsetX,transform.position.y + offsetY, transform.position.z);
            itemsBottom[i].transform.position = itemPosition;
        }
    }
}
