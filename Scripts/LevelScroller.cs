using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelScroller : MonoBehaviour
{
    public ScrollRect scrollRect; // ��������� ���� ������ ����� ���������
    public RectTransform contentPanel; // ������, ���������� ������ �������
    public Button[] levelButtons; // ������ ���� ������ �������
    public float scrollSpeed = 10f; // �������� ���������
    private float lastScrollPosition = 0f; // ���������� ��� ���������� ��������� ������� �������

    private void Start()
    {
        // ��������������� ��������� ������� ������� ��� ������
        scrollRect.verticalNormalizedPosition = PlayerPrefs.GetFloat("LastScrollPosition", 1f);
    }

    public void ScrollToLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelButtons.Length)
            return;

        float targetPosition = levelButtons[levelIndex].GetComponent<RectTransform>().anchoredPosition.y;
        StartCoroutine(SmoothScrollTo(targetPosition / contentPanel.sizeDelta.y));
    }

    private IEnumerator SmoothScrollTo(float targetPositionY)
    {
        while (Mathf.Abs(scrollRect.verticalNormalizedPosition - targetPositionY) > 0.001f)
        {
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, targetPositionY, Time.deltaTime * scrollSpeed);
            yield return new WaitForEndOfFrame();
        }
        lastScrollPosition = scrollRect.verticalNormalizedPosition;
        SaveScrollPosition();
    }

    private void SaveScrollPosition()
    {
        // ��������� ��������� ������� �������
        PlayerPrefs.SetFloat("LastScrollPosition", lastScrollPosition);
        PlayerPrefs.Save();
    }
}
