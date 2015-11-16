using System;

namespace CodeCop.Setup.Enums
{
    /// <summary>
    /// Indicates the position of interception.
    /// </summary>
    [Flags]
    public enum Intercept
    {
        Before   = 1        << 0,
        Override = Before   << 1,
        After    = Override << 2,
        Error    = After    << 3
    }
}