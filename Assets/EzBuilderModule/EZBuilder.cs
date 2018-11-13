using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EZBuilder : MonoBehaviour {

    public Sprite texture;

    public int SizeX, SizeY;

    public static int newSizeX, newSizeY;

    public bool collition, parallax, snapToGrid;

    public int LayerNum;

    public BoxCollider2D bc;

    //Only run in the Editor, to save PC usage ;)
#if UNITY_EDITOR

    public void Awake()
    {
        bc = GetComponent<BoxCollider2D>();

        newSizeX = SizeX;
        newSizeY = SizeY;
    }

    public void Update () {

        //Snap to the World grid
        if (snapToGrid)
        {
            Vector3 SnapToLocation = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
            gameObject.transform.position = SnapToLocation;

            bc.transform.position = gameObject.transform.position;
        }

        //Add Collition
        float x1 = (float)SizeX / 2;
        float y1 = (float)SizeY / 2;

        Vector2 boxCollPos = new Vector2(x1, y1);
        bc.offset = boxCollPos;

        Vector2 Size = new Vector2(SizeX, SizeY);
        bc.size = Size;

        //For collition toggle
        if (collition)
            bc.enabled = true;
        else
            bc.enabled = false;

        //On size change remove and redraw objects
        if (newSizeX != SizeX || newSizeY != SizeY) {
            newSizeX = SizeX;
            newSizeY = SizeY;
            DestroyObjects();
        }

        //Keep from lagging
        if (SizeX > 999) {SizeX = 999;}
        if (SizeY > 999) {SizeY = 999;}
    }

    //Destory all of this gameobjects squares
    public void DestroyObjects() {

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("ground");

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].transform.parent == gameObject.transform)
                DestroyImmediate(allObjects[i]);
        }

        AddObjects();
    }

    //reinstaiate gameobjects to array size
    void AddObjects() {

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                Vector3 pos = new Vector3(x + 0.5f, y + 0.5f, 0);
                GameObject empty = new GameObject();
                empty.name = "Block Number: " + x;
                empty.AddComponent<SpriteRenderer>();
                empty.GetComponent<SpriteRenderer>().sprite = texture;
                var XSize = empty.GetComponent<SpriteRenderer>().bounds.size.x;
                var YSize = empty.GetComponent<SpriteRenderer>().bounds.size.y;
                //empty.layer = LayerNum;
                empty.transform.position = new Vector2(pos.x * XSize + transform.position.x, pos.y * YSize + transform.position.y);
                empty.transform.parent = gameObject.transform;
                empty.tag = "ground";
            }
        }      
    }
#endif
}
