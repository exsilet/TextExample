using UnityEngine;

public class SwapMover : MonoBehaviour
{
    private bool IsMobilePlatform;
    private bool _isDragging;
    private float _minSwipeDelta = 130f;
    private Vector2 _tapPoint, _swipeDelta;

    public enum SwipeType
    {
        Left,
        Right,
        Up,
        Dawn
    }

    public delegate void OnSwipeInput(SwipeType type);

    public static event OnSwipeInput SwipeEvent;

    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        IsMobilePlatform = false;
#else
        isMobilePlatform = true;
#endif
    }

    private void Update()
    {
        if (!IsMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _tapPoint = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    _isDragging = true;
                    _tapPoint = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }
        }

        CalculateSwipe();
    }

    private void CalculateSwipe()
    {
       _swipeDelta = Vector2.zero;

        if (_isDragging)
        {
            if (!IsMobilePlatform && Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _tapPoint;
            else if (Input.touchCount > 0)
                _swipeDelta = Input.touches[0].position - _tapPoint;
        }

        if (_swipeDelta.magnitude > _minSwipeDelta)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                    SwipeEvent(_swipeDelta.x < 0 ? SwipeType.Left : SwipeType.Right);
                else
                    SwipeEvent(_swipeDelta.x < 0 ? SwipeType.Up : SwipeType.Dawn);
            }

            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isDragging = false;
        _tapPoint = _swipeDelta = Vector2.zero;
    }
}