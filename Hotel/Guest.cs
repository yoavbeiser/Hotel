using System;
namespace Hotel
{
    public class Guest
    {
        private static readonly Random _rnd = new();
        public string Name { get; set; }

        public int GetSatisfaction()
        {
            return _rnd.Next(10);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Guest))
                return Equals(obj as Guest);

            return base.Equals(obj);
        }

        public bool Equals(Guest other)
        {
            return Name == other.Name;
        }
    }
}

