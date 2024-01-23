// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record JwtOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JwtOptions"/> class.
    /// </summary>
    /// <param name="audience">The audience.</param>
    /// <param name="issuer">The issuer.</param>
    public JwtOptions(string? Audience, string? Issuer)
    {
        this.Audience = Audience;
        this.Issuer = Issuer;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtOptions"/> class.
    /// </summary>
    public JwtOptions()
    {
        Audience = default!;
        Issuer = default!;
    }

    /// <summary>
    /// Gets or sets the audience.
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Gets or sets the issuer.
    /// </summary>
    public string? Issuer { get; set; }
}
