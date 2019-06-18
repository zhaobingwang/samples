using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Framework
{
    public static class MapperHelper
    {
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)AutoMapper.Mapper.Map(src, src.GetType(), typeof(TDest));
        }
    }
}