using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelShifter : MonoBehaviour
{
    private List<Transform> participatorySceneTransforms = null;

    [SerializeField] private Transform cameraTransform = null;
    [SerializeField] private Transform levelObjectsTransform = null;

    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private TrailRenderer playerTrailFX = null;

    // Start is called before the first frame update
    void Start()
    {
        participatorySceneTransforms = new List<Transform>();

        //cameraTransform = Camera.main.transform;
        participatorySceneTransforms.Add(cameraTransform);

        for(int i = 0; i < levelObjectsTransform.childCount; i ++)
        {
            participatorySceneTransforms.Add(levelObjectsTransform.GetChild(i));
        }

        //for(int i = 0; i <)
    }

    // Update is called once per frame
    void Update()
    {
        float boundLimit = 1000f;

        //bounds' conditions
        bool leftOfBounds = cameraTransform.position.x < -boundLimit;
        bool rightofBounds = cameraTransform.position.x > boundLimit;
        bool aboveBounds = cameraTransform.position.y > boundLimit;
        bool belowBounds = cameraTransform.position.y < -boundLimit;

        if (leftOfBounds)
        {
            ShiftTransforms(new Vector3(boundLimit, 0, 0));
        }
        else if(rightofBounds)
        {
            ShiftTransforms(new Vector3(-boundLimit, 0, 0));
        }

        if(aboveBounds)
        {
            ShiftTransforms(new Vector3(0, -boundLimit, 0));
        }
        else if(belowBounds)
        {
            ShiftTransforms(new Vector3(0, boundLimit, 0));
        }
    }

    private void ShiftTransforms(Vector3 shiftPosition)
    {
        List<Transform> transforms = participatorySceneTransforms;

        playerTrailFX.Clear();
        playerTrailFX.transform.gameObject.SetActive(false);
        playerTrailFX.transform.gameObject.SetActive(true);
        playerTransform.position = playerTransform.position + shiftPosition;
        

        for (int i = 0; i < transforms.Count; i ++)
        {
            transforms[i].position = transforms[i].position + shiftPosition;
        }
    }
}
