using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkList
{
    class Node
    {
        private float info;
        private Node next;
        public Node(float x)
        {
            info = x;
            next = null;
        }
        public float Info
        {
            set { info = value; }
            get { return info; }
        }
        public Node Next
        {
            set { next = value; }
            get { return next; }
        }
    }
    class SingleLinkList
    {
        private Node Head;
        public SingleLinkList()
        {
            Head = null;
        }
        public void AddHead(float x)
        {
            Node p = new Node(x);
            p.Next = Head;
            Head = p;
        }
        public void AddLast(float x)
        {
            Node p = new Node(x);
            if(Head == null)
            {
                Head = p;
            }
            else
            {
                Node q = new Node(x);
                q = Head;
                while(q.Next != null)
                {
                    q = q.Next;
                }
                q.Next = p;
            }
        }
        public void DeleteHead()
        {
            if(Head != null)
            {
                Node p = Head;
                Head = Head.Next;
                p.Next = null;
            }
        }
        public void DeleteLast()
        {
            if(Head != null)
            {
                Node p = Head;
                Node q = null;
                while(p.Next != null)
                {
                    q = p;
                    p = p.Next;
                }
                q.Next = null;
            }
        }
        public void ProcessList()
        {
            Node p = Head;
            while(p!=null)
            {
                Console.Write($"{p.Info}  ");
                p = p.Next;
            }
        }
        public void DeleteNode(float x)
        {
            Node p = Head;
            Node q = null;
            while(p!=null && p.Info != x)
            {
                q = p;
                p = p.Next;
            }
            if(p!=null)
            {
                if(p== Head)
                {
                    DeleteHead();
                }
                else
                {
                    q.Next = p.Next;
                    p.Next = null;
                }
            }
        }
        public Node findMax()
        {
            Node max = Head;
            Node p = Head.Next;
            while(p!=null)
            {
                if(p.Info > max.Info)
                {
                    max = p;
                }
                p = p.Next;
            }
            return max;
        }
        public float CalAvg()
        {
            float sum = 0;
            int count = 0;
            Node p = Head;
            while(p!=null)
            {
                sum += p.Info;
                count++;
                p = p.Next;
            }
            return sum / count;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkList l = new SingleLinkList();
            EnterList(l);
            Console.WriteLine("\nLink List: ");
            l.ProcessList();

            Console.WriteLine("\nLink List after DeleteHead: ");
            l.ProcessList();

            l.DeleteLast();
            Console.WriteLine("\nLink List after DeleteLast: ");
            l.ProcessList();

            Console.WriteLine("\nEnter Node value need delete: ");
            float x = float.Parse(Console.ReadLine());
            l.DeleteNode(x);

            Console.WriteLine($"\nNode max: {l.findMax().Info}");
            
            Console.WriteLine($"\nAverage value: {l.CalAvg()}");

            Console.ReadLine();
        }
        static void EnterList(SingleLinkList l)
        {
            string chon = "y";
            float x;
            while(chon != "n")
            {
                Console.Write("Nhap gia tri nut: ");
                x = float.Parse(Console.ReadLine());
                l.AddHead(x);
                Console.Write("Tiep tuc (y/n): ");
                chon = Console.ReadLine();
            }
        }
    }
}
