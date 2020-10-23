using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI.PathManagers
{
    public class Path : IList<Waypoint>
    {
        private List<Waypoint> waypoints = new List<Waypoint>();

        public Waypoint this[int index] { get => ((IList<Waypoint>)waypoints)[index]; set => ((IList<Waypoint>)waypoints)[index] = value; }

        public int Count => ((ICollection<Waypoint>)waypoints).Count;

        public bool IsReadOnly => ((ICollection<Waypoint>)waypoints).IsReadOnly;

        public void Add(Waypoint item)
        {
            ((ICollection<Waypoint>)waypoints).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Waypoint>)waypoints).Clear();
        }

        public bool Contains(Waypoint item)
        {
            return ((ICollection<Waypoint>)waypoints).Contains(item);
        }

        public void CopyTo(Waypoint[] array, int arrayIndex)
        {
            ((ICollection<Waypoint>)waypoints).CopyTo(array, arrayIndex);
        }

        public IEnumerator<Waypoint> GetEnumerator()
        {
            return ((IEnumerable<Waypoint>)waypoints).GetEnumerator();
        }

        public int IndexOf(Waypoint item)
        {
            return ((IList<Waypoint>)waypoints).IndexOf(item);
        }

        public void Insert(int index, Waypoint item)
        {
            ((IList<Waypoint>)waypoints).Insert(index, item);
        }

        public bool Remove(Waypoint item)
        {
            return ((ICollection<Waypoint>)waypoints).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Waypoint>)waypoints).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)waypoints).GetEnumerator();
        }
    }
}
