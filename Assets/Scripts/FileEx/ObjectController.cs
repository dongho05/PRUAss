using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCircle;
    private void Start()
    {
        if (ContinueScript.IsEnter == true)
        {
            var listObject = ContinueScript.GetInstance();
            foreach (var item in listObject)
            {

                GameObject circle = Instantiate(prefabCircle);
                circle.transform.position = new Vector3(item.x, item.y, 0f);
                circle.tag = "Circle";
            }
        }


        // Use the receivedObject as needed in the current scene
    }

}
