﻿using Gma.System.MouseKeyHook;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HandheldCompanion.Managers.Classes
{
    [Flags]
    public enum InputsChordType : ushort
    {
        None = 0,
        Click = 1,
        Hold = 2,
    }

    [Serializable]
    public class OutputKey
    {
        public int KeyValue { get; set; }
        public int ScanCode { get; set; }
        public int Timestamp { get; set; }
        public bool IsKeyDown { get; set; }
        public bool IsKeyUp { get; set; }
        public bool IsExtendedKey { get; set; }

        public override string ToString()
        {
            return ((Keys)KeyValue).ToString();
        }
    }

    [Serializable]
    public class InputsChord
    {
        public GamepadButtonFlags GamepadButtons { get; set; } = GamepadButtonFlags.None;
        public string SpecialKey { get; set; } = string.Empty;
        public List<OutputKey> OutputKeys { get; set; } = new();

        public InputsChordType InputsType { get; set; } = InputsChordType.Click;

        public InputsChord(GamepadButtonFlags GamepadButtons, string SpecialKey, List<OutputKey> OutputKeys, InputsChordType InputsType)
        {
            this.GamepadButtons = GamepadButtons;
            this.SpecialKey = SpecialKey;
            this.OutputKeys = OutputKeys;

            this.InputsType = InputsType;
        }

        public InputsChord()
        {
        }

        public void AddKey(KeyEventArgsExt args)
        {
            OutputKey key = new OutputKey()
            {
                KeyValue = args.KeyValue,
                ScanCode = args.ScanCode,
                Timestamp = args.Timestamp,
                IsKeyDown = args.IsKeyDown,
                IsKeyUp = args.IsKeyUp,
                IsExtendedKey = args.IsExtendedKey,
            };

            OutputKeys.Add(key);
        }
    }
}