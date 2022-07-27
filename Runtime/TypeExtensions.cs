namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class TypeExtensions
    {
        public static System.Reflection.FieldInfo GetFieldViaPath(this System.Type type, string path)
        {
            var parentType = type;
            var fieldInfo = type.GetField(path);
            var perDot = path.Split('.');
            
            foreach (var fieldName in perDot)
            {
                fieldInfo = parentType.GetField(fieldName);
                if (fieldInfo == null)
                {
                    return null;
                }

                parentType = fieldInfo.FieldType;
            }
            
            return fieldInfo != null ? fieldInfo : null;
        }
    }
}