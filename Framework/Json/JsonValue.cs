﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Foster.Framework.Json
{

    public abstract class JsonValue
    {
        public readonly JsonType Type;

        public JsonValue(JsonType type)
        {
            Type = type;
        }

        public bool IsNull => Type == JsonType.Null;
        public bool IsBool => Type == JsonType.Bool;
        public bool IsNumber => Type == JsonType.Number;
        public bool IsString => Type == JsonType.String;
        public bool IsObject => Type == JsonType.Object;
        public bool IsArray => Type == JsonType.Array;

        public abstract bool Bool { get; }
        public abstract float Float { get; }
        public abstract double Double { get; }
        public abstract byte Byte { get; }
        public abstract char Char { get; }
        public abstract short Short { get; }
        public abstract ushort UShort { get; }
        public abstract int Int { get; }
        public abstract uint UInt { get; }
        public abstract long Long { get; }
        public abstract ulong ULong { get; }
        public abstract string String { get; }
        public abstract JsonObject? Object { get; }
        public abstract JsonArray? Array { get; }

        public static implicit operator JsonValue(bool value) => new JsonValue<bool>(JsonType.Bool, value);
        public static implicit operator JsonValue(float value) => new JsonValue<float>(JsonType.Number, value);
        public static implicit operator JsonValue(double value) => new JsonValue<double>(JsonType.Number, value);
        public static implicit operator JsonValue(byte value) => new JsonValue<byte>(JsonType.Number, value);
        public static implicit operator JsonValue(char value) => new JsonValue<char>(JsonType.Number, value);
        public static implicit operator JsonValue(short value) => new JsonValue<short>(JsonType.Number, value);
        public static implicit operator JsonValue(ushort value) => new JsonValue<ushort>(JsonType.Number, value);
        public static implicit operator JsonValue(int value) => new JsonValue<int>(JsonType.Number, value);
        public static implicit operator JsonValue(uint value) => new JsonValue<uint>(JsonType.Number, value);
        public static implicit operator JsonValue(long value) => new JsonValue<long>(JsonType.Number, value);
        public static implicit operator JsonValue(ulong value) => new JsonValue<ulong>(JsonType.Number, value);
        public static implicit operator JsonValue(string value) => new JsonValue<string>(JsonType.String, value);

        public static implicit operator bool(JsonValue value) => value.Bool;
        public static implicit operator float(JsonValue value) => value.Float;
        public static implicit operator double(JsonValue value) => value.Double;
        public static implicit operator byte(JsonValue value) => value.Byte;
        public static implicit operator char(JsonValue value) => value.Char;
        public static implicit operator short(JsonValue value) => value.Short;
        public static implicit operator ushort(JsonValue value) => value.UShort;
        public static implicit operator int(JsonValue value) => value.Int;
        public static implicit operator uint(JsonValue value) => value.UInt;
        public static implicit operator long(JsonValue value) => value.Long;
        public static implicit operator ulong(JsonValue value) => value.ULong;
        public static implicit operator string(JsonValue value) => value.String;

    }

    public class JsonNull : JsonValue
    {
        public JsonNull() : base(JsonType.Null)
        {

        }

        public override bool Bool => false;
        public override float Float => 0;
        public override double Double => 0;
        public override byte Byte => 0;
        public override char Char => (char)0;
        public override short Short => 0;
        public override ushort UShort => 0;
        public override int Int => 0;
        public override uint UInt => 0;
        public override long Long => 0;
        public override ulong ULong => 0;
        public override string String => string.Empty;
        public override JsonObject? Object => null;
        public override JsonArray? Array => null;
    }

    public class JsonValue<T> : JsonValue
    {

        public readonly T Value;

        public JsonValue(JsonType type, T value) : base(type)
        {
            Value = value;
        }

        public override bool Bool => (Value is bool value ? value : false);

        public override float Float
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is float value)
                        return value;
                    return Convert.ToSingle(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override double Double
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is double value)
                        return value;
                    return Convert.ToDouble(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override short Short
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is short value)
                        return value;
                    return Convert.ToInt16(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override byte Byte
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is byte value)
                        return value;
                    return Convert.ToByte(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override char Char
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is char value)
                        return value;
                    return Convert.ToChar(Value, NumberFormatInfo.InvariantInfo);
                }

                return (char)0;
            }
        }

        public override ushort UShort
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is ushort value)
                        return value;
                    return Convert.ToUInt16(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override int Int
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is int value)
                        return value;
                    return Convert.ToInt32(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override uint UInt
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is uint value)
                        return value;
                    return Convert.ToUInt32(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override long Long
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is long value)
                        return value;
                    return Convert.ToInt64(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override ulong ULong
        {
            get
            {
                if (IsNumber)
                {
                    if (Value is ulong value)
                        return value;
                    return Convert.ToUInt64(Value, NumberFormatInfo.InvariantInfo);
                }

                return 0;
            }
        }

        public override string String => (IsString ? ((Value as string) ?? "") : "");

        public override JsonObject? Object => (IsObject ? (this as JsonObject) : null);

        public override JsonArray? Array => (IsArray ? (this as JsonArray) : null);

    }
}
