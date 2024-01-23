// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record GraphQLRuntimeOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphQLRuntimeOptions"/> class.
    /// </summary>
    /// <param name="enabled">Whether the GraphQL runtime is enabled.</param>
    /// <param name="path">The path for the GraphQL endpoint.</param>
    /// <param name="allowIntrospection">Whether introspection is allowed.</param>
    public GraphQLRuntimeOptions(bool Enabled = true, string Path = DEFAULT_PATH, bool AllowIntrospection = true)
    {
        this.Enabled = Enabled;
        this.Path = Path;
        this.AllowIntrospection = AllowIntrospection;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GraphQLRuntimeOptions"/> class.
    /// </summary>
    public GraphQLRuntimeOptions()
        : this(true, DEFAULT_PATH, true)
    {
    }

    /// <summary>
    /// Gets or sets whether the GraphQL runtime is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the path for the GraphQL endpoint.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Gets or sets whether introspection is allowed.
    /// </summary>
    public bool AllowIntrospection { get; set; }

    /// <summary>
    /// The default path for the GraphQL endpoint.
    /// </summary>
    public const string DEFAULT_PATH = "/graphql";
}
