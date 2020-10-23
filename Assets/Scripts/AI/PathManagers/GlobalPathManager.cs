using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.AI.PathManagers
{
    class GlobalWaypointsManager : MonoBehaviour
    {
        [SerializeField] Terrain Landscape;
        private static readonly object _locker = new object();
        private readonly CancellationTokenSource CancelTokenSource = new CancellationTokenSource();
        private Path CalculatedPath;

        private void Start()
        {
            var token = CancelTokenSource.Token;
            Task.Factory.StartNew(action: () => CalculateGlobalPath(token), cancellationToken: token);
        }

        public Vector3 GetPath()
        {
            lock (_locker)
            {
                var path = CalculatedPath;
            }
            return new Vector3();
        }

        private void CalculateGlobalPath(CancellationToken token)
        {
            while (token.IsCancellationRequested)
            {
                // calculations
                lock (_locker)
                {
                    CalculatedPath = new Path();
                }
            }
        }

        private void OnDestroy()
        {
            CancelTokenSource.Cancel();
        }

    }
}
