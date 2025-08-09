using System;

namespace Core.Data
{
    [Serializable]
    public class BoolDataObject : PrimitiveBaseDataObject<bool>
    {
        public override DataType DataType => DataType.Bool;
        
        protected override bool CheckEquality(bool v1, bool v2)
        {
            return v1.Equals(v2);
        }
    }
}
