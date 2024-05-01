namespace OopLaba7
{
    public class Node {
        private Node _nextElement;
        
        public Node NextElement
        {
            get { return _nextElement; }
            set { _nextElement = value; }
        }
        private short _data;
        public short Data{
            get { return _data; }
            set { _data = value; }
        }

        public Node(short data){
            this._data=data;
            this._nextElement=null;
        }
    }

}