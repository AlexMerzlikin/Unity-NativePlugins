using Toast;
using UnityEngine;

namespace Example
{
    public class UnityToastExample : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(ShowToast), 0, 10);
            InvokeRepeating(nameof(ShowLongToast), 5, 10);
        }

        private void ShowToast()
        {
            UnityToast.ShowToast("Native Toast Short");
        }
        
        private void ShowLongToast()
        {
            UnityToast.ShowToast("Native Toast Long", ToastLength.Long);
        }
    }
}