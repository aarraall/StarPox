using UnityEngine;
using System.Collections.Generic;
public class Obstacle : MonoBehaviour
{
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() // Don't use `OnEnable`, otherwise, each time your gameObject is enabled again, the function will run and you may end with several colliders to each children
    {
        addTriggerBoxCollider();
    }
        //Generate Collider
        private void addTriggerBoxCollider()
    {
      
            List<GameObject> childrenList = new List<GameObject>();
            //get all transforms in the hierarchy
            Transform[] children = GetComponentsInChildren<Transform>(true);
            //go through the transform array and only add their gameObjects to the list if they are not the parent (this) gameObject.
            for (int i = 0; i < children.Length; i++)
            {
                Transform child = children[i];
                if (child != transform)
                {
                    childrenList.Add(child.gameObject);
                }
            }
            //go thorugh the list and add the component.
            for (int i = 0; i < childrenList.Count; i++)
            {
                 boxCollider = childrenList[i].AddComponent<BoxCollider>();
                 boxCollider.isTrigger = true;
            }
        
    }
}
// todo add animations