using UnityEngine;

namespace Betterfly.BetterCode
{
    public class AutoRotateController : MonoBehaviour
    {
        [SerializeField] private Transform _wantRotateTrans;
        [SerializeField] private Vector3 _rotateAxis = Vector3.up;
        [SerializeField] private Space _rotateSpace = Space.Self;
        [SerializeField] private float _rotateSpeed = 1F;
        [SerializeField] private bool _autoRotate;

        public Transform WantRotateTrans
        {
            get { return _wantRotateTrans; }
            set { _wantRotateTrans = value; }
        }

        public Vector3 RotateAxis
        {
            get { return _rotateAxis; }
            set { _rotateAxis = value; }
        }

        public Space RotateSpace
        {
            get { return _rotateSpace; }
            set { _rotateSpace = value; }
        }

        public float RotateSpeed
        {
            get { return _rotateSpeed; }
            set { _rotateSpeed = value; }
        }

        public bool AutoRotate
        {
            get { return _autoRotate; }
            set { _autoRotate = value; }
        }
    
        private void Update()
        {
            if (AutoRotate && WantRotateTrans != null)
            {
                WantRotateTrans.Rotate(RotateAxis,RotateSpeed * Time.deltaTime,RotateSpace);
            }
        }
    }
}