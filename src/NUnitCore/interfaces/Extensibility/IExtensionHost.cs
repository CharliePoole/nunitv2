// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Core.Extensibility
{
    /// <summary>
    /// The IExtensionHost interface is implemented by each
    /// of NUnit's Extension hosts. Currently, there is
    /// only one host, which resides in the test domain.
    /// </summary>
    public interface IExtensionHost
    {
        /// <summary>
        /// Get a list of the ExtensionPoints provided by this host.
        /// </summary>
        IExtensionPoint[] ExtensionPoints
        {
            get;
        }

        /// <summary>
        /// Get an interface to the framework registry
        /// </summary>
        [Obsolete("Use the FrameworkRegistry extension point instead")]
        IFrameworkRegistry FrameworkRegistry
        {
            get;
        }

        /// <summary>
        /// Return an extension point by name, if present
        /// </summary>
        /// <param name="name">The name of the extension point</param>
        /// <returns>The extension point, if found, otherwise null</returns>
        IExtensionPoint GetExtensionPoint( string name );

        /// <summary>
        /// Gets the ExtensionTypes supported by this host
        /// </summary>
        /// <returns>An enum indicating the ExtensionTypes supported</returns>
        ExtensionType ExtensionTypes { get; }
    }
}
