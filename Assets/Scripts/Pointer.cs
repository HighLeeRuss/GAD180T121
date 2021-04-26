using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Pointer : MonoBehaviour

{
    [SerializeField] private Camera uiCamera;
    private Vector3 targetPosition;
    public RectTransform pointerRectTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(14.28f, 8.5f);
        //pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
      
        


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPositon = Camera.main.transform.position;
        fromPositon.z = 0f;
        Vector3 dir = (toPosition - fromPositon).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0,0,angle);

        float boarderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= boarderSize || targetPositionScreenPoint.x >= Screen.width - boarderSize ||
                           targetPositionScreenPoint.y <= boarderSize || targetPositionScreenPoint.y >= Screen.height - boarderSize;


        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
          if (cappedTargetScreenPosition.x <= boarderSize) cappedTargetScreenPosition.x = boarderSize;
          if (cappedTargetScreenPosition.x >= Screen.width - boarderSize) cappedTargetScreenPosition.x = Screen.width - boarderSize;
          if (cappedTargetScreenPosition.y <= boarderSize) cappedTargetScreenPosition.y = boarderSize;
          if (cappedTargetScreenPosition.y >= Screen.height - boarderSize) cappedTargetScreenPosition.y = Screen.height - boarderSize;

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);

        }

    }
}
