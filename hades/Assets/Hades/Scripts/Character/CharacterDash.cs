using System.Collections;
using UnityEngine;

namespace Hades
{
    public class CharacterDash : MonoBehaviour
    {
        private bool isDashing;

        public void Dash()
        {
            isDashing = true;
            StartCoroutine(DashInternal());
        }

        private IEnumerator DashInternal()
        {
            yield return null;
        }
    }
}
