namespace Oz.Client
{
    public class Counter
    {
        private readonly string _name;
        private int _count;

        public Counter(string id) => _name = id;

        public void Increment() => _count++;

        public int Count => _count;

        public override string ToString() => $"{_count} {_name}";
    }
}