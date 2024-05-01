using System;

namespace OopLaba7
{
    public class MyList {
        Node _head;
        private int _counterOfElements;

        public MyList() {
            this._head = null;
        }

        public int Size() {
            return _counterOfElements;
        }

        public void Add(short data) {
            Node newNode = new Node(data);
            if (_head == null) {
                _head = newNode;
            } else {
                Node current = _head;
                while (current.NextElement != null) {
                    current = current.NextElement;
                }
                current.NextElement=newNode;
            }
            _counterOfElements++;
        }
        
        public short Get(int index) {
            if (_head == null || index < 0) {
                throw new Exception("Invalid index or empty list");
            }
            Node current = _head;
            for (int i = 0; i < index; i++) {
                current = current.NextElement;
                if (current == null) {
                    throw new Exception("Index out of range");
                }
            }
            return current.Data;
        }

        public void Delete(int index) {
            _counterOfElements--;
            if (_head == null || index < 0) {
                throw new Exception("Invalid index or empty list");
            }
            if (index == 0) {
                _head = _head.NextElement;
                return;
            }
            Node prev = null;
            Node current = _head;
            for (int i = 0; i < index; i++) {
                prev = current;
                current = current.NextElement;
                if (current == null) {
                    throw new Exception("Index out of range");
                }
            }
            prev.NextElement=current.NextElement;
        }

        public MyList FindMultiples(short number) {
            short element;
            MyList multiples = new MyList();
            for (int i = 0; i < this.Size(); i++) {
                element = this.Get(i);
                if (element % number == 0) {
                    multiples.Add(element);
                }
            }
            return multiples;
        }

        public void ReplaceEvenPositionElementsWithZero() {
            for (int i = 0; i < this.Size(); i++) {
                if (i % 2 != 0) {
                    this.Set(i, 0);
                }
            }
        }

        public void Set(int index, short value) {
            if (_head == null || index < 0) {
                throw new Exception("Invalid index or empty list");
            }
            Node current = _head;
            for (int i = 0; i < index; i++) {
                current = current.NextElement;
                if (current == null) {
                    throw new Exception("Index out of range");
                }
            }
            current.Data=value;
        }

        public MyList GetValuesGreaterThanThreshold(short number) {
            short element;
            MyList list = new MyList();
            for (int i = 0; i < this.Size(); i++) {
                element = this.Get(i);
                if (element > number) {
                    list.Add(element);
                }
            }
            return list;
        }
        public void DeleteElementsAtNonEvenPositions(){
            for (int i = this.Size()-1; i >=0; i--) {
                if(i%2==0){
                    this.Delete(i);
                }
            }
        }
        public void PrintList(){
            Console.Write("[  ");
            for (int i = 0; i < this.Size(); i++) {
                Console.Write(this.Get(i)+" ");
            }
            Console.Write("]");
        }
    }
}
