﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCAD.OpenCADFormat.PCBLayout
{
    public class Pad: PCBElement
    {
        public PadShape Shape;
    }

    public abstract class PadShape
    {

    }
}
