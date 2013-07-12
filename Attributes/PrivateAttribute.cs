using System;
using System.Linq;
using System.Text;

namespace MAXX.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrivateAttribute : Attribute
    {
        public PrivateAttribute() { }
    }
}
