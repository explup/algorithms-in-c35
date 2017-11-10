using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructure
{
    public class DoubleLinkedList
    {
        public DoubleLinkedNode Header { get; set; }

        public DoubleLinkedNode Tailer { get; set; }

        public void Insert(object value)
        {
            if (Header == null)
            {
                DoubleLinkedNode header = new DoubleLinkedNode()
                {
                    Value = value,
                    PrevNode = null,
                    NextNode = null,
                };
                Header = header;
                Tailer = header;
            }
            else
            {
                if (Tailer != null)
                {
                    DoubleLinkedNode newNode = new DoubleLinkedNode()
                    {
                        Value = value,
                        NextNode = null,
                        PrevNode = Tailer,
                    };

                    Tailer.NextNode = newNode;
                    Tailer = newNode;
                }
            }
        }

        public bool Contains(object value)
        {
            DoubleLinkedNode visitingNode = Header;
            while (visitingNode != null && !visitingNode.Value.Equals(value))
            {
                visitingNode = visitingNode.NextNode;
            }

            if (visitingNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Delete(object value)
        {
            if(Header == null)
            {
                return false;
            }

            DoubleLinkedNode preNode = null;
            DoubleLinkedNode visitingNode = Header;
            while (visitingNode != null && !visitingNode.Value.Equals(value))
            {
                preNode = visitingNode;
                visitingNode = visitingNode.NextNode;
            }
            if (visitingNode != null)
            {
                if (preNode == null)
                {
                    if (visitingNode.NextNode != null)
                    {
                        Header = Header.NextNode;
                        Header.PrevNode = null;
                    }
                    else
                    {
                        Header = null;
                        Tailer = null;
                    }

                }
                else
                {
                    if (visitingNode.NextNode != null)
                    {
                        preNode.NextNode = visitingNode.NextNode;
                        visitingNode.NextNode.PrevNode = preNode;
                    }
                    else
                    {
                        preNode.NextNode = null;
                        Tailer = preNode;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DoubleLinkedNode> Travel()
        {
            DoubleLinkedNode node = Header;
            while (node != null)
            {
                yield return node;
                node = node.NextNode;
            }
        }

        public IEnumerable<DoubleLinkedNode> ReverseTravel()
        {
            DoubleLinkedNode node = Tailer;
            while (node != null)
            {
                yield return node;
                node = node.PrevNode;
            }
        }
        
    }

    public class DoubleLinkedNode
    {
        public object Value { get; set; }
        public DoubleLinkedNode NextNode { get; set; }
        public DoubleLinkedNode PrevNode { get; set; }

        public bool Equals(SingleLinkedNode n)
        {
            // If parameter is null return false:
            if ((object)n == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Value == n.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }


}
