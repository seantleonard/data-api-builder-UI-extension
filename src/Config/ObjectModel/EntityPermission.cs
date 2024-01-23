// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <summary>
/// Defines which Actions (Create, Read, Update, Delete, Execute) are permitted for a given role.
/// </summary>
/// <remarks>This record is mutable.</remarks>
#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public record EntityPermission
{
    /// <summary>
    /// Name of the role to which defined permission applies.
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// An array of what can be performed against the entity for the actions.
    /// This can be written in JSON using shorthand notation, or as a full object, with a custom <c>JsonConverter</c> to convert that into the .NET type.
    /// </summary>
    public EntityAction[] Actions { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityPermission"/> class.
    /// </summary>
    /// <param name="role">Name of the role to which defined permission applies.</param>
    /// <param name="actions">An array of what can be performed against the entity for the actions.
    /// This can be written in JSON using shorthand notation, or as a full object, with a custom <c>JsonConverter</c> to convert that into the .NET type.</param>
    public EntityPermission(string Role, EntityAction[] Actions)
    {
        this.Role = Role;
        this.Actions = Actions;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityPermission"/> class.
    /// </summary>
    public EntityPermission()
    {
        Role = default!;
        Actions = Array.Empty<EntityAction>();
    }
}
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
