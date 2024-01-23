// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Defines the Entities that are exposed.
/// </summary>
/// <remarks>This record is mutable.</remarks>
public record Entity
{
    /// <summary>
    /// The underlying database object to which the exposed entity is connected to.
    /// </summary>
    public EntitySource Source { get; set; }

    /// <summary>
    /// The JSON may represent this as a bool or a string and we use a custom <c>JsonConverter</c> to convert that into the .NET type.
    /// </summary>
    public EntityGraphQLOptions GraphQL { get; set; }

    /// <summary>
    /// The JSON may represent this as a bool or a string and we use a custom <c>JsonConverter</c> to convert that into the .NET type.
    /// </summary>
    public EntityRestOptions Rest { get; set; }

    /// <summary>
    /// Permissions assigned to this entity.
    /// </summary>
    public EntityPermission[] Permissions { get; set; }

    /// <summary>
    /// Defines mappings between database fields and GraphQL and REST fields.
    /// </summary>
    public Dictionary<string, string>? Mappings { get; set; }

    /// <summary>
    /// Defines how an entity is related to other exposed entities and optionally provides details on what underlying database objects can be used to support such relationships.
    /// </summary>
    public Dictionary<string, EntityRelationship>? Relationships { get; set; }

    public const string PROPERTY_PATH = "path";
    public const string PROPERTY_METHODS = "methods";

    public Entity(
        EntitySource Source,
        EntityGraphQLOptions GraphQL,
        EntityRestOptions Rest,
        EntityPermission[] Permissions,
        Dictionary<string, string>? Mappings,
        Dictionary<string, EntityRelationship>? Relationships)
    {
        this.Source = Source;
        this.GraphQL = GraphQL;
        this.Rest = Rest;
        this.Permissions = Permissions;
        this.Mappings = Mappings;
        this.Relationships = Relationships;
    }

    public Entity()
    {
        Source = default!;
        GraphQL = default!;
        Rest = default!;
        Permissions = Array.Empty<EntityPermission>();
        Mappings = null;
        Relationships = null;
    }
}
