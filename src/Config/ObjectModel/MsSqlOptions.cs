// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Options for MsSql database.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record MsSqlOptions : IDataSourceOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MsSqlOptions"/> class.
    /// </summary>
    /// <param name="setSessionContext">The value indicating whether to set the session context.</param>
    public MsSqlOptions(bool SetSessionContext = true)
    {
        this.SetSessionContext = SetSessionContext;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MsSqlOptions"/> class.
    /// </summary>
    public MsSqlOptions()
        : this(true)
    {
        // empty
    }

    /// <summary>
    /// Gets or sets the value indicating whether to set the session context.
    /// </summary>
    public bool SetSessionContext { get; set; } = true;
}
