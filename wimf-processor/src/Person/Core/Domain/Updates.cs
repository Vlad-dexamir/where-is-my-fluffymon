using System;

namespace PersonApi
{
    public class UpdateActionType
    {
        public static readonly UpdateActionType Put = new("Put");
        public static readonly UpdateActionType Delete = new("Delete");

        public override string ToString()
        {
            return _typeName;
        }

        private readonly string _typeName;

        private UpdateActionType(string typeName)
        {
            _typeName = typeName;
        }
    }

    public class UpdateAction<T>
    {
        public readonly T? Value;
        public readonly UpdateActionType? Action;

        public UpdateAction(T? value, UpdateActionType? action)
        {
            if (value == null && action != UpdateActionType.Delete)
            {
                throw new ArgumentNullException(
                    string.Empty,
                    $"A {UpdateActionType.Delete} action cannot have a value"
                    );
            }

            if (value == null && action == null)
            {
                throw new ArgumentNullException(
                    string.Empty,
                    "Please supply a Value or an Action "
                    );
            }

            if (value != null)
            {
                Value = value;
            }

            if (action != null)
            {
                Action = action;
            }
        }
    }
}