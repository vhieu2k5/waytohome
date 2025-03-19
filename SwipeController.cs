using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;

    [SerializeField] float moveSpeed = 5f; // Toc do di chuyen

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
    }

    void Update()
    {
        // Làm muot chuyen ðong bang Lerp
        levelPagesRect.localPosition = Vector3.Lerp(levelPagesRect.localPosition, targetPos, moveSpeed * Time.deltaTime);
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
        }
    }
}
