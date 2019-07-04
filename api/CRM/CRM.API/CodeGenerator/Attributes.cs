using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.CodeGenerator
{
    public class CodeGenEntityPluralizedAttribute : Attribute
    {
        public string Value { get; set; }

        public CodeGenEntityPluralizedAttribute(string value)
        {
            this.Value = value;
        }
    }

    public class CodeGenInputTypeValues
    {
        public const string Text = "Text";
        public const string Number = "Number";
        public const string Email = "Email";
        public const string Telephone = "Telephone";
        public const string TextArea = "TextArea";
        public const string Lookup = "Lookup";
    }
    
    public class CodeGenInputTypeAttribute : Attribute
    {
        public string Value { get; set; }

        public CodeGenInputTypeAttribute(string value)
        {
            this.Value = value;
        }
    }

    public class CodeGenFieldHiddenAttribute : Attribute
    {
        public bool Value { get; set; }

        public CodeGenFieldHiddenAttribute(bool value)
        {
            this.Value = value;
        }
    }

    public class CodeGenFieldDisabledAttribute : Attribute
    {
        public bool Value { get; set; }

        public CodeGenFieldDisabledAttribute(bool value)
        {
            this.Value = value;
        }
    }

    public class CodeGenFieldDisplayNameAttribute : Attribute
    {
        public string Value { get; set; }

        public CodeGenFieldDisplayNameAttribute(string value)
        {
            this.Value = value;
        }
    }

    public class CodeGenFieldSortAttribute : Attribute
    {
        public int Value { get; set; }

        public CodeGenFieldSortAttribute(int value)
        {
            this.Value = value;
        }
    }

    public class CodeGenRelationSortAttribute : Attribute
    {
        public int Value { get; set; }

        public CodeGenRelationSortAttribute(int value)
        {
            this.Value = value;
        }
    }

    public class CodeGenLookupIdAttribute : Attribute
    {
        public string Value { get; set; }

        public CodeGenLookupIdAttribute(string value)
        {
            this.Value = value;
        }
    }

    public class CodeGenLookupFieldToDisplayAttribute : Attribute
    {
        public bool Value { get; set; }

        public CodeGenLookupFieldToDisplayAttribute(bool value)
        {
            this.Value = value;
        }
    }
}
