// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Holds the global settings used at runtime for REST APIs.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record RestRuntimeOptions
{
    /// <summary>
    /// If the REST APIs are enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// The URL prefix path at which endpoints for all entities will be exposed.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Boolean property indicating whether extraneous fields are allowed in request body.
    /// The default value is true - meaning we don't allow extraneous fields by default in the rest request body.
    /// Changing the default value is a breaking change.
    /// </summary>
    public bool RequestBodyStrict { get; set; }

    public const string DEFAULT_PATH = "/api";

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRuntimeOptions"/> class.
    /// </summary>
    /// <param name="enabled">If the REST APIs are enabled.</param>
    /// <param name="path">The URL prefix path at which endpoints for all entities will be exposed.</param>
    /// <param name="requestBodyStrict">Boolean property indicating whether extraneous fields are allowed in request body.</param>
    public RestRuntimeOptions(bool Enabled = true, string Path = DEFAULT_PATH, bool RequestBodyStrict = true)
    {
        this.Enabled = Enabled;
        this.Path = Path;
        this.RequestBodyStrict = RequestBodyStrict;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RestRuntimeOptions"/> class.
    /// </summary>
    public RestRuntimeOptions()
    {
        Enabled = default!;
        Path = default!;
        RequestBodyStrict = default!;
    }
}
