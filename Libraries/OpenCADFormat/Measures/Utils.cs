﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OpenCAD.OpenCADFormat.Measures
{
    public static class Utils
    {
        public static (double X, double Y) GetScreenDPI()
        {
            using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                return (X: graphics.DpiX, Y: graphics.DpiY);
            }
        }

        public static double GetMetricPrefixValue(MetricPrefix prefix) => prefix == null ? 1 : prefix.Multiplier;

        public static double GetAbsoluteAmount(Scalar measurement)
            => measurement.Unit.StandardAmount * measurement.Amount;

        public static double ConvertAmount(Scalar measurement, Unit outUnit) => GetAbsoluteAmount(measurement)
            / outUnit.StandardAmount;

        public static IEnumerable<Unit> GetSupportedUnits()
        {
            foreach (var unit in Units.SupportedUnits)
            {
                yield return unit;

                foreach (var prefix in MetricPrefixes.SupportedPrefixes)
                    yield return unit.Multiply(prefix);
            }
        }

        internal static Quantity FindEquivalentQuantity(Unit unit)
        {
            ///TODO: implement equivalency between quantities and selection logic

            return null;
        }
    }
}