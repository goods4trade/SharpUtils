using System;

namespace MAXX.Utils.BaseObjects
{
    [Serializable()]
    public class SQLParam : BaseEntity
    {
        private string _paramName;
        private object _paramValue;
        private string _paramType;

        // parameter name
        public string ParamName
        {
            get { return this._paramName; }
            set { this._paramName = value; }
        }

        // Data value
        public object ParamValue
        {
            get { return this._paramValue; }
            set { this._paramValue = value; }
        }

        // Data type
        public string ParamType
        {
            get { return this._paramType; }
            set { this._paramType = value; }
        }

        public SQLParam(string paramName, object paramValue, string paramType)
        {
            this._paramName = paramName;
            this._paramValue = paramValue;
            this._paramType = paramType;
        }

        public SQLParam() : this(string.Empty, null, string.Empty) { }

        public override string ToString()
        {
            return String.Format("ParamName: " + this._paramName + "; ParamValue: " + this._paramValue + "; ParamType: " + this._paramType);
        }

    }
}
