// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record EntityAction
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityAction"/> class.
    /// </summary>
    /// <param name="action">The entity action.</param>
    /// <param name="fields">The entity action fields.</param>
    /// <param name="policy">The entity action policy.</param>
    public EntityAction(EntityActionOperation Action, EntityActionFields? Fields, EntityActionPolicy? Policy)
    {
        this.Action = Action;
        this.Fields = Fields;
        this.Policy = Policy;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityAction"/> class.
    /// </summary>
    public EntityAction()
    {
        Action = default!;
        Fields = default!;
        Policy = default!;
    }

    /// <summary>
    /// Gets or sets the entity action.
    /// </summary>
    public EntityActionOperation Action { get; set; }

    /// <summary>
    /// Gets or sets the entity action fields.
    /// </summary>
    public EntityActionFields? Fields { get; set; }

    /// <summary>
    /// Gets or sets the entity action policy.
    /// </summary>
    public EntityActionPolicy? Policy { get; set; }

    public static readonly HashSet<EntityActionOperation> ValidPermissionOperations = new() { EntityActionOperation.Create, EntityActionOperation.Read, EntityActionOperation.Update, EntityActionOperation.Delete };
    public static readonly HashSet<EntityActionOperation> ValidStoredProcedurePermissionOperations = new() { EntityActionOperation.Execute };
}
