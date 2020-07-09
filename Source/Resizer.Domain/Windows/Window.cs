﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Resizer.Domain.Windows
{
    /// <summary>
    /// Defines a class that acts as model for active windows running on the system
    /// </summary>
    public class Window : IEquatable<Window>, IComparable<Window>
    {
        /// <summary>
        /// Gets or Sets the id of the window used as identification
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the window handle used to manipulate window information through the WinApi
        /// </summary>
        public IntPtr WindowHandle { get; set; }

        /// <summary>
        /// Gets or Sets the description of the application that owns the window
        /// <remarks>Defaults to an empty string</remarks>
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Gets or Sets the icon of the application that owns the window
        /// </summary>
        public Bitmap? Icon { get; set; }

        /// <summary>
        /// Gets or Sets the dimensions of the window
        /// </summary>
        public Dimension Dimensions { get; set; }

        /// <summary>
        /// Gets the resolution of the application
        /// </summary>
        public string Resolution => $"{Dimensions.Width} x {Dimensions.Height}";

        /// <summary>
        /// Comapares the current <see cref="Window"/> to a given <see cref="Window"/>
        /// </summary>
        /// <param name="other"><see cref="Window"/> to compare to the current instance</param>
        /// <returns>Returns <see langword="true"/> if the current istance is equal to the given <see cref="Window"/>, otherwise returns <see langword="false"/></returns>
        public bool Equals([AllowNull] Window other)
            => other?.Id == Id
            && other?.WindowHandle == WindowHandle
            && other?.Description == Description
            && other?.Dimensions == Dimensions;

        /// <summary>
        /// Comapares the current <see cref="Window"/> to a given <see cref="object"/>
        /// </summary>
        /// <param name="obj"><see cref="object"/> to compare to the current instance</param>
        /// <returns>Returns <see langword="true"/> if the current istance is equal to the given <see cref="object"/>, otherwise returns <see langword="false"/></returns>
        public override bool Equals(object? obj)
            => obj is Window window && Equals(window);

        /// <summary>
        /// Gets the hashCode of the <see cref="Window"/>
        /// </summary>
        /// <returns>Returns <see cref="int"/> containing a unique hashcode that represents the instance of the current <see cref="Window"/></returns>
        public override int GetHashCode() => (Id, WindowHandle, Description, Dimensions).GetHashCode();

        /// <summary>
        /// Compare if the current <see cref="Window"/> represents the same item as a given <see cref="Window"/>
        /// </summary>
        /// <param name="other"><see cref="Window"/> to compare against</param>
        /// <returns>Returns <see langword="true"/> if the <see cref="Window"/> represent the same <see cref="Window"/>, otherwise returns <see langword="false"/></returns>
        public int CompareTo([AllowNull] Window other)
        {
            if (Id == other?.Id)
            {
                return 0;
            }
            return -1;
        }
    }
}
