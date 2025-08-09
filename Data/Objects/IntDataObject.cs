using System;

namespace Core.Data
{
    [Serializable]
    public class IntDataObject : PrimitiveBaseDataObject<int>
    {
        public override DataType DataType => DataType.Int;
        
        protected override bool CheckEquality(int v1, int v2)
        {
            return v1.Equals(v2);
        }
    }
}
