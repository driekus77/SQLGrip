using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace SQLGrip.SyntaxTree.Nodes
{
    public class SqlListNode<TItem> : SqlNode, IList<TItem>
    {
        private readonly List<TItem> listImpl = new List<TItem>();


        public TItem this[int index] { get => listImpl[index]; set => listImpl[index] = value; }

        public int Count {get => listImpl.Count;}

        public bool IsReadOnly {get; set;}

        public void Add(TItem item)
        {
            listImpl.Add(item);
        }


        public void AddRange(params TItem[] items)
        {
            listImpl.AddRange(items);
        }



        public void Clear()
        {
            listImpl.Clear();
        }

        public bool Contains(TItem item)
        {
            return listImpl.Contains(item);
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            listImpl.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return listImpl.GetEnumerator();
        }

        public int IndexOf(TItem item)
        {
            return listImpl.IndexOf(item);
        }

        public void Insert(int index, TItem item)
        {
            listImpl.Insert(index, item);
        }

        public bool Remove(TItem item)
        {
            return listImpl.Remove(item);
        }

        public void RemoveAt(int index)
        {
            listImpl.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listImpl.GetEnumerator();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach ( var n in listImpl )
            {
                sb.Append(n.ToString());
            }

            return sb.ToString();
        }
    }
}
