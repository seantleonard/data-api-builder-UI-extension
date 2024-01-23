// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This record is mutable.
/// </remarks>
public record HostOptions
{
    /// <summary>
    /// Gets or sets the CORS options.
    /// </summary>
    public CorsOptions? Cors { get; set; }

    /// <summary>
    /// Gets or sets the authentication options.
    /// </summary>
    public AuthenticationOptions? Authentication { get; set; }

    /// <summary>
    /// Gets or sets the host mode.
    /// </summary>
    public HostMode Mode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HostOptions"/> class.
    /// </summary>
    /// <param name="cors">The CORS options.</param>
    /// <param name="authentication">The authentication options.</param>
    /// <param name="mode">The host mode.</param>
    public HostOptions(CorsOptions? Cors, AuthenticationOptions? Authentication, HostMode Mode = HostMode.Production)
    {
        this.Cors = Cors;
        this.Authentication = Authentication;
        this.Mode = Mode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HostOptions"/> class.
    /// </summary>
    public HostOptions()
    {
        Cors = default!;
        Authentication = default!;
        Mode = HostMode.Production;
    }
  
     /// <summary>
    /// Returns the default host Global Settings
    /// If the user doesn't specify host mode. Default value to be used is Production.
    /// Sample:
    // "host": {
    //     "mode": "production",
    //     "cors": {
    //         "origins": [],
    //         "allow-credentials": true
    //     },
    //     "authentication": {
    //         "provider": "StaticWebApps"
    //     }
    // }
    /// </summary>
    public static HostOptions GetHostOptions(
        HostMode hostMode,
        IEnumerable<string>? corsOrigin,
        string authenticationProvider,
        string? audience,
        string? issuer)
    {
        string[]? corsOriginArray = corsOrigin is null ? new string[] { } : corsOrigin.ToArray();
        CorsOptions cors = new(Origins: corsOriginArray);
        AuthenticationOptions AuthenticationOptions;
        if (Enum.TryParse<EasyAuthType>(authenticationProvider, ignoreCase: true, out _)
            || AuthenticationOptions.SIMULATOR_AUTHENTICATION.Equals(authenticationProvider))
        {
            AuthenticationOptions = new(Provider: authenticationProvider, Jwt: null);
        }
        else
        {
            AuthenticationOptions = new(
                Provider: authenticationProvider,
                Jwt: new(audience, issuer)
            );
        }

        return new(
            Mode: hostMode,
            Cors: cors,
            Authentication: AuthenticationOptions);
    }
}
