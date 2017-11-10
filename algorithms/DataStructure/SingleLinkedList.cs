using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.DataStructure
{
    public class SingleLinkedList
    {
        public SingleLinkedNode Header { get; set; }

        public SingleLinkedNode Tailer { get; set; }

        public void Insert(object value)
        {
            SingleLinkedNode newNode = new SingleLinkedNode()
            {
                Value = value,
                NextNode = null,
            };
            if (Header == null)
            {
                Header = newNode;
                Tailer = newNode;
            }
            else
            {
                if (Tailer != null)
                {
                    Tailer.NextNode = newNode;
                    Tailer = newNode;
                }
            }
        }

        public bool Contains(object value)
        {
            SingleLinkedNode visitingNode = Header;
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

            SingleLinkedNode preNode = null;
            SingleLinkedNode visitingNode = Header;
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

        public IEnumerable<SingleLinkedNode> Travel()
        {
            SingleLinkedNode node = Header;
            while (node != null)
            {
                yield return node;
                node = node.NextNode;
            }
        }

        public IEnumerable<SingleLinkedNode> ReverseTravel()
        {
            SingleLinkedNode node = Tailer;

            while (node != null)
            {
                yield return node;
                SingleLinkedNode preNode = node == Header ? null : Header;

                while (preNode!=null && preNode.NextNode != node)
                {
                    preNode = preNode.NextNode;
                }

                node = preNode;
            }
        }
        
    }

    public class SingleLinkedNode
    {
        public object Value { get; set; }
        public SingleLinkedNode NextNode { get; set; }

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
