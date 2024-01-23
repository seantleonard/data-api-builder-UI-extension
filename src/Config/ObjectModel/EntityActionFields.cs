// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record EntityActionFields
{
    /// <summary>
    /// Exclude cannot be null, it is initialized with an empty set - no field is excluded.
    /// </summary>
    public HashSet<string> Exclude { get; set; }

    /// <summary>
    /// Include being null indicates that it was not specified in the config.
    /// This is used later (in authorization resolver) as an indicator that
    /// Include resolves to all fields present in the config.
    /// And so, unlike Exclude, we don't initialize it with an empty set when null.
    /// </summary>
    public HashSet<string>? Include { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionFields"/> class.
    /// </summary>
    /// <param name="exclude">The fields to exclude.</param>
    /// <param name="include">The fields to include.</param>
    public EntityActionFields(HashSet<string> Exclude, HashSet<string>? Include = null)
    {
        this.Exclude = Exclude;
        this.Include = Include;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityActionFields"/> class.
    /// </summary>
    public EntityActionFields()
    {
        Exclude = new HashSet<string>();
        Include = null;
    }
}
