using System;

namespace Core.Data
{
    [Serializable]
    public class FloatDataObject : PrimitiveBaseDataObject<float>
    {
        public override DataType DataType => DataType.Float;
        
        protected override bool CheckEquality(float v1, float v2)
        {
            return v1.Equals(v2);
        }
    }
}
