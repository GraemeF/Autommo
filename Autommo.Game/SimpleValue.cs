namespace Autommo.Game
{
    #region Using Directives

    using System;

    #endregion

    public abstract class SimpleValue<TValue>
    {
        private TValue _value;

        protected SimpleValue(TValue value)
        {
            Value = value;
        }

        private TValue Value
        {
            get { return _value; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value");

                _value = value;
            }
        }

        public static bool operator ==(SimpleValue<TValue> operand, SimpleValue<TValue> operand2)
        {
            if (ReferenceEquals(operand, operand2))
                return true;

            return !ReferenceEquals(null, operand) && operand.Equals(operand2);
        }

        public static bool operator !=(SimpleValue<TValue> operand, SimpleValue<TValue> operand2)
        {
            return !(operand == operand2);
        }

        public override bool Equals(object obj)
        {
            var other = obj as SimpleValue<TValue>;

            return other != null &&
                   GetType() == other.GetType() &&
                   Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}