using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Application
{
    public static class TypeExtensions
    {
        public static bool IsAssiableFromGenericType(this Type type, Type genericType)
        {
            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType);
        }
    }
}
