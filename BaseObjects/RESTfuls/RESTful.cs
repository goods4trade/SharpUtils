﻿using System;
using System.Collections.Generic;

namespace MAXX.Utils.BaseObjects.RESTfuls
{
    public class RESTful<T>
    {
        public string Href { get; set; }
        public int Length { get; set; }
        public T Items { get; set; }
    }
}
