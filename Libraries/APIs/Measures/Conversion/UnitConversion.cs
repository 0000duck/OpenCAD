﻿using System;

namespace OpenCAD.APIs.Measures.UnitConversion
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    /// <summary>
    /// Defines a conversion between two units. 
    /// The form is Y = A*X + B, where "A" is the multiplier, "B" is a constant.
    /// </summary>
    public class UnitConversion : IEquatable<UnitConversion>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        /// <summary>
        /// Initializes an instance of the UnitConversion class.
        /// </summary>
        /// <param name="sourceUnit">The source class.</param>
        /// <param name="targetUnit">The destination class.</param>
        /// <param name="factor">The multiplier.</param>
        public UnitConversion(Unit sourceUnit, Unit targetUnit, double factor)
        {
            SourceUnit = sourceUnit;
            TargetUnit = targetUnit;
            Factor = factor;
        }

        public override string ToString()
        {
            return $"{SourceUnit?.Name ?? "1"}→{TargetUnit?.Name ?? "1"}";
        }

        /// <summary>
        /// Gets the source class for this conversion.
        /// </summary>
        public Unit SourceUnit { get; }

        /// <summary>
        /// Gets the destination class for this conversion.
        /// </summary>
        public Unit TargetUnit { get; }

        /// <summary>
        /// Gets the multiplier.
        /// </summary>
        public double Factor { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is UnitConversion))
                return false;
            else
                return ((IEquatable<UnitConversion>)this).Equals((UnitConversion)obj);
        }

        bool IEquatable<UnitConversion>.Equals(UnitConversion other)
        {
            bool sourceUnitMatches = SourceUnit?.Equals(other.SourceUnit) ?? SourceUnit == other.SourceUnit;
            bool targetUnitMatches = TargetUnit?.Equals(other.TargetUnit) ?? TargetUnit == other.TargetUnit;
            return sourceUnitMatches && targetUnitMatches;
        }

        public UnitConversion Invert()
        {
            return new UnitConversion(TargetUnit, SourceUnit, 1.0 / Factor);
        }
    }
}
