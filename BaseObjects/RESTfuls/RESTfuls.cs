﻿using System;
using System.Collections.Generic;

namespace SharpUtil.BaseObjects.RESTfuls
{
    public class RESTfuls<T>
    {
        public string Href { get; set; }
        public int Length { get; set; }
        public List<T> Items { get; set; }
    }
}
