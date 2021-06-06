using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChemBlockMenu : MonoBehaviour
{
    [SerializeField] GameUtility gameUtility;
    [SerializeField] ElementType type;
    [SerializeField] Button mButton;
    [SerializeField] Image mImage;
    [SerializeField] bool selected = true;

    private Color baseColor, unselectedColor;

    //FF5722
    //new Color = BF003F
    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = GetComponent<Image>();
        baseColor = mImage.color;
        selected = true;
    }

    void Start()
    {
        ColorUtility.TryParseHtmlString("#5C001F", out unselectedColor);
        gameUtility.IsSelectedElement.Add(type, selected);
        SetButtonEvent();
    }

    private void SelectThis(bool state)
    {
        selected = state;
        int i = gameUtility.IsSelectedElement.Values.Where(x => x == true).Count();
        if (state)
        {
            mImage.color = baseColor;
            gameUtility.IsSelectedElement[type] = true;
        }
        else if (i > 1)
        { 
            mImage.color = unselectedColor;
            gameUtility.IsSelectedElement[type] = false;
        }
        gameUtility.UpdateUnselectedType?.Invoke();
    }

    private void SetButtonEvent()
    {
        mButton.onClick.AddListener(OnClickEvent);
    }

    private void OnClickEvent()
    {
        SelectThis(!selected);
    }
}
