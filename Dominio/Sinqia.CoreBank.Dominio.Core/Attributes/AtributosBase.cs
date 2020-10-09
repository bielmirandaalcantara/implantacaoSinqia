using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dominio.Core.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IgnorePersistenciaAttribute : System.Attribute
    {
        public IgnorePersistenciaAttribute()
        {
            
        }
    }
}
