﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using System;
using System.Globalization;
using System.Xml.Linq;

namespace Prolog.Code
{
    /// <summary>
    /// Represents a <see cref="CodeValue"/> containing a <see cref="DateTime"/> value.
    /// </summary>
    [Serializable]
    public sealed class CodeValueDateTime : CodeValue, IEquatable<CodeValueDateTime>, IImmuttable
    {
        public new const string ElementName = "CodeValueDateTime";

        public CodeValueDateTime(DateTime value)
        {
            Value = value;
        }

        public static new CodeValueDateTime Create(XElement xCodeValueDateTime)
        {
            var value = DateTime.Parse(xCodeValueDateTime.Value);
            return new CodeValueDateTime(value);
        }

        public override object Object
        {
            get { return Value; }
        }

        public DateTime Value { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var rhs = obj as CodeValueDateTime;
            if (rhs == null) return false;

            return Value == rhs.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(CodeValueDateTime lhs, CodeValueDateTime rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return true;

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null)) return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(CodeValueDateTime lhs, CodeValueDateTime rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public override XElement ToXElement()
        {
            return ToXElementBase(
                new XElement(ElementName, Value.ToString(CultureInfo.InvariantCulture)));
        }

        public override bool Equals(CodeValue other)
        {
            return Equals(other as CodeValueDateTime);
        }

        public bool Equals(CodeValueDateTime other)
        {
            if (ReferenceEquals(other, null)) return false;

            return Value == other.Value;
        }
    }
}
